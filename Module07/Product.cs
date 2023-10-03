using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module07
{
    /// <summary>
    /// Класс товаров
    /// </summary>
    class Product
    {
        internal string name; //Название товара
        internal string vendorName; //Название производителя
        internal string article; //Артикул товара по проиводителю. Если отсутствует просваиваем свой внутренний
        internal decimal price; //Цена за единицу товара (штуку/веса)
        internal double quantity; //Количество доступных товаров на складе (0 - товар недоступен, резерв на будущее на даннй момент не реализую.
                                  //double - потому что если товар не штучный, то его количество не обязательно целое число)
        internal double weight; //Вес единицы товара (чтобы пружины у курьера не лопнули)

        public Product(string Name, string VendorName, string Article, decimal Price, double Quantity, double Weight)
        {
            name = Name;
            vendorName = VendorName;
            article = Article;
            price = Price;
            quantity = Quantity;
            weight = Weight;
        }
    }
}

