﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTask.Core.Domain
{
    public class Access
    {
        [Key]
        public int Id { get; set; }

        public string description { get; set; }
    }

}
