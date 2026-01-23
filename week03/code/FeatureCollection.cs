public class FeatureCollection
{
    public string Type { get; set; }
    public Feature[] Features { get; set; }

}

public class Feature
{
    public string Id { get; set; }
    public Properties Properties { get; set; }
    public Geometry Geometry { get; set; }
}

public class Properties
{
    public double? Mag { get; set; }
    public string Place { get; set; }
    public long? Time { get; set; }
    public long? Updated { get; set; }
    public int? Tz { get; set; } 
    public string MagType { get; set; }
}

public class Geometry
{
    public string Type { get; set; }
    public decimal?[] Coordinates { get; set; }
}