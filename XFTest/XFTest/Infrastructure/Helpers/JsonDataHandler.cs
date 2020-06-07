using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace XFTest.Infrastructure.Helpers
{
    public class JsonDataHandler
    {
        private string _jsonData;

        public JsonDataHandler()
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(JsonDataHandler)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("XFTest.DummyData.json");
            using (var reader = new System.IO.StreamReader(stream))
            {
                _jsonData = reader.ReadToEnd();
            }
        }

        public async Task<ServiceResponse<T>> RetrieveData<T>(DateTime cleanListDate)
        {
            var serviceResponse = new ServiceResponse<T>();
            try
            {
                var response = await Task.Run(() => { return JObject.Parse(_jsonData); });
                if ((bool)response["success"])
                {
                    serviceResponse.Result = JsonConvert.DeserializeObject<T>(response["data"].ToString());
                }
                serviceResponse.IsSuccess = (bool)response["success"];
                serviceResponse.ResponseCode = (string)response["message"];
            }
            catch (Exception ex)
            {
                serviceResponse.Exception = ex;
            }

            return serviceResponse;
        }
    }
}