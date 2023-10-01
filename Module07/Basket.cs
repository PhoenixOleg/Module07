using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module07
{
    internal class Basket
    {
        //Так как Корзина это мини-склад, сначала планировал наследовать его от Warehouse
        //Но тут вспомнил, что списки я использую в VB.Net и более-менее работать с ними умею.
        //И список дает нужную мне гибкость. ПЕределывать на список склад не стал. Пока не придумал где еще индексатор прикрутить
        ArrayList products = new ArrayList();

        public void AddItem(Product product)
        { 
            products.Add(product);
        }

        public Product GetItem(int id)
        {
            if(id >= 0 && id < products.Count)
            {
                return (Product)products[id];
            }
            else
            {
                Console.WriteLine("Товара с таким индексом не существует");
                return null;
            }
        }
        
        public void RemoveItem(int id) 
        {
            if (id >= 0 && id < products.Count)
            {
                products.Remove(id);
            }
            else
            {
                Console.WriteLine("Товара с таким индексом не существует");
            }
        }

        internal void ShowItems()
        {
            if (products.Count == 0)
            {
                Console.WriteLine("Ваша корзина пуста!");
            }
            else
            { 
            int idx = 0;
            foreach (Product item in products)
            {
                if (item != null)
                {
                    idx++;
                    Console.WriteLine($"{idx}. {item.vendorName} {item.name} (Артикул {item.article}). Цена {item.price}. Доступное количество {item.quantity}.");
                }
            }
            }
        }

        public void Clear()
        {
            products.Clear();
        }
    }
}
