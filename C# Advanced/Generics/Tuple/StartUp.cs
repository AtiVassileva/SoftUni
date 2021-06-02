using System;

class StartUp
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine().Split();
        var tuple1 = new ThreeUple<string, string, string>(input[0] + " " + input[1], input[2], input[3]);
        Console.WriteLine(tuple1);

        input = Console.ReadLine().Split();
        var isDrunk = input[2] == "drunk" ? true : false;
        var tuple2 = new ThreeUple<string, int, bool>(input[0], int.Parse(input[1]), isDrunk);
        Console.WriteLine(tuple2);

        input = Console.ReadLine().Split();
        var tuple3 = new ThreeUple<string, double, string>(input[0], double.Parse(input[1]), input[2]);
        Console.WriteLine(tuple3);
    }
}