using System;

namespace Module07
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.ReadKey();
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
