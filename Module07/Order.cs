using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module07
{
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
