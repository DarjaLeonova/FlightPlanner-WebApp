using System.Collections.Generic;

namespace FlightPlanner_WebApp
{
    public class SearchFlightResult
    {
        public List<string> Items { get; set; }
        public int Page { get; set; }
        public int TotalItems { get; set; }

        public SearchFlightResult() 
        {
            Items = new List<string>();
        }

        public SearchFlightResult(List<string> items, int page, int totalItems)
        {
            Items = new List<string>(items);
            Page = page;
            TotalItems = totalItems;
        }
    }
}
