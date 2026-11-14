using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace _1w4w.CMS.Manager
{
    public class ParseManager
    {
        /*

        {
          "id": "cmpl-CEgc0WvLn9UcE8W7KykZwgOr3yA2A",
          "object": "text_completion",
          "created": 1757616428,
          "model": "gpt-3.5-turbo-instruct:20230824-v2",
          "choices": [
            {
              "text": " och deras partners\n\nISBN: 9789174249073\nTitle: Sex, kärlek & aspergers syndrom : med kärleksskola för aspergare och deras partners\nDescription: Denna bok tar upp hur asperger påverkar sex och kärlekslivet, både för personer med aspergers syndrom och deras partners. Den ger också tips och råd för hur man kan förbättra kommunikationen och förståelsen i relationen.\nPagecount: 256\nImageurl: https://www.bokus.com/cgi-bin/product_image.cgi?image=/9789174249073.jpg&isbn=9789174249073&size=medium",
              "index": 0,
              "logprobs": null,
              "finish_reason": "stop"
            }
          ],
          "usage": {
            "prompt_tokens": 43,
            "completion_tokens": 154,
            "total_tokens": 197
          }
        }

         */

        public static string getSourceCode(string url)
        {
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                StreamReader sr = new StreamReader(resp.GetResponseStream(), Encoding.UTF8);
                string sourceCode = sr.ReadToEnd();
                sr.Close();
                resp.Close();
                return sourceCode;
            }
            catch
            {
                return "invalid";
            }
        }

        public static string getGroupWord(string url)
        {
            int startIndex = url.IndexOf("q=") + 2;
            url = url.Substring(startIndex, url.Length - startIndex);
            int endIndex = url.IndexOf("&");
            if (endIndex == -1) endIndex = url.Length;
            string groupWord = url.Substring(0, endIndex);
            groupWord = groupWord.Replace("&nbsp;", " ");
            groupWord = groupWord.Replace("&#39;", "'");
            groupWord = groupWord.Replace("&quot;", "\"");
            groupWord = groupWord.Replace("&amp;", "&");
            groupWord = groupWord.Replace("%3A", ":");
            return groupWord;
        }

        public static string Between(string text, string start, string end)
        {
            if (string.IsNullOrEmpty(text) ||
                string.IsNullOrEmpty(start) ||
                string.IsNullOrEmpty(end)
                ) { return ""; }
            string result;
            int pos1 = text.IndexOf(start) + start.Length;
            int pos2 = text.IndexOf(end);
            result = text.Substring(pos1, pos2 - pos1);
            //return result;
            if (end == "") return (text.Substring(pos1));
            else return text.Substring(pos1, pos2 - pos1);
        }
    }
}