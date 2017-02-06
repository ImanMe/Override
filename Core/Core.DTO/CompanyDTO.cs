using System.Collections.Generic;

namespace Core.DTO
{
    public class CompanyDTO
    {
        public int CompanyID { get; set; }
        public string Name { get; set; }
        public string DBA { get; set; }
        public string TaxNumber { get; set; }
        public string EffectiveFrom { get; set; }
        public string EffectiveTo { get; set; }
        public IEnumerable<CompanyLocationDTO> CompanyLocations { get; set; }
    }
}
