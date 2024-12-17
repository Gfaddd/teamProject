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
        int countPublication;

        public int countPrivateation
        {
            get => countPublication;
            set
            {
                if (value < 0)
                    throw new Exception("invlaid value");
                countPublication = value;
            }
        }

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

        public Person(string firstName, string lastName, DateTime birthday,int countPublication)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthday = birthday;   
            this.countPublication = countPublication;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;
                
            Person other = (Person)obj;
            return firstName == other.firstName && lastName == other.lastName && birthday == other.birthday;
        }
        public static bool operator ==(Person p1, Person p2)
        {
            if (ReferenceEquals(p1, p2))
            {
                return true;
            }
            if (p1 is null  ||p2 is null)
                return false;
            return p1.Equals(p2);

        }
        public static bool operator !=(Person p1, Person p2)
        {
            return !(p1 == p2);
        }
        public override int GetHashCode()
        {
            return (firstName, lastName, birthday).GetHashCode();
        }
        public virtual object DeepCopy()
        {
            return new Person(this.firstName, this.lastName, this.birthday,this.countPublication);
        }
        public override string ToString() => $"Имя: {firstName}\nФамилия: {LastName}\nГод рождения: {birthday.ToShortDateString()}";

        public virtual string ToShortString() => $"Имя: {firstName}; Фамилия: {LastName}";
    }
}
