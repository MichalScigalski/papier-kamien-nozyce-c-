using System;
using System.Threading;

namespace rockpaperscissors
{
    class Program
    {
        static string[] option = { "papier", "kamień", "nożyce" };
        static int playerCounter, computerCounter;
        static void run()
        {
            showXY("1. papier \n2. kamień \n3. nożyce", 0, 3);
            showXY("Wybierz czym chcesz być:", 0, 1);
            int x = int.Parse(Console.ReadLine());
            switch (x)
            {
                case 1:
                    showXY("\nWybrałeś papier", 1, 6);
                    check("papier");
                    break;
                case 2:
                    showXY("\nWybrałeś kamień", 1, 6);
                    check("kamień");
                    break;
                case 3:
                    showXY("\nWybrałeś nożyce", 1, 6);
                    check("nożyce");
                    break;
                default:
                    showXY("\nNie ma takiej opcji", 1, 6);
                    break;
            }
            showCounter();
            Thread.Sleep(1000);
        }
        static void showCounter()
        {
            showXY($"Ty: {playerCounter} || Komputer: {computerCounter} \n", 8, 12);
        }

        static void check(string playerOption)
        {
            Random random = new Random();
            int start = random.Next(0, option.Length);
            string enemy = option[start];
            Thread.Sleep(400);
            printT($"Twój przeciwnik wybrał: {enemy}\n");
            Thread.Sleep(1000);

            if (playerOption == "papier")
            {
                if (enemy == "papier")
                    printT("Remis");
                if (enemy == "kamień")
                {
                    printT("Wygrywasz!");
                    playerCounter++;
                }
                if (enemy == "nożyce")
                {
                    printT("Przegrywasz!");
                    computerCounter++;
                }
            }
            if (playerOption == "nożyce")
            {
                if (enemy == "nożyce")
                    printT("Remis");
                if (enemy == "papier")
                {
                    printT("Wygrywasz!");
                    playerCounter++;
                }
                if (enemy == "kamień")
                {
                    printT("Przegrywasz!");
                    computerCounter++;
                }
            }
            if (playerOption == "kamień")
            {
                if (enemy == "kamień")
                    printT("Remis");
                if (enemy == "nożyce")
                {
                    printT("Wygrywasz!");
                    playerCounter++;
                }
                if (enemy == "papier")
                {
                    printT("Przegrywasz!");
                    computerCounter++;
                }
            }
        }

        static void printT(string t)
        {
            Console.WriteLine(t);
        }
        static void showXY(string t, int left = 0, int top = 0)
        {
            if (left != 0 || top != 0)
                Console.SetCursorPosition(left, top);
            Console.WriteLine(t);

        }
        static void Main(string[] args)
        {
            char res;
            int amountGame;
            do
            {
                Console.Clear();
                computerCounter = 0; playerCounter = 0;
                printT("Do ilu chcesz grać?");
                amountGame = int.Parse(Console.ReadLine());

                while (playerCounter < amountGame && computerCounter < amountGame)
                {
                    Console.Clear();
                    showCounter();
                    run();
                }

                printT("Czy chcesz zagrać ponownie? (t/n)");
                res = char.Parse(Console.ReadLine());
            }
            while (res == 't' || res == 'T');
            Console.Clear();
            showXY("KONIEC GRY!", 13, 9);
            showXY("v wynik rundy v", 10, 10);
            showCounter();
        }
    }
}
