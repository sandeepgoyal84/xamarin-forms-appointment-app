using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
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

            //var jsonFileName="DummyData.json";
            //var assembly = typeof(MainPage).GetTypeInfo().Assembly;
            //Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{jsonFileName}");
            //using (var reader = new System.IO.StreamReader(stream))
            //{
            //    _jsonData = reader.ReadToEnd();

            //    //Converting JSON Array Objects into generic list    
            //    //ObjContactList = JsonConvert.DeserializeObject<ContactList>(jsonString);
            //}
            //_jsonData = JObject.Parse(File.ReadAllText(path));
        }

        public async Task<ServiceResponse<T>> RetrieveData<T>()
        {
            var serviceResponse = new ServiceResponse<T>();
            try
                {
                    var response = await Task.Run(() => { return JObject.Parse(_jsonData); });
                    if ((bool)response["success"])
                    {
                        var content = response["data"].ToString();
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
