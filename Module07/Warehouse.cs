using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Module07
{
    class Warehouse
    {
        private static int countOfPlace;

        //Здесь по логике лучше применить коллекцию, но я их пока не знаю. 
        //Чтобы показать работу с индексатором и статическим полем сделал массив. Это ограничивает гибкость склада      
        static private Product[] products;

        public Warehouse(int CountOfPlace)
        {
            countOfPlace = CountOfPlace; //Вместимость магазина
            products = new Product[countOfPlace];
        }

        public Product this[int index]
        {
            get
            {
                //@@@ В идеале тут еще надо проверку на добавление имеющегося уже товара по его артикулу
                if (index >= 0 && index < products.Length)
                {
                    return products[index];
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }                    
            }
            set
            {
                if (index >= 0 && index < products.Length)
                {
                    products[index] = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        internal void Show(int index)
        {
            if (index >= 0 && index < products.Length)
            {
                if (products[index] != null)
                {
                    Console.WriteLine($"{products[index].vendorName} {products[index].name} (Артикул {products[index].article}). Цена {products[index].price}. Доступное количество {products[index].quantity}.");
                }
                else
                {
                    Console.WriteLine("Товара с индексом {0} не существует", index);
                }
            }
            else
            {
                Console.WriteLine("Индекс {0} находится за пределами диапазона", index);
            }
        }

        internal void ShowCatalog()
        {
            int idx = 0;
            foreach (var item in products)
            {
                if (item != null && item.quantity > 0) {
                    idx++;
                    Console.WriteLine($"{idx}. {item.vendorName} {item.name} (Артикул {item.article}). Цена {item.price}. Доступное количество {item.quantity}.");
                }
            }
        }

        static internal void ChangeQuantity(string Article, double Quantity)
        { 
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i] != null && products[i].article == Article) 
                {
                    products[i].quantity += Quantity;
                }
            }
        }

        internal Product GetClone (Product item)
        {
            return new Product(item.name, item.vendorName, item.article, item.price, item.quantity, item.weight);
        }
    }
}

