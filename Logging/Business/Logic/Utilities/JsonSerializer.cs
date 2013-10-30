using Newtonsoft.Json;

namespace Whatsnexx.Logging.Utilities
{
    public static class JsonSerializer
    {
        public static T DeserializeObject<T>(string jsonString)
        {
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        public static T DeserializeObject<T>(string jsonString, bool serializeObject)
        {
            return serializeObject ? JsonConvert.DeserializeObject<T>(jsonString, new JsonSerializerSettings {TypeNameHandling = TypeNameHandling.Objects}) : DeserializeObject<T>(jsonString);
        }

        public static string SerializeObject(object entity)
        {
            return JsonConvert.SerializeObject(entity);
        }

        public static string SerializeObject(object obj, bool serializeAsObject, bool normalizeResult)
        {
            return normalizeResult
                ? SerializeObject(obj, serializeAsObject).Replace("\"{", "{").Replace("}\"", "}").Replace("\\", "").Replace("\"[", "[").Replace("]\"", "]")
                : SerializeObject(obj, serializeAsObject);
        }

        public static string SerializeObject(object obj, bool serializeAsObject)
        {
            return serializeAsObject
                ? JsonConvert.SerializeObject(obj, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto })
                : SerializeObject(obj);
        }
    }
}
