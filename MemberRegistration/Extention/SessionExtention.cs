using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace MemberRegistration.Extention
{
    public static class SessionExtention 

    {
        //set i extend edeceğiz
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value)); //objeyi veririz Json stringe dönüştürür.
        }
        // ne gönderdiysem geri dönüşü o objeden almalı 
        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value); //get ile bu ifadeyi okuyoruz.Object olan value ifadeyi stringe döndürdük.
        }
    }
}
