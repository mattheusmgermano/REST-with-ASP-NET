﻿using REST_with_ASP_NET.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace REST_with_ASP_NET.Model
{
    [Table("person")]
    public class Person : BaseEntity
    {
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("address")]
        public string Address { get; set; }
        [Column("gender")]
        public string Gender { get; set; }
    }
}
