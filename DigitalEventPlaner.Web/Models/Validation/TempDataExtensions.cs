using System;
namespace DigitalEventPlaner.Web.Models.Validation
{
    public static class TempDataExtensions
    {
        public static void Put<T>(this Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionary tempData, string key, T value) where T : class
        {
            tempData[key] = Newtonsoft.Json.JsonConvert.SerializeObject(value);
        }

        public static T Get<T>(this Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionary tempData, string key) where T : class
        {
            object o;
            tempData.TryGetValue(key, out o);
            return o == null ? null : Newtonsoft.Json.JsonConvert.DeserializeObject<T>((string)o);
        }
    }
}
