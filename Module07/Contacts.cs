using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Module07
{
    class Contacts
    {
        private string phone;
        private string email;

        /// <summary>
        /// Свойство номер телефона
        /// Корректный ввод - 71234567890
        /// Без плюса, скобок и дефиса
        /// </summary>

        internal Contacts() { }

        internal Contacts(string phone, string email)
        {
            SetPhone(phone);
            //this.phone = phone;
            this.email = email;
        }

        internal string Phone
        {
            get 
            {
                return phone; 
            }
            set
            {
                SetPhone(value);
            }
        }

        private void SetPhone(string value)
        {
            //@@@ Можно для проверки использовать регулярные выражения, но я их плохо понимаю на данный момент
            if (value.Length == 11 && long.TryParse(value, out long result)) //@@@ можно добавить для защиты от спама совпадение кода страны с адресом заказчика
            {
                //Форматируем до +7 (123) 456-78-90
                StringBuilder stringBuilder = new StringBuilder(value, 18);
                stringBuilder.Insert(0, "+");
                stringBuilder.Insert(2, " (");
                stringBuilder.Insert(7, ") ");
                stringBuilder.Insert(12, "-");
                stringBuilder.Insert(15, "-");
                phone = stringBuilder.ToString();
            }
            else
            {
                throw new ArgumentException("Неправильный формат номера телефона", "phone");
            }
        }

        internal string Email
        {
            get
            {
                return email;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) != true && value.Contains("@") && value.Contains("."))
                {
                    email = value;
                }
                else
                {
                    throw new ArgumentException("Неправильный формат адреса электронной почты", "email");
                }
            }
        }
    }
}
