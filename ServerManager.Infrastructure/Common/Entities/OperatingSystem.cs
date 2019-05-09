using System.Collections.Generic;

namespace ServerManager.Infastructure.Common.Entities
{
    public class OperatingSystem
    {
        public string Id { get; set; }

        public string Slug { get; set; }

        public string Name { get; set; }

        public string Distro { get; set; }

        public string Version { get; set; }
        
        public bool Preinstallable { get; set; }

        public Pricing Pricing { get; set; }

        public bool Licensed { get; set; }
    }

    public class Pricing
    {
        public Hour Hour { get; set; }
    }

    public class Hour
    {
        public double Price { get; set; }

        public string Multiplier { get; set; }
    }
}