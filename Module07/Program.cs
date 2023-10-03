using System;
using System.Threading;

namespace Module07
{
    class Program
    {
        enum DeliveryAdr 
        { 
        }

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
                ErrorReaction(e.Message, e.HResult);
            }
            Console.WriteLine("В нашем магазине Вы можете купить:");
            warehouse.ShowCatalog();
            #endregion

            #region Создаем заказчика ФЛ с адресом и контактами
            Address address = null;
            try
            {
                address = new Address("Солнечногорская ул", "24", "", "3", "15", "г. Москва", "Москва"); //Адрес левый xD Любое совпадение является случайностью
                if (address != null)
                {
                    if (address.ZipCode == null)
                    {address.ZipCode = "123456"; }
                }
                else
                {
                    Console.WriteLine("Не удалось задать адрес");
                }
            }
            catch (ArgumentException e)
            {
                ErrorReaction(e.Message, e.HResult);
            }

            Contacts contacts = new Contacts();
            try
            {
                //Проверку на null не делаю, т. к. код в try и уйдет на обработчик 
                contacts.Phone = "79161234567";
                contacts.Email = "oleg@gmail.com";
            }
            catch (Exception e)
            {
                ErrorReaction(e.Message, e.HResult);
            }

            Person person = null;
            try
            {
                person = new Person("Олег", "", "Королёв");
                person.contacts = contacts;
                person.address = address;
            }
            catch (Exception e)
            {
                ErrorReaction(e.Message, e.HResult);
            }
            #endregion

            
            try
            {
                #region Создаем курьера и доставку на дом
                Courier courier = new Courier("Иванов", "Иван", "Иванович");
                courier.contacts = new Contacts("79876543210", "delivery@shop.com");

                HomeDelivery homeDelivery = new HomeDelivery(courier, DateTime.Now.AddDays(1));
                homeDelivery.Address = person.address.GetAdressString();
                #endregion

                #region Создаем заказ и корзину внутри него
                int orderNum = 1; //Получили новый ID для запись в таблицу заказов в БД
                string remark = "Просьба позвонить до прибытия за 10 минут"; //Пожелания к заказу (для курьера, сборщика и т. п.)
                Order<HomeDelivery, Customer> order = new Order<HomeDelivery, Customer>(homeDelivery, person, orderNum, remark);
                #endregion 

                #region Заполнение корзины
                //Убеждаемся что корзина пуста вначале
                Console.WriteLine("\nВ Вашей корзине находятся товары:");
                order.basket.ShowItems();
                Console.WriteLine("");

                //Попытка добавить товар в слишком большом количестве
                order.basket.AddItem(warehouse.GetClone(warehouse[1]), 10); //basket.AddItem(warehouse[2], 2); - так копируется ссылка на объект в куче и изменение количества идет никак
                Console.WriteLine("\nВ нашем магазине Вы можете купить:");
                warehouse.ShowCatalog();
                Console.WriteLine("");

                //Добавляем товар idx=1 (второй)
                order.basket.AddItem(warehouse.GetClone(warehouse[1]), 3);
                Console.WriteLine("\nВ нашем магазине Вы можете купить:");
                warehouse.ShowCatalog();
                Console.WriteLine("");

                //Добавляем товар idx=2 (третий)
                order.basket.AddItem(warehouse.GetClone(warehouse[2]), 2);
                Console.WriteLine("\nВ нашем магазине Вы можете купить:");
                warehouse.ShowCatalog();
                Console.WriteLine("");

                //Проверяем корзину
                Console.WriteLine("\nВ Вашей корзине находятся товары:");
                order.basket.ShowItems();
                Console.WriteLine("Сумма заказа {0}", order.basket.GetSum());

                //Удаляем товар idx=2 (третий). В корзине он второй
                order.basket.RemoveItem(1);
                Console.WriteLine("\nВ нашем магазине Вы можете купить:");
                warehouse.ShowCatalog();
                Console.WriteLine("");

                //Проверяем корзину
                Console.WriteLine("\nВ Вашей корзине находятся товары:");
                order.basket.ShowItems();
                Console.WriteLine("Сумма заказа {0}", order.basket.GetSum());

                //Добавляем товар idx=0 (первый)
                order.basket.AddItem(warehouse.GetClone(warehouse[0]), 7);
                Console.WriteLine("\nВ нашем магазине Вы можете купить:");
                warehouse.ShowCatalog();
                Console.WriteLine("");

                //Добавляем товар idx=2 (третий)
                order.basket.AddItem(warehouse.GetClone(warehouse[2]), 1);
                Console.WriteLine("\nВ нашем магазине Вы можете купить:");
                warehouse.ShowCatalog();
                Console.WriteLine("");

                //Проверяем корзину
                Console.WriteLine("\nВ Вашей корзине находятся товары:");
                order.basket.ShowItems();
                Console.WriteLine("Сумма заказа {0}", order.basket.GetSum());

                order.basket.Clear();
                Console.WriteLine("\nВ нашем магазине Вы можете купить:");
                warehouse.ShowCatalog();
                Console.WriteLine("");
                //Проверяем корзину
                Console.WriteLine("\nВ Вашей корзине находятся товары:");
                order.basket.ShowItems();
                Console.WriteLine("Сумма заказа {0}", order.basket.GetSum());

                #endregion

                #region "Выходные формы"
                Console.WriteLine("");
                Console.WriteLine($"Уважаемый, {order.Customer.GetName()}. Проверьте Ваши контактные данные:\n\tТелефон - {order.Customer.contacts.Phone}\n\tЭл. почта - {order.Customer.contacts.Email}.");
                Console.WriteLine("");
                order.OrderSending();

                Console.WriteLine($"\nИнформация для курьера.\nЗаказ N{order.Number} необходимо доставить по адресу {order.Delivery.address}. Дата вручения заказа клиенту - {order.Delivery.DeliveryDate:dd.MM.yyyy}." +
                    $"\nФИО клиента - {order.Customer.GetName()}\nДанные для связи с клиентом - {order.Customer.contacts.Phone}" +
                    $"\nНеобходимо выполнить пожелание клиента - {order.Remark}");
                #endregion 
            }
            catch (Exception e)
            {
                ErrorReaction(e.Message, e.HResult);
            }

            Console.ReadKey();



        }

        static void ErrorReaction(string msg, int exitCode)
        {
            Console.WriteLine(msg);
            Console.WriteLine("Выполнение программы будет завершено");
            Console.ReadKey();
            System.Environment.Exit(exitCode);
        }
    }






}
