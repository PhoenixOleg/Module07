using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module07
{
    abstract class Customer
    {
        internal Address address;
        internal Contacts contacts;
        private string name;

        internal Customer(string Name) 
        {
            name = Name;
        }

        virtual internal string GetName()
        {
            return name;
        }
        
    }

    class Person : Customer 
    {
        private string name;
        private string middleName;
        private string lastName;
        private int age;

        /// <summary>
        /// Конструктор покупателя-человека для обычных товаров
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="middleName">Отчество</param>
        /// <param name="lastName">Фамилия</param>
        internal Person (string name, string middleName, string lastName) : base(name)
        {
            if (!string.IsNullOrWhiteSpace(name) && !string .IsNullOrWhiteSpace(lastName))
            {
                this.name = name;
                this.middleName = middleName;
                this.lastName = lastName;
            }
            else
            {
                throw new ArgumentException("Поля имя и фамилия и не могут быть пустыми");
            }
        }

        /// <summary>
        /// Конструктор покупателя-человека для обычных товаров 18+
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="middleName">Отчество</param>
        /// <param name="lastName">Фамилия</param>
        /// <param name="age">Возраст</param>
        internal Person(string name, string middleName, string lastName, string age) : this (name, middleName, lastName) //чтобы избежать повтора кода
        {
            if (Int32.TryParse(age, out int result) && result >= 18)
            {
                this.age = result;
            }
            else 
            {
                throw new ArgumentException("Возраст должен быть числом и быть не менее 18");
            }            
        }

        internal override string GetName()
        {
            return (name + " " + middleName + " " + lastName).Replace ("  ", " "); //Подавление второго пробела, если не указано отчество
        }

        internal int GetAge()
        {
            return age;
        }
    }

    class Company : Customer
    {
        private string name;

        internal Company (string name) : base (name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                this.name = name;
            }
            else
            {
                throw new ArgumentException("Название компании не может быть пустыми");
            }
        }
    }

    class Courier : Person
    {
        internal Courier(string name, string middleName, string lastName) : base (name, middleName, lastName) { }
    }
}
