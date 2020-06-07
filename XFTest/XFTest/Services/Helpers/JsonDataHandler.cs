using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace XFTest.Services.Helpers
{
    public class JsonDataHandler
    {
        static string _jsonData;

        static JsonDataHandler()
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(JsonDataHandler)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("XFTest.DummyData.json");
            using (var reader = new System.IO.StreamReader(stream))
            {
                _jsonData = reader.ReadToEnd();
            }
        }

        public static async Task<ServiceResponse<T>> RetrieveData<T>(DateTime cleanListDate)
        {
            var serviceResponse = new ServiceResponse<T>();
            try
            {
                var response = await Task.Run(() => { return JObject.Parse(_jsonData); });
                if ((bool)response["success"])
                {
                    var srchItems = ((JArray)response["data"]).SelectTokens("$.[?(@.taskDate=='" + cleanListDate.ToString("yyyy-MM-dd") + "')]");
                    StringBuilder sb = new StringBuilder("[");
                    bool shoulRemove = false;
                    foreach (var item in srchItems)
                    {
                        sb.Append(item.ToString());
                        sb.Append(",");
                        shoulRemove = true;
                    }
                    if (shoulRemove) { sb.Remove(sb.Length - 1, 1); }
                    sb.Append("]");
                    serviceResponse.Result = JsonConvert.DeserializeObject<T>(sb.ToString());
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