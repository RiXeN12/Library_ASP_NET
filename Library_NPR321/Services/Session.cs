using System.Text.Json;

namespace Library_NPR321.Services
{
    public static class Session
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            string json = JsonSerializer.Serialize(value);
            session.SetString(key, json);
        }

        public static T? Get<T>(this ISession session, string key)
        {
            string value = session.GetString(key);

            if (value == null)
            {
                return default;
            }

            T? res = JsonSerializer.Deserialize<T>(value);
            return res;
        }
    }
}
