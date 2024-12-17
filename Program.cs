using System.Collections;
using System.Diagnostics;
using teamProject;
Team t1 = new("team", 1);
Team t2 = new("team", 1);
if (t1 ==t2)
    Console.WriteLine("t1 == t2");
else
    Console.WriteLine("t1 != t2");
if (ReferenceEquals(t1,t2))
    Console.WriteLine("ref t1 == ref t2");
else
    Console.WriteLine("ref t1 != ref t2");
Console.WriteLine($"t1 hashCode: {t1.GetHashCode()}\nt2 hashCode: {t2.GetHashCode()}");
try
{
    t1.RegNum = -3;
}
catch(ArgumentOutOfRangeException e)
{
    Console.WriteLine(e.Message);
}
ResearchTeam researchTeam = new ("themeIsled","AAA",562,TimeFrame.TwoYear, new ArrayList { new Paper("pubNew", new Person("qqqqqqqqq", "qqqqqqqqqqqq", DateTime.Now,0), DateTime.MinValue), new Paper("pubA", new Person("nameA", "surnameA", DateTime.Now, 0), DateTime.Now), new Paper("pubB", new Person("nameB", "surnameB", DateTime.Now, 0), DateTime.Now) },new ArrayList { new Person("nameA", "surnameA", DateTime.Now,0), new Person("nameB", "surnameB", DateTime.Now, 0) });
Console.WriteLine(researchTeam);
Console.WriteLine(researchTeam.Name);
ResearchTeam researchTeam1 = researchTeam.DeepCopy() as ResearchTeam;
researchTeam.Name = "newName";
Console.WriteLine($"rT name: {researchTeam.Name}\trT1 name: {researchTeam1.Name}");
foreach (var i in researchTeam.GetPerson())
    Console.WriteLine(i);
foreach (var i in researchTeam.GetPapersFromLastYears(5))
    Console.WriteLine(i);




 
enum TimeFrame
{
    Null,
    Year,
    TwoYear,
    Long,
}
