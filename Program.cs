using System.Diagnostics;
using teamProject;

ResearchTeam team = new ResearchTeam("qwe", "qwe", 0, TimeFrame.TwoYear, new Paper[] 
{
    new Paper("qwe", new Person(), DateTime.MinValue) 
});
Console.WriteLine(team.ToShortString() + "\n\n");
try
{
    team.RegNum = -43;
}
catch (ArgumentException e)
{
    Console.WriteLine(e.Message);
}
team.NameOrg = "AAA";
team.ThemeIsled = "wqewr";
team.RegNum = 4;
team.DurIsled = TimeFrame.Long;
team.SpisPub = new Paper[] 
{
    new Paper("bbb", new Person(), new DateTime(1111, 5, 4)),
    new Paper("ttt", new Person(), DateTime.MinValue)
};
Console.WriteLine("\n\n"+team);
team.AddPapers(new Paper[] 
{
    new Paper("asd", new Person(), DateTime.Now),
    new Paper("zxc", new Person(), DateTime.Now) 
});
//Console.WriteLine(team);
if (team.firstPaper() == null)
{
    Console.WriteLine("NULL");
}
Console.WriteLine(team.firstPaper());
Console.WriteLine($"Год: {team[TimeFrame.Year]}\nДва года: {team[TimeFrame.TwoYear]}\nБолее долгий срок: {team[TimeFrame.Long]}");

bool exit = false;
Stopwatch stopwatch = stopwatch = Stopwatch.StartNew();
while (!exit)
{
        stopwatch.Reset();
    Console.Write("Выбирете пункт меню:\n0 - Выход из меню\n1 - Одномерный массив\n2 - Двумерный массив\n3 - Двумерный ступенчитый массив\nВведите пункт меню: ");
    int p = int.Parse(Console.ReadLine());
    switch (p)
    {
        case 0:
            {
                Console.WriteLine("Вы вышли из меню");
                exit = true;
                break;
            }
        case 1:
            {
                Paper[] paper = 
                {
                    new Paper("111", new Person(), new DateTime(1111, 5, 4)),
                    new Paper("222", new Person(), DateTime.MinValue),
                    new Paper("333", new Person(), new DateTime(1111, 5, 4)),
                    new Paper("444", new Person(), DateTime.MinValue),
                    new Paper("555", new Person(), new DateTime(1111, 5, 4)),
                    new Paper("666", new Person(), DateTime.MinValue)
                };
                stopwatch.Start();
                foreach (Paper i in paper)
                    Console.WriteLine(i);
                stopwatch.Stop();
                break;
            }
        case 2:
            {
                Paper[,] paper = new Paper[,] 
                {
                    {
                        new Paper("111", new Person(), new DateTime(1111, 5, 4)),
                        new Paper("222", new Person(), DateTime.MinValue),
                        new Paper("333", new Person(), new DateTime(1111, 5, 4))
                    },
                    {
                        new Paper("444", new Person(), DateTime.MinValue),
                        new Paper("555", new Person(), new DateTime(1111, 5, 4)),
                        new Paper("666", new Person(), DateTime.MinValue)
                    }
                };
                stopwatch.Start();
                for (int i = 0; i < paper.GetLength(0); i++)
                {
                    for (int j = 0; j < paper.GetLength(1); j++)
                    {
                        Console.WriteLine(paper[i,j]);
                    }
                    Console.WriteLine();
                }
                stopwatch.Stop();
                break;
            }
            case 3:
            {
                Paper[][] paper = new Paper[3][];
                paper[0] = new Paper[1] { new Paper("111", new Person(), new DateTime(1111, 5, 4)) };
                paper[1] = new Paper[2] 
                {
                    new Paper("222", new Person(), DateTime.MinValue),
                    new Paper("333", new Person(), new DateTime(1111, 5, 4))
                };
                paper[2] = new Paper[3] 
                { 
                    new Paper("444", new Person(), DateTime.MinValue), 
                    new Paper("555", new Person(), new DateTime(1111, 5, 4)),
                    new Paper("666", new Person(), DateTime.MinValue)
                };
                stopwatch.Start();

                for (int i = 0; i < paper.GetLength(0); i++)
                {
                    for (int j = 0; j < paper[i].Length; j++)
                    {
                        Console.WriteLine(paper[i][j]);
                    }
                    Console.WriteLine();
                }
                stopwatch.Stop();
                break;
            }
        default:
            {
                Console.WriteLine("Такого пункта меню нет, выберите заново");
                continue;
            }
    }
    if(!exit)
        Console.WriteLine($"Время выполнения: {stopwatch.ElapsedMilliseconds }\n");

}

enum TimeFrame
{
    Null,
    Year,
    TwoYear,
    Long,
}
