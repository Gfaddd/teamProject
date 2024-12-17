using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace teamProject
{
    
    internal class ResearchTeam : Team, IEnumerable
    {
        string themeIsled;
        TimeFrame durIsled;
        ArrayList spisPersons = new ArrayList();
        ArrayList spisPapers = new ArrayList();
        public ResearchTeam() : base("Неизвестно",0)
        {
            themeIsled = "Неизвестно";
            durIsled = TimeFrame.Null;
        }
        public ResearchTeam(string themeIsled, string nameOrg, int regNum, TimeFrame durIsled, ArrayList spisPapers,ArrayList spisPersons) :base(nameOrg,regNum)
        {
            this.themeIsled = themeIsled;
            this.durIsled = durIsled;
            foreach (var i in spisPapers)
                if (i is not Paper)
                    throw new Exception("Массив должен содержать только публикации");
            this.spisPapers = spisPapers;
            foreach (var i in spisPersons)
                if (i is not Person)
                    throw new Exception("Массив должен содержать только людей");
            this.spisPersons = spisPersons;
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
        //public string NameOrg
        //{
        //    get => nameOrg;
        //    set
        //    {
        //        if (string.IsNullOrEmpty(value))
        //            throw new ArgumentException("Значение имеет null или пустая строка");
        //        nameOrg = value;
        //    }
        //}
        //public int RegNum
        //{
        //    get => regNum;
        //    set
        //    {
        //        if (value < 0)
        //            throw new ArgumentException("Номер не может быть отрицательным");
        //        regNum = value;
        //    }
        //}
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
        public ArrayList SpisPapers
        {
            get => spisPapers;
            set
            {
                foreach (var i in value)
                    if (i is not Paper)
                        throw new Exception("Массив должен содержать только публикации");
                spisPapers = value;
            }
        }

        public ArrayList SpisPersons
        {
            get => spisPersons;
            set
            {
                foreach (var i in spisPersons)
                    if (i is not Person)
                        throw new Exception("Массив должен содержать только людей");
                spisPersons = value;
            }
        }

        public Paper? firstPaper()
        {
            DateTime firstDate = DateTime.MaxValue;
            int index = int.MaxValue;
            Paper paper;
            for (int i = 0; i < spisPapers.Count; i++)
            {
                paper = (Paper)spisPapers[i];
                if (firstDate > paper.DataPub)
                {
                    index = i;
                    firstDate = paper.DataPub;
                }
            }

            return index == int.MaxValue ? null : spisPapers[index] as Paper;
        }
        public bool this[TimeFrame value]
        {
            get => durIsled == value;
        }
        public void AddPapers(params Paper[] spis) => spisPapers.AddRange(spis);

        public override string ToString()
        {
            string str = $"Тема исследования: {themeIsled}\n{base.ToString()}\nВремя исследования: {durIsled.ToString()}\nСписок публикаций:\n";
            foreach(var i in spisPapers)
                str += i;
            str += "Список участников преокта:\n";
            foreach(var i in spisPersons)
                str += i;
            return str;
        }
        public virtual string ToShortString() => $"Тема исследования: {themeIsled}\n{base.ToString()}\nВремя исследования: {durIsled.ToString()}";

        public override object DeepCopy() => new ResearchTeam(themeIsled, name, RegNum, durIsled, spisPapers, spisPersons);
        public void AddMembers(params Person[] people) => spisPersons.AddRange(people);
        public Team Team
        {
            get => new Team(name,RegNum);
            set
            {
                if(value.RegNum<=0)
                    throw new ArgumentOutOfRangeException("Регистрационный номер - некорректный");
                RegNum = value.RegNum;
                if (string.IsNullOrEmpty(value.Name))
                    throw new ArgumentNullException("Имя не может быть пустым либо равным null");
                name = value.Name;
            }
        }
        public IEnumerable<Paper> GetPapersFromLastYears(int n)
        {
            DateTime date = DateTime.Now.AddYears(-n);
            foreach (Paper paper in spisPapers)
                if (paper.DataPub >= date)
                    yield return paper;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;

            ResearchTeam other = (ResearchTeam)obj;
            return themeIsled == other.themeIsled && durIsled == other.durIsled && spisPersons == other.spisPersons&& spisPapers == other.spisPapers;
        }
        public static bool operator ==(ResearchTeam t1, ResearchTeam t2)
        {
            if (ReferenceEquals(t1, t2))
            {
                return true;
            }
            if (t1 is null || t2 is null)
                return false;
            return t1.Equals(t2);

        }
        public static bool operator !=(ResearchTeam t1, ResearchTeam t2)
        {
            return !(t1 == t2);
        }
        public IEnumerator GetEnumerator() => new ResearchTeamEnumerator(spisPersons);
        public IEnumerable<Person> GetPerson()
        {
            for (int i = 0; i < spisPersons.Count; i++)
                yield return spisPersons[i] as Person;
        }
        public IEnumerable<Person> GetPersonsWithoutPublication()
        {
            for (int i = 0; i < spisPersons.Count; i++)
                if(spisPersons[i] is Person p && p.countPrivateation == 0)
                    yield return p;
        }
        public IEnumerable<Person> GetPersonsWithPublication()
        {
            for (int i = 0; i < spisPersons.Count; i++)
                if (spisPersons[i] is Person p && p.countPrivateation > 0)
                    yield return p;
        }
        public IEnumerable<Paper> GetPaperFromThisYear()
        {
            for (int i = 0; i < spisPapers.Count; i++)
                if (spisPapers[i] is Paper p && DateTime.Now.Year - p.DataPub.Year == 0)
                    yield return p;
        }
    }
}
