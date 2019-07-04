using System.Linq;

namespace BookCarProjectMaster.Models
{
    public class CartItem
    {
        DbBookCarContext db = new DbBookCarContext();

        public int id { get; set; }
        public string tenXe { get; set; }
        public decimal giaThue { get; set; }

        public CartItem(int idCar)
        {
            id = idCar;
            CarProduct carProduct = db.CarProducts.Single(n => n.CarProductsId == id);
            tenXe = carProduct.ModelCar;
            giaThue = decimal.Parse(carProduct.RentCost.ToString());
        }
    }
}