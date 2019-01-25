using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FileCDN.Models
{
    public static class CdnServiceHelper
    {
        public static string cdnUrl = "";
        public static class Methods
        {
            public const string Upload = "upload";
            public const string Select = "select";
            public const string Disable = "disable";
            public const string Download = "download";
        }

        public static async Task<Tresult> CallMethod<Tresult, Trequest>(Trequest model, string method)
        {
            Tresult returnValue = default(Tresult);
            var methodUrl = string.Empty;
            try
            {
                using (var client = new HttpClient())
                {
                    methodUrl = cdnUrl + "/" + method;
                    client.BaseAddress = new Uri(methodUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var requestContent = new JsonContent(model);
                    HttpResponseMessage response = await client.PostAsync(client.BaseAddress, requestContent);
                    response.EnsureSuccessStatusCode();
                    returnValue = JsonConvert.DeserializeObject<Tresult>(response.Content.ReadAsStringAsync().Result);
                }
                return returnValue;
            }
            catch (Exception e)
            {
                // ErrorHelper.WriteToLog("CoreCDNService/CallCDNmethod url:" + methodUrl, e);
                throw (e);
            }
        }

        private class JsonContent : StringContent
        {
            public JsonContent(object obj) :
                base(JsonConvert.SerializeObject(obj), System.Text.Encoding.UTF8, "application/json")
            { }
        }
    }
}
