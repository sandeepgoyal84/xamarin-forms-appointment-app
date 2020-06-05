using Newtonsoft.Json;

namespace XFTest.Models
{
    public class CleaningTask: BaseModel
    {

        [JsonProperty("taskId")]
        public string VisitId { get; set; }

        [JsonProperty("title")]
        public string EmployeeId { get; set; }

        [JsonProperty("timesInMinutes")]
        public int TimesInMinutes { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }
    }

}