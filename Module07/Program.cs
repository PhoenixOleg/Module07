using System;

namespace Module07
{
    class Program
    {
        static void Main(string[] args)
        {
            Address address = null;
            try        
            {
                ///*Address*/ address = new Address("Street", "Building", "intercode", "floor", "appartment", "city", "state");
                address = new Address("Солнечногорская ул", "24", "", "3", "15", "г. Москва", "Москва");
                if (address != null)
                {
                    if (address.ZipCode == null)
                    { address.ZipCode = "123456"; }
                }
                else
                {
                    Console.WriteLine("Не удалось задать адрес");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine(address?.ZipCode);
            Console.WriteLine(address?.Display());

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
