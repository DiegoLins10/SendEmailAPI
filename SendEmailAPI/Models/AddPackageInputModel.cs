using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SendEmailAPI.Models
{
    public class AddPackageInputModel
    {
        public string Title { get; set; }
        public decimal Weight { get; set; }
    }
}
