using System;

namespace AasxDemonstration
{
    public class CarbonIntensityQueryResult
    {
        public CarbonData[] data { get; set; }
    }

    public class CarbonData
    {
        public DateTime from { get; set; }

        public DateTime to { get; set; }

        public CarbonIntensity intensity { get; set; }
    }

    public class CarbonIntensity
    {
        public int forecast { get; set; }

        public int actual { get; set; }

        public string index { get; set; }
    }
}