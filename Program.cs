using System;
using System.Threading;

namespace rockpaperscissors
{
    class Program
    {
        static int playerCounter, computerCounter;
        //zmienne służące do ustalania prawdopodobieństwa.
        static double percentFirst = 33.3, percentSecond = 66.6;
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
            Thread.Sleep(2000);
        }
        static void showCounter()
        {
            showXY($"Ty: {playerCounter} || Komputer: {computerCounter} \n", 8, 12);
        }

        static void check(string playerOption)
        {
            //losowanie przez komputer
            Random random = new Random();
            string enemy = "";
            int rand = random.Next(1, 101);
            Thread.Sleep(400);
            if (rand <= percentFirst)
                enemy = "papier";
            else if (rand > percentFirst && rand < percentSecond)
                enemy = "kamień";
            else
                enemy = "nożyce";

            showXY($"Twój przeciwnik wybrał: {enemy}\n");
            Thread.Sleep(1000);

            if (playerOption == "papier")
            {
                if (enemy == "papier")
                {
                    //papier na 10%, kamień 45%, nożyce 45%
                    percentFirst = 10; percentSecond = percentFirst + 45;
                    showXY("Remis");
                }
                if (enemy == "kamień")
                {
                    //papier 45%, kamień na 10%,  nożyce 45%
                    percentFirst = 45; percentSecond = percentFirst + 10;
                    showXY("Wygrywasz!");
                    playerCounter++;
                }
                if (enemy == "nożyce")
                {
                    //papier na 5%, kamień 5%, nożyce 90%
                    percentFirst = 5; percentSecond = percentFirst + 5;
                    showXY("Przegrywasz!");
                    computerCounter++;
                }
            }

            if (playerOption == "kamień")
            {
                if (enemy == "kamień")
                {
                    //kamień na 10%, nożyce 45%, papier 45%
                    percentFirst = 45; percentSecond = percentFirst + 10;
                    showXY("Remis");
                }
                if (enemy == "nożyce")
                {
                    //papier na 45%, kamień 45%, nożyce 10%, 
                    percentFirst = 45; percentSecond = percentFirst + 45;
                    showXY("Wygrywasz!");
                    playerCounter++;
                }
                if (enemy == "papier")
                {
                    //papier na 90%, nożyce 5%, papier 5%
                    percentFirst = 90; percentSecond = percentFirst + 5;
                    showXY("Przegrywasz!");
                    computerCounter++;
                }
            }
            if (playerOption == "nożyce")
            {
                if (enemy == "nożyce")
                {
                    //papier na 45%, kamień 45%, nożyce 10%
                    percentFirst = 45; percentSecond = percentFirst + 45;
                    showXY("Remis");
                }
                if (enemy == "papier")
                {
                    //papier na 10%, kamień 45%, nożyce 45%   
                    percentFirst = 10; percentSecond = percentFirst + 45;
                    showXY("Wygrywasz!");
                    playerCounter++;
                }
                if (enemy == "kamień")
                {
                    //papier na 5%, kamień 90%, nożyce 5%   
                    percentFirst = 5; percentSecond = percentFirst + 90;
                    showXY("Przegrywasz!");
                    computerCounter++;
                }
            }
        }

        static void showXY(string t, int left = 0, int top = 0)
        {
            if (left != 0 || top != 0)
                Console.SetCursorPosition(left, top);
            Console.WriteLine(t);
        }
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            char res; int amountGame;
            do
            {
                Console.Clear();
                computerCounter = 0; playerCounter = 0;
                showXY("Do ilu chcesz grać?");
                amountGame = int.Parse(Console.ReadLine());

                while (playerCounter < amountGame && computerCounter < amountGame)
                {
                    Console.Clear();
                    showCounter();
                    run();
                }

                showXY("Czy chcesz zagrać ponownie? (t/n)");
                res = char.Parse(Console.ReadLine());
            }
            while (res == 't' || res == 'T');
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            showXY("KONIEC GRY!", 12, 9);
            showXY("v wynik rundy v", 10, 10);
            showCounter();
        }
    }
}
