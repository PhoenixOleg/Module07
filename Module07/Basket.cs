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
        //И список дает нужную мне гибкость. Переделывать на список склад не стал. Т. к. не придумал где еще индексатор прикрутить
        private ArrayList products = new ArrayList();

        public void AddItem(Product product, double Quantity)
        {
            Console.WriteLine($"\nПробуем положить в корзину {product.vendorName} {product.name} в количестве {Quantity}...");
            if (product.quantity >= Quantity)
            {
                product.quantity = Quantity;
                Warehouse.ChangeQuantity(product.article, -Quantity);
                products.Add(product);
                Console.WriteLine("Товар добавлен!");
            }
            else
            {
                Console.WriteLine($"Сожалеем, но столько товара {product.vendorName} {product.name} у нас нет. В данный момент можем предложить только {product.quantity}");
            }
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
                var item = (Product)products[id];
                Console.WriteLine($"\nПробуем удалить из корзины {item.vendorName} {item.name} в количестве {item.quantity}...");
                Warehouse.ChangeQuantity(item.article, + item.quantity); //Пишу +, чтоб не запутаться самому
                products.RemoveAt(id);
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
                        Console.WriteLine($"{idx}. {item.vendorName} {item.name} (Артикул {item.article}). Цена {item.price}. Количество {item.quantity}.");
                    }
                }
            }
        }

        public void Clear() 
        {
            foreach (Product item in products) 
            {
                Warehouse.ChangeQuantity(item.article, +item.quantity); //Пишу +, чтоб не запутаться самому
            }
            products.Clear();
            Console.WriteLine("Корзина очищена");
        }

        public decimal GetSum()
        {
            Decimal sum = 0.00m;
            if (products.Count == 0)
            {
                return sum;
            }
            else
            {
                foreach (Product item in products)
                {
                    if (item != null)
                    {
                        sum = sum + decimal.Multiply(item.price, (decimal)item.quantity); //Это был сюрприз с оператором *
                    }
                }
                return sum;
            }
        }

        public int GetItemCount
        {
            get { return products.Count; }
        }

    }
}
