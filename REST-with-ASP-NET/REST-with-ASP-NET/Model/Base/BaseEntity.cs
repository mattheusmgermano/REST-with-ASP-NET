using System.ComponentModel.DataAnnotations.Schema;


namespace REST_with_ASP_NET.Model.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }
    }
}
