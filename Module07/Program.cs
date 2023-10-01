using System;
using System.Threading;

namespace Module07
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Заполняем магазин            
            Warehouse warehouse = new Warehouse(3);
            try 
            {
                warehouse[0] = new Product("RAM 16Gb", "HP", "A2Z52AA", 8500.00m, 60, 0.050);
                warehouse[1] = new Product("HDD SAS 146Gb", "IBM", "40K1044", 10200.00m, 5, 0.7);
                warehouse[2] = new Product("ASR-8805E SGL 2294001-R RAID 0/1/10/ 8i-ports 512Gb", "Adaptec", "1452126", 30723.00m, 2, 0.25);
            }
            catch (Exception e)
            {
                ErrorReaction(e.Message);
            }
            #endregion

            #region Заполнение корзины
            Console.WriteLine("В нашем магазине Вы можете купить:");
            warehouse.ShowCatalog();

            Basket basket = new Basket();

            Console.WriteLine("\nВ Вашей корзине находятся товары:");
            basket.ShowItems();

            basket.AddItem(warehouse.GetClone(warehouse[1]), 10); //basket.AddItem(warehouse[2], 2); - так копируется ссылка на объект в куче и изменение количества идет никак
            Console.WriteLine("\nВ нашем магазине Вы можете купить:");
            warehouse.ShowCatalog();

            basket.AddItem(warehouse.GetClone(warehouse[1]), 3); //basket.AddItem(warehouse[2], 2); - так копируется ссылка на объект в куче и изменение количества идет никак
            Console.WriteLine("\nВ нашем магазине Вы можете купить:");
            warehouse.ShowCatalog();

            basket.AddItem(warehouse.GetClone(warehouse[2]), 2);
            Console.WriteLine("\nВ нашем магазине Вы можете купить:");
            warehouse.ShowCatalog();

            Console.WriteLine("\nВ Вашей корзине находятся товары:");
            basket.ShowItems();
            #endregion 

            //Проверка очистки корзины
            //basket.Clear();
            //Console.WriteLine("\nВ Вашей корзине находятся товары:");
            //basket.ShowItems();

            //Проверка на несушествуюший товар и null
            //Console.WriteLine();
            //Console.WriteLine(basket.GetItem(1)?.name);

            //Test.DoTest();
            Console.ReadKey();
        }
        
        static void ErrorReaction(string msg)
        {
            Console.WriteLine(msg);
            Console.WriteLine("Выполнение программы будет завершено");
            Console.ReadKey();
            System.Environment.Exit(0);
        }
    }



    /// <summary>
    /// Абстрактный класс доставки "вообще". Базовый для всех видов доставок
    /// </summary>
    abstract class Delivery
    {
        public string Address;
    }

    /// <summary>
    /// Доставка на дом. Наследуется от Delivery
    /// </summary>
    class HomeDelivery : Delivery

    {
        /* ... */
    }

    /// <summary>
    /// Доставка в пункт выдачи (самовывоз типа 1). Наследуется от Delivery
    /// </summary>
    class PickPointDelivery : Delivery
    {
        /* ... */
    }

    /// <summary>
    /// Доставка в маазин (самовывоз типа 2). Наследуется от Delivery
    /// </summary>
    class ShopDelivery : Delivery
    {
        /* ... */
    }

    /// <summary>
    /// Класс заказа
    /// </summary>
    /// <typeparam name="TDelivery">Входной обобщенный (универсальный) параметр вида доставки. Ограничивается абстрактным классом Delivery</typeparam>
    /// <typeparam name="TStruct">Входной обобщенный (универсальный) параметр структуры заказа. Ничем не огранивается. Возможно, далее сделаю ограничение struct или конкретной структурой</typeparam>
    class Order<TDelivery, TStruct> where TDelivery : Delivery
    {
        public TDelivery Delivery; //Поле доставки

        public int Number; //Поле номера заказа

        public string Description; //Поле описания заказа

        /// <summary>
        /// Метод отображения адреса доставки (получения) заказа
        /// </summary>
        public void DisplayAddress()
        {
            Console.WriteLine(Delivery.Address);
        }

        // ... Другие поля
    }
}
