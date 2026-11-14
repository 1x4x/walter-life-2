using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Net.NetworkInformation;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Encoders;
namespace _1w4w.CMS.Manager
{
    public class ColorManager
    {
        /// <summary>
        /// Get a small number of what colors an image contains. 
        /// i use this to set the backgroundcolor of my divs automatically 
        /// to one of the colors in the image
        /// 
        /// -----------
        /// Usage:
        /// -----------
        /// var bitmap = new Bitmap("colorful-colourful-ink-1065714.jpg");
        /// var quantized = ColorManager.Quantize(bitmap, 15);
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="colourCount"></param>
        /// <returns></returns>
        /// 
        public static Bitmap GetBitmapFromPng(string path)
        {
            Bitmap bmp = null;
            //string path = "path/to/input.png";

            // Load the PNG image
            using (var png = new Bitmap(path))
            {
                // Create a new Bitmap image with the same dimensions as the PNG image
                using (var bitmapImage = new Bitmap(png.Width, png.Height, PixelFormat.Format32bppArgb))
                {
                    // Draw the PNG image onto the Bitmap image
                    using (var graphics = Graphics.FromImage(bitmapImage))
                    {
                        graphics.DrawImage(png, new Rectangle(0, 0, png.Width, png.Height));
                        
                        //using (Image img = Image.FromFile(@"C:\a.jpg"))
                        using (Image img = Image.FromFile(path))
                        {
                            bmp = new Bitmap(img, 400, 400);
                            return bmp;
                        }
                        
                    }
                }
            }
        }
        public static string GetHexFromColor(Color color) {
            //return string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}",
            //             color.R,
            //             color.G,
            //             color.B,
            //             color.A);
            return string.Format("#{0:X2}{1:X2}{2:X2}",
                         color.R,
                         color.G,
                         color.B);
        }

        //public static Tuple<Bitmap, List<Bucket>> Quantize(Bitmap bitmap, int colourCount)
        public static Tuple<Bitmap, List<string>> Quantize(Bitmap bitmap, int colourCount)
        {
            var colours = Enumerable.Range(0, bitmap.Height)
                .SelectMany(y => Enumerable.Range(0, bitmap.Width)
                    .Select(x => bitmap.GetPixel(x, y)));
            var buckets = new List<Bucket> { new Bucket(colours) };

            while (buckets.Count < colourCount)
            {
                var newBuckets = new List<Bucket>();
                for (var i = 0; i < buckets.Count; i++)
                {
                    if (newBuckets.Count + (buckets.Count - i) < colourCount)
                    {
                        var split = buckets[i].Split();
                        newBuckets.Add(split.Item1);
                        newBuckets.Add(split.Item2);
                    }
                    else
                    {
                        newBuckets.AddRange(buckets.GetRange(i, buckets.Count - i));
                        break;
                    }
                }
                buckets = newBuckets;
            }

            var ret = new Bitmap(bitmap.Width, bitmap.Height);
            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    var bucket = buckets.First(b => b.HasColour(bitmap.GetPixel(x, y)));
                    ret.SetPixel(x, y, bucket.Colour);
                }
            }

            // 
            var list = new List<string>();
            //var aaaa = buckets;
            foreach (var bucket in buckets)
            {
                var hex = GetHexFromColor(bucket.Colour);
                list.Add(hex);
            }
            //string listasstring = buckets.ToString();
            
            return new Tuple<Bitmap, List<string>>(ret, list);
            //return ret;
        }

        public class Bucket
        {
            public readonly IDictionary<Color, int> colours;

            public Color Colour { get; }

            public Bucket(IEnumerable<Color> colours)
            {
                this.colours = colours.ToLookup(c => c)
                    .ToDictionary(c => c.Key, c => c.Count());
                this.Colour = Average(this.colours);
            }

            public Bucket(IEnumerable<KeyValuePair<Color, int>> enumerable)
            {
                this.colours = enumerable.ToDictionary(c => c.Key, c => c.Value);
                this.Colour = Average(this.colours);
            }

            private static Color Average(IEnumerable<KeyValuePair<Color, int>> colours)
            {
                var totals = colours.Sum(c => c.Value);
                return Color.FromArgb(
                    alpha: 255,
                    red: colours.Sum(c => c.Key.R * c.Value) / totals,
                    green: colours.Sum(c => c.Key.G * c.Value) / totals,
                    blue: colours.Sum(c => c.Key.B * c.Value) / totals);
            }

            public bool HasColour(Color colour)
            {
                return colours.ContainsKey(colour);
            }

            public Tuple<Bucket, Bucket> Split()
            {
                var redRange = colours.Keys.Max(c => c.R) - colours.Keys.Min(c => c.R);
                var greenRange = colours.Keys.Max(c => c.G) - colours.Keys.Min(c => c.G);
                var blueRange = colours.Keys.Max(c => c.B) - colours.Keys.Min(c => c.B);

                Func<Color, int> sorter;
                if (redRange > greenRange)
                {
                    if (redRange > blueRange)
                    {
                        sorter = c => c.R;
                    }
                    else
                    {
                        sorter = c => c.B;
                    }
                }
                else
                {
                    if (greenRange > blueRange)
                    {
                        sorter = c => c.G;
                    }
                    else
                    {
                        sorter = c => c.B;
                    }
                }

                var sorted = colours.OrderBy(c => sorter(c.Key));

                var firstBucketCount = sorted.Count() / 2;

                var bucket1 = new Bucket(sorted.Take(firstBucketCount));
                var bucket2 = new Bucket(sorted.Skip(firstBucketCount));
                return new Tuple<Bucket, Bucket>(bucket1, bucket2);
            }
        }

        //public static string GetTodoColor(string todotype)
        //{
        //    var color = "#555555";
        //    if (todotype == "todo") { color = "#555555"; }
        //    if (todotype == "hygiene") { color = "#5b165b"; }
        //    if (todotype == "meeting") { color = "#ffff00"; }
        //    //if (todotype == "training") { color = "#5b165b"; }
        //    if (todotype == "training") { color = "#165b5b"; }
        //    if (todotype == "important") { color = "#ff0000"; }
        //    if (todotype == "book") { color = "#ae00ff"; }
        //    return color;
        //}

        public static List<string> GetListOfTodoTypes()
        {
            var list = new List<string> { "todobig", "meeting", "training", "hygiene", "important", "book", "todo" };
            return list;
        }
        public static string GetTodoColor(string todotype)
        {
            var color = "";
            switch (todotype)
            {
                case "todobig":
                    color = "#bb88cc";
                    break;
                case "todo":
                    color = "#555555";
                    break;
                case "hygiene":
                    color = "#5b165b";
                    break;
                case "meeting":
                    color = "#ffff00";
                    break;
                case "training":
                    color = "#165b5b";
                    break;
                case "important":
                    color = "#ff0000";
                    break;
                case "book":
                    color = "#ae00ff";
                    break;
                default:
                    color = "#555555";
                    break;
            }
            return color;
        }
    }
}