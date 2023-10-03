using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module07
{
    class Test
    {
        /// <summary>
        /// Метод, куда убран и закомментирован вспомогательный код для тестирования функционала. В релизе не нужен
        /// </summary>
        public static void DoTest()
        {
            //    {
            //        Address address = null;
            //        try
            //        {
            //            ///*Address*/ address = new Address("Street", "Building", "intercode", "floor", "appartment", "city", "state");
            //            address = new Address("Солнечногорская ул", "24", "", "3", "15", "г. Москва", "Москва");
            //            if (address != null)
            //            {
            //                if (address.ZipCode == null)
            //                { address.ZipCode = "123456"; }
            //            }
            //            else
            //            {
            //                Console.WriteLine("Не удалось задать адрес");
            //            }
            //        }
            //        catch (ArgumentException e)
            //        {
            //            Console.WriteLine(e.Message);
            //        }

            //        Console.WriteLine(address?.ZipCode);
            //        Console.WriteLine(address?.GetAdressString());

            //        Contacts contacts = new Contacts();
            //        try
            //        {
            //            contacts.Phone = "79161234567";
            //            contacts.Email = "oleggmail.com";
            //        }
            //        catch (ArgumentException e)
            //        {
            //            Console.WriteLine(e.Message);
            //        }

            //        Console.WriteLine("Phone {0}, Email {1}", contacts?.Phone, contacts?.Email);

            //        Person person = null;
            //        try
            //        {
            //            person = new Person("Олег", "", "Королев");
            //        }
            //        catch (ArgumentException e)
            //        {
            //            Console.WriteLine(e.Message);
            //        }
            //        Console.WriteLine(person?.GetName());
            //        Console.WriteLine(person?.GetAge());
            //        //------------

            //        //Тест класса Person
            //        try
            //        {
            //            person = new Person("Олег", "", "Королев", "44");
            //            person.address = new Address("Солнечногорская ул", "24", "", "3", "15", "г. Москва", "Москва");
            //            if (address != null)
            //            {
            //                if (address.ZipCode == null)
            //                {address.ZipCode = "123456"; }
            //            }
            //            else
            //            {
            //                Console.WriteLine("Не удалось задать адрес");
            //            }
            //            person.contacts = new Contacts();
            //            person.contacts.Phone = "79161234567";
            //            person.contacts.Email = "mail@gmail.com";
            //        }
            //        catch (ArgumentException e)
            //        {
            //            Console.WriteLine(e.Message);
            //        }

            //        Console.WriteLine(person?.GetName());
            //        Console.WriteLine(person?.GetAge());
            //        Console.WriteLine(person.address.GetAdressString());
            //        Console.WriteLine("Phone {0}, Email {1}", person?.contacts?.Phone, person?.contacts?.Email);

            //        //Тест класса Company 
            //        Company company = null;

            //        try 
            //        {
            //            company = new Company("ООО Ромашка");
            //        }

            //        catch (ArgumentException e)
            //        {
            //            Console.WriteLine(e.Message);
            //        }

            //        Console.WriteLine(company?.GetName());


            //        Basket basket = new Basket();

            //        //Проверка очистки корзины
            //        basket.Clear();
            //        Console.WriteLine("\nВ Вашей корзине находятся товары:");
            //        basket.ShowItems();

            //       // Проверка на несушествуюший товар и null
            //        Console.WriteLine();
            //        Console.WriteLine(basket.GetItem(1)?.name);

            //        PickPointDelivery shopDelivery = new ShopDelivery(DateTime.Now.AddDays(1));
            //        shopDelivery.Sending();
            //    }

            //order.basket.Clear();
            //Console.WriteLine("\nВ нашем магазине Вы можете купить:");
            //warehouse.ShowCatalog();
            //Console.WriteLine("");
            ////Проверяем корзину
            //Console.WriteLine("\nВ Вашей корзине находятся товары:");
            //order.basket.ShowItems();
            //Console.WriteLine("Сумма заказа {0}", order.basket.GetSum());
        }
    }
}
