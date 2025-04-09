public class Product 
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public bool Sold { get; set; }
    public DateTime DayStocked { get; set; }
    public TimeSpan DaysOnShelf { get
    {
        TimeSpan Days = DateTime.Now - DayStocked;
        return Days;
    }}
    public int ProductTypeId { get; set;}

}

public class ProductType
{
    public string Name { get; set; }
    public int Id { get; set; }
}