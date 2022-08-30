﻿using System;
using System.Collections.Generic;

namespace SendEmailAPI.Entities
{
    public class Package
    {
        public int Id { get; private set; }
        public string Code { get; private set; }
        public string Title { get; private set; }
        public decimal Weight { get; private set; }
        public bool Delivered { get; private set; }
        public DateTime PostedAt { get; private set; }
        public List<PackageUpdate> Updates { get; private set; }

        public Package(string title, decimal weight)
        {
            Code = Guid.NewGuid().ToString();
            Title = title;
            Weight = weight;
            Delivered = false;
            PostedAt = DateTime.Now;
            Updates = new List<PackageUpdate>();

        }
    }
}