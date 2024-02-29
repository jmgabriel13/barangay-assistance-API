using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Services.Helpers.Utility
{
    public static class Common
    {
        public static string Serialize<T>(this IList<T> list) => JsonConvert.SerializeObject(list);

        public static string Serialize<T>(this T data) => JsonConvert.SerializeObject(data);
    }
}