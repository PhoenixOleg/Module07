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
    class Products
    {
        private int id; //ID товара в БД
        private string name; //Название товара
        private int idVendor; //ID производителя товара
        private string vendorName; //Название производителя
        private string article; //Артикул товара по проиводителю. Если отсутствует просваиваем свой внутренний
        private double price; //Цена за единицу товара (штуку/веса)
        private double quantity; //Количество доступных товаров на складе (0 - товар недоступен, резерв на будущее на даннй момент не реализую.
                                 //double - потому что если товар не штучный, то его количество не обязательно целое число)
        private double weight; //Вес единицы товара (чтобы пружины у курьера не лопнули)

        public Products(string Name, string VendorName, string Article, double Price, double Quantity, double Weight)
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

        /// <summary>
        /// Выбор товара из БД (для упрощения во всех перегрузках считаем, что выбирается один товар SELECT TOP 1)
        /// </summary>
        /// <param name="Article">артикул</param>
        /// <param name="item">кортеж с характеристиками товара</param>
        /// <returns></returns>
        static internal bool GetProduct(in string Article, out (string name, string vendorName, string article, double price, double quantity, double weight, int idProduct, int idVendor) item)
        {
            //Заглушка            
            switch (Article.ToUpper())
            {
                case "5462E6G":
                    item.name = "IBM System x3650 M5";
                    item.article = Article;
                    item.price = 98880;
                    item.quantity = 20;
                    item.weight = 23;
                    item.idProduct = 1;
                    item.idVendor = 0;
                    item.vendorName = GetVendorNameByID(item.idVendor);
                    return true;
                case "3573-L4U-2FCLTO4":
                    item.name = "TS3200";
                    item.article = Article;
                    item.price = 517230;
                    item.quantity = 3;
                    item.weight = 21.3;
                    item.idProduct = 2;
                    item.idVendor = 0;
                    item.vendorName = GetVendorNameByID(item.idVendor);
                    return true;
                case "AJ822C":
                    item.name = "HPE Brocade SAN AJ822C";
                    item.article = Article;
                    item.price = 942760;
                    item.quantity = 7;
                    item.weight = 1.81;
                    item.idProduct = 3;
                    item.idVendor = 1;
                    item.vendorName = GetVendorNameByID(item.idVendor);
                    return true;
                default:
                    item.name = "NOTFound";
                    item.article = "";
                    item.price = 0;
                    item.quantity = 0;
                    item.weight = 0;
                    item.idProduct = -1;
                    item.idVendor = -1;
                    item.vendorName = GetVendorNameByID(item.idVendor);
                    return false;
            }
        }

        static internal bool  GetProduct(string Name, out (string name, string vendorName, string article, double price, double quantity, double weight, int idProduct, int idVendor) item)
        {
            switch (Name.ToUpper())
            {
                //Заглушка
                case "IBM SYSTEM X3650 M5":
                    item.name = Name;
                    item.article = "5462E6G";
                    item.price = 98880;
                    item.quantity = 20;
                    item.weight = 23;
                    item.idProduct = 1;
                    item.idVendor = 0;
                    item.vendorName = GetVendorNameByID(item.idVendor);
                    return true;
                case "TS3200":
                    item.name = Name;
                    item.article = "3573-L4U-2FCLTO4";
                    item.price = 517230;
                    item.quantity = 3;
                    item.weight = 21.3;
                    item.idProduct = 2;
                    item.idVendor = 0;
                    item.vendorName = GetVendorNameByID(item.idVendor);
                    return true;
                case "HPE Brocade SAN AJ822C":
                    item.name = Name;
                    item.article = "AJ822C";
                    item.price = 942760;
                    item.quantity = 7;
                    item.weight = 1.81;
                    item.idProduct = 3;
                    item.idVendor = 1;
                    item.vendorName = GetVendorNameByID(item.idVendor);
                    return true;
                default:
                    item.name = "NOTFound";
                    item.article = "";
                    item.price = 0;
                    item.quantity = 0;
                    item.weight = 0;
                    item.idProduct = -1;
                    item.idVendor = -1;
                    item.vendorName = GetVendorNameByID(item.idVendor);
                    return false;
            }
        }

        //static internal int GetProduct(int idVendor) @@@
        //{

        //}

        static internal int GetProduct(string Name, int idVendor)
        {

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

