﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTask.Core.Domain
{
    public class WorkTopic
    {
        [Key]
        public int Id { get; set; }

        public string description { get; set; }
    }

}
