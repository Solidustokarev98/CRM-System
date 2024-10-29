using System.Text.Json;

namespace CRM_System.Infrastructure
{
    public static class SessionExtensions
    {
        public static void SetJson(this ISession session, string key, object value)
        {
            var valueSerialized = JsonSerializer.Serialize(value);
            session.SetString(key, valueSerialized);
        }

        public static T GetJson<T>(this ISession session, string key) where T : class, new()
        {
            var sessionData = session.GetString(key);

            if (sessionData is null)
            {
                return new T();
            }

            var r = JsonSerializer.Deserialize<T>(sessionData);

            return JsonSerializer.Deserialize<T>(sessionData) ?? new T();
        }
    }
}
