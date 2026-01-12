using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto
{
    public class AccuCityCodeRootDTO
    {
        public int Version { get; set; }
        public string Key { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int Rank { get; set; }
        public string LocalizedName { get; set; } = string.Empty;
        public string EnglishName { get; set; } = string.Empty;
        public string PrimaryPostalCode { get; set; } = string.Empty;
        public Region? Region { get; set; }
        public AdministrativeArea? AdminstriveArea { get; set; }
        public TimeZone TimeZone { get; set; }
        public GeoPosition? GeoPosition { get; set; }
        public bool IsAlias { get; set; }
        public SupplementalAdminArea[]? SupplmentalAdminAreas { get; set; }
        public string[]? DataSets { get; set; }
    }
    public class Region
    {
        public string Id { get; set; } = string.Empty;
        public string LocalizedName { get; set; } = string.Empty;
        public string EnglishName { get; set; } = string.Empty;

    }
    public class Country
    {
        public string Id { get; set; } = string.Empty;
        public string LocalizedName { get; set; } = string.Empty;
        public string EnglishName { get; set; } = string.Empty;
    }
    public class AdministrativeArea
    {
        public string Id { get; set; } = string.Empty;
        public string LocalizedName { get; set; } = string.Empty;
        public string EnglishName { get; set; } = string.Empty;
        public int Level { get; set; }
        public string LocalizedType { get; set; } = string.Empty;
        public string EnglishType { get; set; } = string.Empty;
        public string CountryId { get; set; } = string.Empty;
    }
    public class TimeZone
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public double GetOffset { get; set; }
        public bool IsDaylightSavingTime { get; set; }
        public DateTime? NextOffSetChange { get; set; }
    }
    public class GeoPosition
    {
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public Elevation? Elevation { get; set; }
    }
    public class Elevation
    {
        public Metric? Metric { get; set; }
        public Imperial? Imperial { get; set; }
    }
    public class Metric
    {
        public double Value { get; set; }
        public string Unit { get; set; } = string.Empty;
        public int UnitType { get; set; }
    }
    public class Imperial
    {

        public double Value { get; set; }
        public string Unit { get; set; } = string.Empty;
        public int UnitType { get; set; }
    }
    public class SupplementalAdminArea
    {
        public string Level { get; set; } = string.Empty ;
        public string LocalizedName { get; set; } = string.Empty;
        public string EnglishName { get; set; } = string.Empty;
    }
}
