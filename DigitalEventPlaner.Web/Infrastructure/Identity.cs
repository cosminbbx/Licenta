using System;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace DigitalEventPlaner.Web.Infrastructure
{
    public static class Identity
    {
        public static Web.Infrastructure.UserIdentity User(this ISession session) { return GetUser(session); }

        public const string UserKey = "CurrentUser";

        public static void SetUser(this ISession session, UserIdentity user)
        {
            session.SetString(UserKey, JsonConvert.SerializeObject(user));
        }

        public static UserIdentity GetUser(this ISession session)
        {
            var value = session.GetString(UserKey);
            return value == null ? default(UserIdentity) : JsonConvert.DeserializeObject<UserIdentity>(value);
        }

        public static void ClearUserSession(this ISession session)
        {
            session.Remove(UserKey);
        }
    }
}
