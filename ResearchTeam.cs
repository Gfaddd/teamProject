using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teamProject
{
    internal class ResearchTeam
    {
        string themeIsled;
        string nameOrg;
        int regNum;
        TimeFrame durIsled;
        Paper[] spisPub;

        public ResearchTeam()
        {
            themeIsled = "Неизвестно";
            nameOrg = "Неизвестно";
            regNum = 0;
            durIsled = TimeFrame.Null;
            spisPub = new Paper[] { new Paper() };
        }
        public ResearchTeam(string themeIsled, string nameOrg, int regNum, TimeFrame durIsled, Paper[] spisPub)
        {
            this.themeIsled = themeIsled;
            this.nameOrg = nameOrg;
            this.regNum = regNum;
            this.durIsled = durIsled;
            this.spisPub = spisPub;
        }
        public string ThemeIsled
        {
            get => themeIsled;
            set 
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Значение имеет null или пустая строка");
                themeIsled = value;
            }
        }
        public string NameOrg
        {
            get => nameOrg;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Значение имеет null или пустая строка");
                nameOrg = value;
            }
        }
        public int RegNum
        {
            get => regNum;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Номер не может быть отрицательным");
                regNum = value;
            }
        }
        public TimeFrame DurIsled
        {
            get => durIsled;
            set 
            {
                if (value == TimeFrame.Null)
                    throw new ArgumentException("Время исследования не может быть Null");
                durIsled = value;
            }
        }
        public Paper[] SpisPub
        {
            get => spisPub;
            set
            {
                if (spisPub == null)
                    throw new ArgumentException("Список исследований не может быть пуст");
                spisPub = value;
            }
        }

        public Paper firstPaper()
        {
            DateTime firstDate = DateTime.MaxValue;
            int index = int.MaxValue;
            for(int i = 0;i<spisPub.Length;i++)
            {
                if(firstDate > spisPub[i].DataPub)
                {
                    index = i;
                    firstDate = spisPub[i].DataPub;
                }
            }

            return index == int.MaxValue ?null: spisPub[index];
        }
        public bool this[TimeFrame value]
        {
            get => durIsled == value;
        }
        public void AddPapers(params Paper[] spis)
        {
            Paper[] temp = new Paper[spis.Length + spisPub.Length];
            Array.Copy(spisPub, 0, temp, 0, SpisPub.Length);
            Array.Copy(spis, 0, temp, spisPub.Length, temp.Length - spisPub.Length);
            spisPub = temp;
        }
        public override string ToString()
        {
            string str = $"Тема исследования: {themeIsled}\nНазвание организации: {nameOrg}\nРегистрационный номер: {regNum}\nВремя исследования: {durIsled.ToString()}\nСписок публикаций:\n";
            foreach(var i in spisPub)
                str += i;
            return str;
        }
        public virtual string ToShortString() => $"Тема исследования: {themeIsled}\nНазвание организации: {nameOrg}\nРегистрационный номер: {regNum}\nВремя исследования: {durIsled.ToString()}";

    }
}
