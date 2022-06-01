using System;
using System.Collections.Generic;
using System.Text;

namespace ARSAPI.DAL.AdminDB.Models
{
    public class SearchOutput
    {
       
        public DateTime StartDate { get; set; }
        public string AirlineName { get; set; }
        public decimal TicketCost { get; set; }
        public string FlightNo { get; set; }
       
    }
    public class TripDetails
    {
        public List<SearchOutput> Onetrip { get; set; }
        public List<SearchOutput> Roundtrip { get; set; }
    }

}
