using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teamProject
{
    class Person
    {
        string firstName;
        string lastName;
        DateTime birthday;

        public DateTime Birthday
        {
            get => birthday;
            set
            {
                if (DateTime.Today >= value)
                    birthday = value;
                else
                    throw new ArgumentException("День рождения не может быть больше сегодняшнего дня");
            }
        }
        public string FirstName
        {
            get => firstName;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Значение имеет null или пустая строка");

                firstName = value;
            }
        }
        public string LastName
        {
            get => lastName;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Значение имеет null или пустая строка");

                lastName = value;
            }
        }

        public int Yers
        {
            get => birthday.Year;
            set
            {
                if (value > DateTime.Now.Year)
                    throw new ArgumentException("Передаваемый год больше года в данный момент");

                int differenceYers = DateTime.Now.Year - value;

                birthday = birthday.AddYears(-differenceYers);
            }
        }

        public Person()
        {
            this.firstName = "Имя неизвестно";
            this.lastName = "Фамилия неизвестна";
            this.birthday = DateTime.Today;
        }

        public Person(string firstName, string lastName, DateTime birthday)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthday = birthday;   
        }

        public override string ToString() => $"Имя: {firstName}\nФамилия: {LastName}\nГод рождения: {birthday.ToShortDateString()}";

        public virtual string ToShortString() => $"Имя: {firstName}; Фамилия: {LastName}";
    }
}
