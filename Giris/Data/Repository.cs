using Giris.Models;

namespace Giris.Data;

public  class Repository
{

    public static List<Product> Products = new List<Product>
    {

        // Kullanıcı : Dyson Süpürge   -> Dyson Süpürge (==)
        // Kullanıcı : Dy  -> Dyson Süpürge 1, Dyson Süpürge (Contains)
        // Kullanıcı : dY -> 
        new Product{Id=1, Name="Dyson Süpürge",CategoryName="Ev Aletleri",Price=25000,Stock=123},
        new Product{Id=2,Name="Philips Süpürge",CategoryName="Ev Aletleri",Price=15000,Stock=25},
        new Product{Id=3,Name="Arçelik Süpürge",CategoryName="Ev Aletleri",Price=5000,Stock=63},
        new Product{Id=7,Name="Arçelik Süpürge 3",CategoryName="Ev Aletleri",Price=3250,Stock=15},
        new Product{Id=4, Name="Dyson Süpürge 1",CategoryName="Ev Aletleri",Price=15000,Stock=20},
        new Product{Id=5,Name="Philips Süpürge 1",CategoryName="Ev Aletleri",Price=25000,Stock=250},
        new Product{Id=6,Name="Arçelik Süpürge 1",CategoryName="Ev Aletleri",Price=8000,Stock=163}
    };
}
