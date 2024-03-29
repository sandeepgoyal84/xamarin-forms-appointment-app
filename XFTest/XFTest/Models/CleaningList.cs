﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace XFTest.Models
{
    public class CleaningList : BaseModel
    {
        private string _address;
        private string _name;
        public string Name
        {
            get
            {
                _name = string.Format("{0} {1}", OwnerFirstName, OwnerLastName).Trim();
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

        public double Distance { get; set; }

        [JsonProperty("homeBobEmployeeId")]
        public string EmployeeId { get; set; }

        [JsonProperty("endTimeUtc")]
        public DateTime EndTimeUtc { get; set; }

        [JsonProperty("expectedTime")]
        public string ExpectedTime { get; set; }

        [JsonProperty("houseOwnerAddress")]
        public string OwnerAddress { get; set; }

        [JsonProperty("houseOwnerCity")]
        public string OwnerCity { get; set; }

        [JsonProperty("houseOwnerFirstName")]
        public string OwnerFirstName { get; set; }

        [JsonProperty("houseOwnerId")]
        public string OwnerId { get; set; }

        [JsonProperty("houseOwnerLastName")]
        public string OwnerLastName { get; set; }

        [JsonProperty("houseOwnerLatitude")]
        public double OwnerLatitude { get; set; }

        [JsonProperty("houseOwnerLongitude")]
        public double OwnerLongitude { get; set; }

        [JsonProperty("houseOwnerZip")]
        public string OwnerZip { get; set; }

        [JsonProperty("startTimeUtc")]
        public DateTime StartTimeUtc { get; set; }

        [JsonProperty("tasks")]
        public IEnumerable<CleaningTask> TaskList { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("visitId")]
        public string VisitId { get; set; }
        [JsonProperty("visitState")]
        public string VisitState { get; set; }
        public string VisitStateColor
        {
            get
            {
                switch (VisitState.ToLower())
                {
                    case "todo": return "#4E77D6";
                    case "inprogress": return "#F5C709";
                    case "done": return "#25A87B";
                    case "rejected": return "#EF6565";
                }
                return "#EF6565";
            }
        }
    }
}