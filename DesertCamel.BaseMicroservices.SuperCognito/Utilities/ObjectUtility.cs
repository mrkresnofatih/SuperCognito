using Newtonsoft.Json;
using System.Reflection;

namespace DesertCamel.BaseMicroservices.SuperCognito.Utilities
{
    public static class ObjectUtility
    {
        public static Dictionary<string, string> ToStringDictionary<T>(this T data)
        {
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(data.ToJson());
        }
    }
}
