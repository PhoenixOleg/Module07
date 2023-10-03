using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.Loader;
using System.Text;
using System.Threading.Tasks;

namespace Module07
{
    /// <summary>
    /// Абстрактный класс доставки "вообще". Базовый для всех видов доставок
    /// </summary>
    abstract class Delivery
    {
        public DateTime DeliveryDate; //Дата доставки
        internal string waitInterval; //Время ожидания получения товара (жизни заказа)

        internal string address; //Адрес получения (доставки) товара

        public abstract string WaitInterval {get;}
        
        internal abstract void Sending();

        public virtual string Address 
        {
            get
            { 
                return address; 
            }
            
            set 
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    address = value;
                }
                else
                {
                    throw new ArgumentException("Строка адреса не может быть пустой", "Address");
                }
                
            }
        }
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

        public override string WaitInterval
        {
            get
            {
                return WaitInterval;
            }
        }

        internal override void Sending() 
        {
            Console.WriteLine($"Ваш заказ передан курьеру {courier?.GetName()} и будет доставлен по адресу {address}.\nОжидаемое время доставки {DeliveryDate:dd.MM.yyyy}. Обратите внимание, что курьер сможет ждать получения заказа не более {waitInterval}.\nСвязаться с курьером Вы можете по телефону {courier?.contacts?.Phone}") ;
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

        public override string WaitInterval
        {
            get
            {
                return WaitInterval;
            }
        }

        internal override void Sending() 
        {
            Console.WriteLine($"Ваш заказ будет готов к выдаче с нашего склада по адресу {address} с {DeliveryDate:dd.MM.yyyy}. Обратите внимание, что заказ можно получить в течение {waitInterval}.");
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
            Console.WriteLine($"Ваш заказ будет готов к выдаче в нашем магазине по адресу {address} с {DeliveryDate:dd.MM.yyyy}. Обратите внимание, что заказ можно получить в течение {waitInterval}.");
        }
    }
}
