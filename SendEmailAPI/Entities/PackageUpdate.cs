using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SendEmailAPI.Entities
{
    public class PackageUpdate
    {
        public int Id { get; private set; }
        public int PackageId { get; private set; }
        public string Status { get; private set; }
        public DateTime UpdateDate { get; private set; }

        public PackageUpdate(string status, int packageId)
        {
            Status = status;
            UpdateDate = DateTime.Now;
            PackageId = packageId;
        }

    }
}
