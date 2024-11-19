using System.Diagnostics;
using teamProject;

ResearchTeam team = new ResearchTeam("qwe", "qwe", 0, TimeFrame.TwoYear, new Paper[] { new Paper("qwe", new Person(), DateTime.MinValue) });
//Console.WriteLine(team + "\n\n");
try
{
    team.NameOrg = "AAA";
    team.ThemeIsled = "";
    team.RegNum = -43;
    team.DurIsled = TimeFrame.LongYear;
    team.SpisPub = new Paper[] { new Paper("bbb", new Person(), new DateTime(1111, 5, 4)), new Paper("ttt", new Person(), DateTime.MinValue) };
    //Console.WriteLine(team);
    team.AddPapers(new Paper[] { new Paper("asd", new Person(), DateTime.Now), new Paper("zxc", new Person(), DateTime.Now) });
}
catch(ArgumentException e)
{
    Console.WriteLine(e.Message);
}
//Console.WriteLine(team);
if (team.firstPaper() == null)
{
    Console.WriteLine("NULL");
}
Console.WriteLine(team.firstPaper());
Console.WriteLine($"{team[TimeFrame.Year]} {team[TimeFrame.TwoYear]} {team[TimeFrame.LongYear]}");

Stopwatch stopwatch = Stopwatch.StartNew();
bool exit = true;
while (exit)
{
    Console.WriteLine("Выбирете пункт меню:\n0 - Выход из меню\n1 - Одномерный массив\n2 - Двумерный массив\n3 - Двумерный ступенчитый массив\nВведите пункт меню:");
    int p = int.Parse(Console.ReadLine());
    switch (p)
    {
        case 0:
            {
                Console.WriteLine("Вы вышли из меню");
                exit = false;
                break;
            }
        case 1:
            {
                Paper[] paper1 = new Paper[] { new Paper("111", new Person(), new DateTime(1111, 5, 4)), new Paper("222", new Person(), DateTime.MinValue), new Paper("333", new Person(), new DateTime(1111, 5, 4)), new Paper("444", new Person(), DateTime.MinValue), new Paper("555", new Person(), new DateTime(1111, 5, 4)), new Paper("666", new Person(), DateTime.MinValue) };
                stopwatch.Start();
                foreach (Paper paper in paper1)
                    Console.WriteLine(paper);
                stopwatch.Stop();
                break;
            }
        case 2:
            {
                Paper[,] paper2 = new Paper[,] { { new Paper("111", new Person(), new DateTime(1111, 5, 4)), new Paper("222", new Person(), DateTime.MinValue)  ,new Paper("333", new Person(), new DateTime(1111, 5, 4)) }, {new Paper("444", new Person(), DateTime.MinValue), new Paper("555", new Person(), new DateTime(1111, 5, 4)), new Paper("666", new Person(), DateTime.MinValue) } };
                stopwatch.Start();
                for (int i = 0; i < paper2.GetLength(0); i++)
                {
                    for (int j = 0; j < paper2.GetLength(1); j++)
                    {
                        Console.WriteLine(paper2[i,j]);
                    }
                    Console.WriteLine();
                }
                stopwatch.Stop();
                break;
            }
            case 3:
            {
                
                Paper[][] paper3 = new Paper[3][];
                paper3[0] = new Paper[1] { new Paper("111", new Person(), new DateTime(1111, 5, 4)) };
                paper3[1] = new Paper[2] { new Paper("222", new Person(), DateTime.MinValue), new Paper("333", new Person(), new DateTime(1111, 5, 4))};
                paper3[2] = new Paper[3] { new Paper("444", new Person(), DateTime.MinValue), new Paper("555", new Person(), new DateTime(1111, 5, 4)), new Paper("666", new Person(), DateTime.MinValue) };
                stopwatch.Start();

                for (int i = 0; i < paper3.GetLength(0); i++)
                {
                    for (int j = 0; j < paper3[i].Length; j++)
                    {
                        Console.WriteLine(paper3[i][j]);
                    }
                    Console.WriteLine();
                }
                stopwatch.Stop();
                break;
            }
        default:
            {
                Console.WriteLine("Такого пункта меню нет, выберите заново");
                break;
            }
    }
}

Console.WriteLine("Время выполнения: " + stopwatch.ElapsedMilliseconds);
enum TimeFrame
{
    Null,
    Year,
    TwoYear,
    LongYear,
}
