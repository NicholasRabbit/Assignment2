namespace LiveStockManagement;

public class LiveStock 
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public double Expnese { get; set; }
    public double Weight { get; set; }
    public string? Colour { get; set; }

}

[Table("Cow")]
public class Cow : LiveStock
{
    public double Milk { get; set; }
}

[Table("Sheep")]
public class Sheep : LiveStock
{
    public double Wool { get; set; }
}


