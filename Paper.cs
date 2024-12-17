using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teamProject
{
    internal class Paper
    {
        private string namePub;
        private Person autor;
        DateTime dataPub;


        public Paper()
        {
            this.namePub = "Неизвестно";
            this.autor = new Person();
            this.dataPub = DateTime.Today;
        }
        public Paper(string namePub, Person autor, DateTime dataPub)
        {
            this.namePub = namePub;
            this.autor = autor;
            this.dataPub = dataPub; 
        }
        public string NamePub
        {
            get => namePub;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Значение имеет null или пустая строка");
                 namePub= value;
            }
        }
        public Person Autor
        {
            get => autor;
            set
            {
                if(value==new Person())
                {
                    throw new ArgumentException("Значение имеет null или пустая строка");
                }
                else
                {
                    autor = value;
                }
            }
        }
        public DateTime DataPub
        {
            get => dataPub;
            set
            {
                if (DateTime.Today >= value)
                    dataPub = value;
                else
                    throw new ArgumentException("Дата публикации не может быть больше сегодняшнего дня");
            }
        }
        public virtual object DeepCopy()
        {
            return new Paper( namePub, autor, dataPub);
        }
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;

            Paper other = (Paper)obj;
            return namePub == other.namePub && autor == other.autor && dataPub == other.dataPub;
        }
        public static bool operator ==(Paper p1, Paper p2)
        {
            if (ReferenceEquals(p1, p2))
            {
                return true;
            }
            if (p1 is null || p2 is null)
                return false;
            return p1.Equals(p2);

        }
        public static bool operator !=(Paper p1, Paper p2)
        {
            return !(p1 == p2);
        }
        public override int GetHashCode()
        {
            return (namePub, autor, dataPub).GetHashCode();
        }
        public override string ToString() => $"Название публикации: {namePub}\nДанные автора:\n{autor}\nГод публикации: {dataPub.ToShortDateString()}\n";

    }
}
