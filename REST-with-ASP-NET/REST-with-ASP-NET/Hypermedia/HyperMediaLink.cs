using System.Text;

namespace REST_with_ASP_NET.Hypermedia
{
    public class HyperMediaLink
    {
        public string Rel { get; set; }
        private string href;
        public string Type {
            get
            {
                object _lock = new object();
                lock (_lock)
                {
                    StringBuilder sb = new StringBuilder(href);
                    return sb.Replace("%2f", "/").ToString();
                }
            }
            set 
            {
                href = value;    
            } 
        }
        public string Action { get; set; }
        public string Href { get; internal set; }
    }
}
