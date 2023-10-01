using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module07
{
    enum Category
    {

    }

    /// <summary>
    /// Класс товаров
    /// </summary>
    class Product
    {
        //private int id; //ID товара в БД
        internal string name; //Название товара
        //internal int idVendor; //ID производителя товара
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

        /// <summary>
        /// Выбор ID вендора из БД
        /// </summary>
        /// <param name="VendorName">Имя вендора</param>
        /// <returns></returns>
        static internal int GetVendorIDByName(in string VendorName)
        {
            //Заглушка
            switch (VendorName.ToUpper())
            {
                case "IBM":
                    return 0;
                case "HP":
                    return 1;
                case "DELL":
                    return 2;
                case "MIKROTIK":
                    return 3;
                case "CISCO":
                    return 4;
                case "SUPERMICRO":
                    return 5;
                default:
                    return -1;
            }
        }

        static private string GetVendorNameByID(int ID)
        {
            //Заглушка
            switch (ID)
            {
                case 0:
                    return "IBM";
                case 1:
                    return "HP";
                case 2:
                    return "DELL";
                case 3:
                    return "MikroTik";
                case 4:
                    return "Cisco";
                case 5:
                    return "SuperMicro";
                default:
                   return "NOTFound";
            }
        }
    }
}

