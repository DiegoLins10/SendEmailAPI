using SendEmailAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SendEmailAPI.Persistence
{
    public class EmailContext
    {
        public List<Package> Packages { get; set; }

        public EmailContext()
        {
            Packages = new List<Package>();
        }
    }
}
