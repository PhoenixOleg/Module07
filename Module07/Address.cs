using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module07
{
    /// <summary>
    /// Класс почтового адреса
    /// </summary>
    
    class Address
    {
        string street; //улица
        string building; //номер дома/владения (в идеале надо прописывать и поле для корпуса/строения. иначе в реальном проекте с БД нарушается нормализация таблицы)
        string intercomCode; //код домофона
        string floor; //Этаж
        string apartment; //квартира / номер офиса
        string city; //город, населенный пункт
        string state; //регион. мск, область, например
        string zipCode; //почтовый индекс

        public string ZipCode
        {
            get
            {
                return zipCode;
            }
            set
            {
                if (ValidateZipCode(value))
                {
                    zipCode = value;
                }
                else
                {
                    Console.WriteLine ("!");
                    throw new ArgumentException("Неправильный формат почтового индекса", "zipCode");
                }
                    
            }
        }

        /// <summary>
        /// Конструктор адреса. Почтовый индекс может не определиться по введеной локации. Например, для новых адресов, поэтому его можно принудительно задать через свойства
        /// </summary>
        /// <param name="street">улица</param>
        /// <param name="building">здание</param>
        /// <param name="intercomcode">код домофона</param>
        /// <param name="floor">этаж</param>
        /// <param name="apartment">квартира/офис</param>
        /// <param name="city">населенный пункт</param>
        /// <param name="state">регион</param>
        internal Address(string street, string building, string intercomcode, string floor, string apartment, string city, string state)
        //string zipcode задаем отдельно
        {
            if (ValidateStateCity(state) == false)
            {
                throw new ArgumentException("Не найден регион (область)", "state");
                //https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception?view=net-7.0&amp%3Bredirectedfrom=MSDN
            }
            else
            {
                this.state = state;
            }

            if (ValidateStateCity(state, city) == false)
            {
                throw new ArgumentException("В заданном регионе (области) не найден населенный пункт", "city");
            }
            else
            {
                this.city = city; 
            }

            if (String.IsNullOrWhiteSpace(street) == false) 
            {
                this.street = street;
            }
            else
            {
                throw new ArgumentException("Улица должна быть задана", "street");
            }

            if (String.IsNullOrWhiteSpace(building) == false)
            {
                this.building = building;
            }
            else
            {
                throw new ArgumentException("Не указан номер дома", building);
            }
            
            this.intercomCode = intercomcode; //может быть не задан
            this.floor = floor; //может быть не задан
            this.apartment = apartment; //может быть не задан
            this.zipCode = GetZipCode();
        }

        /// <summary>
        /// Проверка почтового региона и/или города по справочнику
        /// Метод статический, чтобы можно было проверить без создания объекта адреса (до этого)
        /// Перегрузка:
        ///     1. проверка только региона
        ///     2. проверка города в связке с регионом
        /// </summary>
        /// <param name="state">Регион</param>
        /// <returns></returns>
        static internal bool ValidateStateCity(string state)
        {
            //Блок проверки региона по справочнику. В рф называется КЛАДР
            if (state.Length > 0) //Пусть будет такая залушка
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Проверка почтового региона и/или города по справочнику
        /// Метод статический, чтобы можно было проверить без создания объекта адреса (до этого)
        /// Перегрузка:
        ///     1. проверка только региона
        ///     2. проверка города в связке с регионом
        /// </summary>
        /// <param name="state">Регион</param>
        /// <param name="city">Населенный пункт</param>
        /// <returns></returns>
        static internal bool ValidateStateCity(string state, string city)
        {
            //Блок проверки региона по справочнику. В рф называется КЛАДР
            if (state.Length > 0 && city.Length > 0) //Пусть будет такая залушка
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateZipCode(string zipcode)
        {
            if (zipcode.Length == 6 && Int32.TryParse(zipcode, out int result))
            {
                return true ;
            }
            else 
            {
                return false; 
            }
        }

        /// <summary>
        /// Получение почтового индекса по полностью заданому адресу из справочника
        /// </summary>
        /// <returns></returns>
        private string GetZipCode()
        {
            //Заглушка
            if (state == "Москва" && city == "г. Москва" && street == "Кутузовский пр-т" && building == "31")
            {
                return "121165";
            }
            if (state == "Москва" && city == "г. Москва" && street == "Солнечногорская ул" && building == "24")
            {
                return "125413";
            }
            else 
            {
                return null;
            }
        }

        internal string Display()
        {
            return ZipCode + ", " + state + ", " + city + ", " + street + ", дом " + building + ", этаж " + (String.IsNullOrWhiteSpace(floor) ? "не указан" : floor) + ", кв. " + (String.IsNullOrWhiteSpace(apartment) ? "не указана" : apartment) + " (код домофона - " + (String.IsNullOrWhiteSpace(intercomCode) ? "не указан" : intercomCode) + ")";
        }
    }
}
