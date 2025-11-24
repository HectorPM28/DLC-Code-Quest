using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Globalization;
using System.Reflection.Emit;

public class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;

        //Chapter 0
        const string MenuTitle = "===== MAIN MENU - CODEQUEST =====";
        const string MenuOption1 = "1. Train your wizard";
        const string MenuOption2 = "2. Increase LVL";
        const string MenuOption3 = "3. Loot the mine";
        const string MenuOption4 = "4. Show inventory";
        const string MenuOption5 = "5. Buy items";
        const string MenuOption6 = "6. Show attacks by LVL";
        const string MenuOption7 = "7. Decode ancient Scroll";
        const string MenuOptionExit = "0. Exit game";
        const string MenuPrompt = "Choose an option (1-7) - (0) to exit: ";
        const string InputErrorMessage = "Invalid input. Please enter a number between 0 and 7.";
        const string CreateMage = "Before anything, what's your name?";
        const string Present = "Hi ";
        const string Sides = "=========================================================";
        const string PressToContinue = "Press any key to continue";
        const string BeSomething = "Since you don't want to, i'll give you a name";
        const string Welcome = "Welcome {0} the {1} with level {2}";

        //Chapter 1
        const string StartTrain = "Now let's get started with the training!";
        const string CurrentXp = "After all that hard work you managed to get ";
        const string LowLvl = "Finding a stick doesn't make you a wizard";
        const string MidLvl = "Good job, you can Wingardium Leviosa your enemies";
        const string FineLvl = "You're good enough";
        const string HighLvl = "Oh my you can actually fight with that level";
        const string MaxLvl = "Your name will be in the history as the one who should not be named";
        const string AfterTrain = "After training for {0} hours, you got {1} xp";

        string magename = "????";
        int lvlNow = 1, op = 0, xp, xpNow = 0, day, hours, selectMonster, dice, hp, i, j, column, row, digs, treasure, bits, bitsNow, totalBits = 0, rank = 0, item, shopping, answerShop, numScroll, numDecode, vowels, inv = 0;
        int minVal = 1, hourMax = 25, xpMax = 11, monsterMax = 8, monsterMin = 0, diceMax = 7, goldVal = 26, bitMin = 5, bitMax = 51;

        string[] rankMage = { "Guy with a stick", " Mage of a party for kids", "Fine person", "Normal mage", "Jesus Christ" };

        Random rnd = new Random();


        do
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(MenuTitle);
            Console.WriteLine(Welcome, magename, rankMage[rank], lvlNow);
            Console.WriteLine(MenuOption1);
            Console.WriteLine(MenuOption2);
            Console.WriteLine(MenuOption3);
            Console.WriteLine(MenuOption4);
            Console.WriteLine(MenuOption5);
            Console.WriteLine(MenuOption6);
            Console.WriteLine(MenuOption7);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(MenuOptionExit);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(MenuPrompt);

            try
            {
                op = Convert.ToInt32(Console.ReadLine());

            }
            catch (FormatException)
            {
                Console.WriteLine(InputErrorMessage);
                op = -1;
            }
            catch (Exception)
            {
                Console.WriteLine(InputErrorMessage);
                op = -1;
            }

            switch (op)
            {

                case 1:
                    Console.ForegroundColor = ConsoleColor.Green;
                    if (magename.Equals("????"))
                    {
                        Console.WriteLine(Sides);
                        Console.WriteLine(CreateMage);
                        Console.WriteLine(Sides);
                        magename = Console.ReadLine();

                        if (magename.Equals(""))
                        {
                            Console.WriteLine(BeSomething);
                            magename = "Dumbass";
                        }

                        magename = magename.Substring(0, 1).ToUpper().Trim() + magename.Substring(1).ToLower().Trim();
                    }

                    Console.WriteLine(Sides);
                    Console.WriteLine($"{Present}{magename} lvl {lvlNow}");
                    Console.WriteLine(StartTrain);
                    Console.WriteLine(Sides);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    day = 0;
                    while (day != 5)
                    {
                        hours = rnd.Next(minVal, hourMax);
                        xp = rnd.Next(minVal, xpMax);
                        xpNow += xp;
                        Console.WriteLine(AfterTrain, hours, xp);
                        day++;
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(Sides);
                    Console.WriteLine($"{CurrentXp}{xpNow} xp");
                    Console.WriteLine(Sides);
                    switch (xpNow)
                    {
                        case <= 20:
                            rank = 0;
                            Console.WriteLine(LowLvl);
                            Console.WriteLine($"Rank: {rankMage[rank]}");
                            Console.WriteLine(Sides);
                            break;
                        case < 30:
                            rank = 1;
                            Console.WriteLine(MidLvl);
                            Console.WriteLine($"Rank: {rankMage[rank]}");
                            Console.WriteLine(Sides);
                            break;
                        case < 35:
                            rank = 2;
                            Console.WriteLine(FineLvl);
                            Console.WriteLine($"Rank: {rankMage[rank]}");
                            Console.WriteLine(Sides);
                            break;
                        case < 41:
                            rank = 3;
                            Console.WriteLine(HighLvl);
                            Console.WriteLine($"Rank: {rankMage[rank]}");
                            Console.WriteLine(Sides);
                            break;
                        case >= 40:
                            rank = 4;
                            Console.WriteLine(MaxLvl);
                            Console.WriteLine($"Rank: {rankMage[rank]}");
                            Console.WriteLine(Sides);
                            break;
                    }
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(PressToContinue);
                    Console.ReadKey();
                    break;
            }
        } while (op != 0);
    }
}
