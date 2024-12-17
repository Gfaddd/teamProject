using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teamProject
{
    internal class ResearchTeamEnumerator : IEnumerator
    {
        ArrayList people;
        int position = 0;
        public ResearchTeamEnumerator(ArrayList mas) => people = mas;

        public object Current
        {
            get => people[position];
        }

        public bool MoveNext()
        {
            if (position < people.Count - 1)
            {
                position++;
                return true;
            }
            return false;
        }
        public void Reset() => position = 0;
    }
}
