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

        public override string ToString() => $"Данные автора:\n{autor}\nНазвание публикации: {namePub}\nГод публикации: {dataPub.ToShortDateString()}\n";

    }
}
