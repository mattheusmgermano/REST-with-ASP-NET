using REST_with_ASP_NET.Hypermedia.Abstract;
using System.Collections.Generic;

namespace REST_with_ASP_NET.Hypermedia.Filters
{
    public class HyperMediaFilterOptions
    {
        public List<IResponseEnricher> ContentResponseEnricherList { get; set; } = new List<IResponseEnricher>();
    }
}
