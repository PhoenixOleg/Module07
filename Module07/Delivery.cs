using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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
        internal string waitInterval; //Время ожидания получения товара (жизни заказа)

        public abstract TimeOnly WaitInterval {get;}
        
        internal abstract void Sending();

    }

    /// <summary>
    /// Доставка на дом/офис. Наследуется от Delivery
    /// </summary>
    class HomeDelivery : Delivery
    {
        Courier courier;

        internal HomeDelivery(Courier courier, DateTime deliveryDate)
        {
            this.courier = courier;
            DeliveryDate = deliveryDate;
            waitInterval = "15 минут";
        }

        public override TimeOnly WaitInterval
        {
            get
            {
                return WaitInterval;
            }
        }

        internal override void Sending() 
        {
            Console.WriteLine($"Ваш заказ передан курьеру {courier?.DisplayName()} и будет доставлен по адресу {Address}.\nОжидаемое время доставки {DeliveryDate:dd.MM.yyyy}. Обратите внимание, что курьер сможет ждать получения заказа не более {waitInterval}.\nСвязаться с курьером Вы можете по телефону {courier?.contacts?.Phone}") ;
        }
    }

    /// <summary>
    /// Доставка в пункт выдачи (самовывоз типа 1). Наследуется от Delivery
    /// </summary>
    class PickPointDelivery : Delivery
    {
        internal PickPointDelivery(DateTime deliveryDate)
        {
            DeliveryDate = deliveryDate;
            waitInterval = "3 дней";
        }

        public override TimeOnly WaitInterval
        {
            get
            {
                return WaitInterval;
            }
        }

        internal override void Sending() 
        {
            Console.WriteLine($"Ваш заказ будет готов к выдаче с нашего склада по адресу {Address} с {DeliveryDate:dd.MM.yyyy}. Обратите внимание, что заказ можно получить в течение {waitInterval}.");
        }
    }

    //    /// <summary>
    //    /// Доставка в магазин (самовывоз типа 2). Наследуется от PickPointDelivery
    //    /// </summary>
    class ShopDelivery : PickPointDelivery
    {
        internal ShopDelivery(DateTime deliveryDate) : base (deliveryDate)
        {
            DeliveryDate = deliveryDate;
            waitInterval = "1 дня"; //держать помещение торговой точки дорого
        }

        internal override void Sending() //Если создам экземпляр как PickPointDelivery shopDelivery = new ShopDelivery и метод будет new вместо override (сокрыт, а не переопределен), будет выдача со склада
        {
            Console.WriteLine($"Ваш заказ будет готов к выдаче в нашем магазине по адресу {Address} с {DeliveryDate:dd.MM.yyyy}. Обратите внимание, что заказ можно получить в течение {waitInterval}.");
        }
    }
}
