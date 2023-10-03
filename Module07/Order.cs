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
    class Order<TDelivery, TCustomer> where TDelivery : Delivery where TCustomer : Customer
    {
        internal TDelivery Delivery; //Поле доставки
        internal TCustomer Customer; //Поле заказчика

        internal int Number; //Поле номера заказа
        internal string Remark; //Поле описания заказа

        internal Basket basket;


        public Order(TDelivery delivery, TCustomer customer, int number, string description)
        {
            Delivery = delivery; //Агрегация (передаем из вне)
            Customer = customer;
            Number = number;
            Remark = description;

            basket = new Basket(); //Композиция. Полная зависимость
        }

        /// <summary>
        /// Метод отображения адреса доставки (получения) заказа
        /// </summary>
        public void DisplayAddress()
        {
            Console.WriteLine(Delivery.Address);
        }

        public void OrderSending()
        {
            if (basket.GetItemCount > 0)
            {
                Delivery.ShowSendingResume();
            }
            else
            {
                Console.WriteLine("Корзина пуста. Невозможно отправить заказ на выполнение");
            }
        }
    }
}
