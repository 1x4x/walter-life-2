using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1w4w.CMS.Manager
{
    public class JTokenManager
    {
        public static T[] JTokenToArray<T>(JToken jToken)
        {
            List<T> ret = new List<T>();
            foreach (JToken jItem in jToken)
                ret.Add(jItem.Value<T>());
            return ret.ToArray();
        }
        // usage:
        // string[] brands = JTokenToArray<string>(jObject.Value<JToken>("brands"));
    }
}