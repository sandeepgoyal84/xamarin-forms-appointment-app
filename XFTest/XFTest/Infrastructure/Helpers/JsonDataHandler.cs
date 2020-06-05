using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace XFTest.Infrastructure.Helpers
{
    static public class JsonDataHandler
    {
        static JObject _jsonData;
        static JsonDataHandler()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "\\XF-Test-Json.json");
            _jsonData = JObject.Parse(File.ReadAllText(path));
        }

        static public async Task<ServiceResponse<T>> RetrieveData<T>()
        {
            var serviceResponse = new ServiceResponse<T>();
            try
                {
                    var response = await Task.Run(() => { return _jsonData; });
                    if ((bool)response["success"])
                    {
                        var content = (string)response["data"];
                        serviceResponse.Result = JsonConvert.DeserializeObject<T>(content);
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
