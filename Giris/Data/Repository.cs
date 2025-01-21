using Giris.Models;

namespace Giris.Data;

public  class Repository
{

    public static List<Product> Products = new List<Product>
    {
        new Product{Name="Dyson Süpürge",CategoryName="Ev Aletleri",Price=25000,Stock=123},
        new Product{Name="Philips Süpürge",CategoryName="Ev Aletleri",Price=15000,Stock=25},
        new Product{Name="Arçelik Süpürge",CategoryName="Ev Aletleri",Price=5000,Stock=63},
    };
}
