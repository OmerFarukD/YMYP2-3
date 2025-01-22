namespace Giris.Models;

public sealed class Product
{

    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; } 

    public string CategoryName { get; set; } 


    public Product()
    {
        Name = string.Empty;
        CategoryName = string.Empty;
    }

    // stringler değer tip gibi çalışan referans tipleridr.
}

