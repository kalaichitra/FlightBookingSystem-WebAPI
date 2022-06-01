using System;
using System.Collections.Generic;

namespace ARSAPI.DAL.Model
{
    public partial class AirlineRegDetails
    {
        public int AirlineId { get; set; }
        public string AirlineName { get; set; }
        public string ContactAddress { get; set; }
        public string ContactNo { get; set; }
        public bool IsActive { get; set; }
    }
}
