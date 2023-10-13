﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Models
{
    public class Client
    {
        public Guid RecordId { get; set; }
        public string ClientName { get; set; }
        public DateTime DateRegisterd { get; set; }
        public string Location { get; set; }
        public int NumberOfSystemUsers { get; set; }
    }
}