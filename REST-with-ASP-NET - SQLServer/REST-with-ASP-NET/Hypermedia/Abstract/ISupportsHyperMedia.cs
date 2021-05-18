using System.Collections.Generic;

namespace REST_with_ASP_NET.Hypermedia.Abstract
{
    public interface ISupportsHyperMedia
    {
        List<HyperMediaLink> Links { get; set; }
    }
}
