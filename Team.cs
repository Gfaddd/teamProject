using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teamProject
{
    internal class Team : INameAndCopy
    {
        protected int regNum;
        protected string name;
        public Team(string name,int regName)
        {
            if(string.IsNullOrEmpty(name))
                throw new ArgumentNullException("Именя пустое либо null");
            if (regName <= 0)
                throw new ArgumentOutOfRangeException("Регистрационный номер - некорректный");
            this.name = name;
            this.regNum = regName;
        }
        public Team()
        {
            name = "Неизвестно";
            regNum = 1;
        }
        public int RegNum
        {
            get => regNum;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Регистрационный номер - некорректный");
                regNum = value;
            }
        }
        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Именя пустое либо null");
                name = value;
            }
        }
        public virtual object DeepCopy() => new Team(name,regNum);
        public override bool Equals(object? obj)
        {
            if (obj is null)
                throw new ArgumentNullException("Объект - null");
            if (obj is Team t)
                return t.name == name&&t.regNum== regNum;
            else
                throw new ArgumentException("Объект не класса Team");
        }
        public static bool operator ==(Team t1, Team t2)
        {
            if (ReferenceEquals(t1, t2))
            {
                return true;
            }
            if (t1 is null || t2 is null)
                return false;
            return t1.Equals(t2);

        }
        public static bool operator !=(Team t1, Team t2)
        {
            return !(t1 == t2);
        }
        public override int GetHashCode() => name.GetHashCode()+regNum.GetHashCode();
        public override string ToString() => $"Имя: {name}\nРегистрационный номер: {regNum}";

    }
}
