using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace XFTest.Models
{
    public class CleaningList
    {
        private string _name;
        private string _address;
        public string Name
        {
            get
            {
                _name= string.Format("{0} {1}", OwnerFirstName, OwnerLastName).Trim();
                return _name;
            }
        }
        public string Address
        {
            get
            {
                _address = string.Format("{0} {1} {2}", OwnerAddress, OwnerZip, OwnerCity).Trim();
                return _address;
            }
        }

        [JsonProperty("visitId")]
        public string VisitId { get; set; }

        [JsonProperty("homeBobEmployeeId")]
        public string EmployeeId { get; set; }

        [JsonProperty("houseOwnerId")]
        public string OwnerId { get; set; }

        [JsonProperty("startTimeUtc")]
        public DateTime StartTimeUtc { get; set; }

        [JsonProperty("endTimeUtc")]
        public DateTime EndTimeUtc { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("houseOwnerFirstName")]
        public string OwnerFirstName { get; set; }

        [JsonProperty("houseOwnerLastName")]
        public string OwnerLastName { get; set; }

        [JsonProperty("houseOwnerAddress")]
        public string OwnerAddress { get; set; }

        [JsonProperty("houseOwnerZip")]
        public string OwnerZip { get; set; }

        [JsonProperty("houseOwnerCity")]
        public string OwnerCity { get; set; }

        [JsonProperty("houseOwnerLatitude")]
        public long OwnerLatitude { get; set; }

        [JsonProperty("houseOwnerLongitude")]
        public long OwnerLongitude { get; set; }

        [JsonProperty("visitState")]
        public string VisitState { get; set; }

        [JsonProperty("expectedTime")]
        public string ExpectedTime { get; set; }

        [JsonProperty("tasks")]
        public IEnumerable<CleaningTask> TaskList { get; set; }

    }

}
//{
//            "visitId": "799d7830-a5ff-4a0b-b571-9052df6a2e64",
//            "homeBobEmployeeId": "85f99bd7-ffd2-4ca7-1174-08d7984a4cf3",
//            "houseOwnerId": "4ad40a8b-8c55-45a3-9b81-b87527f5cf93",
//            "isBlocked": false,
//            "startTimeUtc": "2020-04-29T08:05:00",
//            "endTimeUtc": "2020-04-29T08:35:00",
//            "title": "Add title",
//            "isReviewed": false,
//            "isFirstVisit": false,
//            "isManual": false,
//            "visitTimeUsed": 0,
//            "rememberToday": null,
//            "houseOwnerFirstName": "Tone",
//            "houseOwnerLastName": "Holtermann",
//            "houseOwnerMobilePhone": "+4520934021",
//            "houseOwnerAddress": "Akademivej 15, 1 th",
//            "houseOwnerZip": "2800",
//            "houseOwnerCity": "Kgs. Lyngby",
//            "houseOwnerLatitude": 55.778830,
//            "houseOwnerLongitude": 12.521240,
//            "isSubscriber": false,
//            "rememberAlways": null,
//            "professional": "Test",
//            "visitState": "Done",
//            "stateOrder": 1,
//            "expectedTime": "08:00/10:00",
//            "tasks": [
//                {
//                    "taskId": "e4131f30-6beb-45aa-9fcf-02758f332219",
//                    "title": "Pudsning indvendig",
//                    "isTemplate": false,
//                    "timesInMinutes": 25,
//                    "price": 99.00,
//                    "paymentTypeId": "51d14bdf-8d83-49fa-843d-787ceba4bb40",
//                    "createDateUtc": "2020-04-29T20:01:56.8831511",
//                    "lastUpdateDateUtc": "2020-04-29T20:01:56.8831539",
//                    "paymentTypes": null
//                },
//                {
//                    "taskId": "56ed0718-2854-4b11-8fde-8a3c573c9283",
//                    "title": "Pudsning udvendig",
//                    "isTemplate": false,
//                    "timesInMinutes": 35,
//                    "price": 199.00,
//                    "paymentTypeId": "9f40509b-191d-4c61-946e-0e816b63088d",
//                    "createDateUtc": "2020-04-29T20:01:26.2182451",
//                    "lastUpdateDateUtc": "2020-04-29T20:01:26.2182775",
//                    "paymentTypes": null
//                }
//            ],
//            "houseOwnerAssets": [],
//            "visitAssets": [],
//            "visitMessages": []
//        },