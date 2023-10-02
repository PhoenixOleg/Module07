using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module07
{
    /// <summary>
    /// Абстрактный класс доставки "вообще". Базовый для всех видов доставок
    /// </summary>
    abstract class Delivery
    {
        public string Address; //Адрес получения (доставки) товара
        public DateTime DeliveryDate; //Дата доставки
        public DateTime Waitinterval; //Время ожидания получения товара (жизни заказа)

        internal abstract void Sending();

    }

    /// <summary>
    /// Доставка на дом/офис. Наследуется от Delivery
    /// </summary>
    class HomeDelivery : Delivery
    {

        //Нужен класс курьера
        /* ... */
        internal override void Sending() { }
    }

    /// <summary>
    /// Доставка в пункт выдачи (самовывоз типа 1). Наследуется от Delivery
    /// </summary>
    class PickPointDelivery : Delivery
    {
        /* ... */
        internal override void Sending() { }    
    }

    /// <summary>
    /// Доставка в магазин (самовывоз типа 2). Наследуется от Delivery
    /// </summary>
    class ShopDelivery : Delivery
    {
        /* ... */
        internal override void Sending() { }

    }
}
