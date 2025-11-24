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

        //Chapter 2
        const string ThrowDice = "Lets throw the dice to kill it!";
        const string DiceOne = "   ________\n  /       /|   \n /_______/ |\n |       | |\n |   o   | /\n |       |/ \n '-------'\n";
        const string DiceTwo = "   ________\n  /       /|   \n /_______/ |\n |o      | |\n |       | /\n |      o|/ \n '-------'\n";
        const string DiceThree = "   ________\n  /       /|   \n /_______/ |\n |o      | |\n |   o   | /\n |      o|/ \n '-------'\n";
        const string DiceFour = "   ________\n  /       /|   \n /_______/ |\n |o     o| |\n |       | /\n |o     o|/ \n '-------'\n";
        const string DiceFive = "   ________\n  /       /|   \n /_______/ |\n |o     o| |\n |   o   | /\n |o     o|/ \n '-------'\n";
        const string DiceSix = "   ________\n  /       /|   \n /_______/ |\n |o     o| |\n |o     o| /\n |o     o|/ \n '-------'\n";
        const string CurrentHp = "Hp left: ";
        const string Defeat = "You managed to kill the monster";
        const string RollDice = "Press any key to roll the dice";
        const string TopLvl = "You are the maximum level possible";
        const string LevelUp = "Hurray! You leveled up!";
        const string ActualLevel = "Now you're level {0}";

        //Chapter 3
        const string DigColumn = "On what column do you wanna dig?";
        const string DigRow = "On what row do you wanna dig?";
        const string FoundGold = "You found a treasure!";
        const string NotFoundGold = "You found nothing..";
        const string OutOfBounds = "You can't dig outside the mine";
        const string Opentreasure = "You open all of your collected treasures and: ";
        const string NoTreasure = "You didn't find a single treasure..";
        const string ErrorDig = "Where are you even digging?";
        const string Money = "🪙";
        const string Dirt = "➖";
        const string Empty = "❌";
        const string TotalBit = "You got a total of {0} bits";
        const string CurrentBit = "Current bits: {0}";

        //Chapter 4
        const string OwnItems = "Owned items:";
        const string EmptyInv = "You have nothing in your inventory";

        //Chapter 5
        const string WelcomeShop = "Welcome to my shop";
        const string InfoShop = "Items \t\t\tPrice";
        const string AskBuy = "What would you like to buy";
        const string MoreMoney = "You need more bits to buy that";
        const string EnoughMoney = "You bought the item";
        const string ExitShop = "5. Exit shop";
        const string ErrorShop = "Don't make me lose my time, get out";
        const string WrongItem = "We don't have that item";

        string magename = "????";
        int lvlNow = 1, op = 0, xp, xpNow = 0, day, hours, selectMonster, dice, hp, i, j, column, row, digs, treasure, bits, bitsNow, totalBits = 0, rank = 0, item, shopping, answerShop, numScroll, numDecode, vowels, inv = 0;
        int minVal = 1, hourMax = 25, xpMax = 11, monsterMax = 8, monsterMin = 0, diceMax = 7, goldVal = 26, bitMin = 5, bitMax = 51;

        string[] rankMage = { "Guy with a stick", " Mage of a party for kids", "Fine person", "Normal mage", "Jesus Christ" };
        string[] monster = { "Wandering Skeleton 💀", "Forest Goblin 👹", "Green Slime 🟢", "Ember Wolf 🐺", "Giant Spider 🕷️", "Iron Golem 🤖", "Lost Necromancer 🧝‍♂️", "Ancient Dragon 🐉" };
        int[] monsterHp = { 3, 5, 10, 11, 18, 15, 20, 50 };
        string[] coordenates = { "  1.", "2.", "3.", "4.", "5." };
        string[,] mine = new string[5, 5];
        string[,] goldMine = new string[5, 5];
        string[] shop = { "Iron Dagger 🗡️", "Healing Potion ⚗️", "Ancient Key 🗝️", "Crossbow 🏹\t", "Metal Shield 🛡️" };
        int[] price = { 30, 10, 50, 40, 20 };
        string[] priceTwo = { "30", "10", "50", "40", "20" };
        string[][] spells =
        {
            new string[] {"Magic Spark 💫" },
            new string[] {"Fireball 🔥", "Ice Ray 🥏", "Arcane Shield ⚕️" },
            new string[] {"Meteor ☄️", "Pure Energy Explosion 💥", "Minor Charm 🎭", "Air Strike 🍃" },
            new string[] {"Wave of Light ⚜️", "Storm of Wings 🐦" },
            new string[] {"Cataclysm 🌋", "Portal of Chaos 🌀", "Arcane Blood Pact 🩸", "Elemental Storm ⛈️" }
        };
        string[] level = { "Level 1", "Level 2", "Level 3", "Level 4", "Level 5" };
        string[] scroll = { "The 🐲 sl33ps in the m0untain of fire 🔥", "Anci3nt magic fl0ws through the cry5tal caves", "Spell: Ignis 5 🔥, Aqua 6 💧, Terra 3 🌍, Ventus 8 🌪️" };
        bool[] decodeTypeOne = { false, false, false };
        bool[] decodeTypeTwo = { false, false, false };
        bool[] decodeTypeThree = { false, false, false };
        string[] decode = { "Decipher spell (remove spaces)", "Count magical runes (vowels)", "Extract secret code (numbers)" };
        char[] vowelsAll = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U', 'à', 'è', 'ì', 'ò', 'ù', 'á', 'é', 'í', 'ó', 'ú' };
        char[] numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        string[] inventory = new string[inv];

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
                case 2:
                    selectMonster = rnd.Next(monsterMin, monsterMax);

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    switch (selectMonster)
                    {
                        case 0:
                            Console.WriteLine($"{monster[selectMonster]} {monsterHp[selectMonster]} hp appears");
                            break;
                        case 1:
                            Console.WriteLine($"{monster[selectMonster]} {monsterHp[selectMonster]} hp appears");
                            break;
                        case 2:
                            Console.WriteLine($"{monster[selectMonster]} {monsterHp[selectMonster]} hp appears");
                            break;
                        case 3:
                            Console.WriteLine($"{monster[selectMonster]} {monsterHp[selectMonster]} hp appears");
                            break;
                        case 4:
                            Console.WriteLine($"{monster[selectMonster]} {monsterHp[selectMonster]} hp appears");
                            break;
                        case 5:
                            Console.WriteLine($"{monster[selectMonster]} {monsterHp[selectMonster]} hp appears");
                            break;
                        case 6:
                            Console.WriteLine($"{monster[selectMonster]} {monsterHp[selectMonster]} hp appears");
                            break;
                        case 7:
                            Console.WriteLine($"{monster[selectMonster]} {monsterHp[selectMonster]} hp appears");
                            break;
                    }

                    hp = monsterHp[selectMonster];
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(ThrowDice);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    while (hp > 0)
                    {
                        Console.WriteLine(CurrentHp + hp);
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine(RollDice);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.ReadKey();
                        dice = rnd.Next(minVal, diceMax);
                        switch (dice)
                        {
                            case 1:
                                Console.WriteLine(DiceOne);
                                hp = hp - 1;
                                break;
                            case 2:
                                Console.WriteLine(DiceTwo);
                                hp = hp - 2;
                                break;
                            case 3:
                                Console.WriteLine(DiceThree);
                                hp = hp - 3;
                                break;
                            case 4:
                                Console.WriteLine(DiceFour);
                                hp = hp - 4;
                                break;
                            case 5:
                                Console.WriteLine(DiceFive);
                                hp = hp - 5;
                                break;
                            case 6:
                                Console.WriteLine(DiceSix);
                                hp = -6;
                                break;
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(Defeat);
                    if (lvlNow < 5)
                    {
                        lvlNow++;
                        Console.WriteLine(LevelUp);
                        Console.WriteLine(ActualLevel, lvlNow);
                    }
                    else
                    {
                        Console.WriteLine(TopLvl);
                    }
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(PressToContinue);
                    Console.ReadKey();
                    break;
                case 3:

                    digs = 5;
                    treasure = 0;
                    bitsNow = 0;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    for (i = 0; i < coordenates.Length; i++)
                    {
                        Console.Write(coordenates[i]);
                    }
                    Console.WriteLine();
                    for (i = 0; i < mine.GetLength(0); i++)
                    {
                        Console.Write($"{i + 1}.");
                        for (j = 0; j < mine.GetLength(1); j++)
                        {
                            mine[i, j] = Dirt;
                            Console.Write($"{mine[i, j]}");
                        }
                        Console.WriteLine();
                    }

                    for (i = 0; i < goldMine.GetLength(0); i++)
                    {
                        for (j = 0; j < goldMine.GetLength(1); j++)
                        {
                            goldMine[i, j] = rnd.Next(minVal, goldVal) > 9 ? Empty : Money;
                        }
                    }

                    while (digs > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(DigColumn);
                        try
                        {
                            column = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine(ErrorDig);
                            column = -1;
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine(OutOfBounds);
                            column = -1;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine(ErrorDig);
                            column = -1;
                        }
                        column--;

                        Console.WriteLine(DigRow);
                        try
                        {
                            row = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine(ErrorDig);
                            row = -1;
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine(OutOfBounds);
                            row = -1;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine(ErrorDig);
                            row = -1;
                        }
                        row--;

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        if (row < 0 || row > 4 || column < 0 || column > 4)
                        {
                            Console.WriteLine(OutOfBounds);
                        }
                        else
                        {
                            if (goldMine[row, column].Equals(Money))
                            {
                                Console.WriteLine(FoundGold);
                                goldMine[row, column] = Empty;
                                mine[row, column] = Money;
                                digs--;
                                treasure++;
                            }
                            else
                            {
                                Console.WriteLine(NotFoundGold);
                                mine[row, column] = Empty;
                                digs--;
                            }
                        }
                        for (i = 0; i < coordenates.Length; i++)
                        {
                            Console.Write($" {coordenates[i]}");
                        }
                        Console.WriteLine();
                        for (i = 0; i < mine.GetLength(0); i++)
                        {
                            Console.Write($"{i + 1}.");
                            for (j = 0; j < mine.GetLength(1); j++)
                            {
                                Console.Write($" {mine[i, j]}");
                            }
                            Console.WriteLine();
                        }
                    }

                    if (treasure.Equals(0))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(NoTreasure);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(Opentreasure);
                        while (treasure != 0)
                        {
                            bits = rnd.Next(bitMin, bitMax);
                            Console.WriteLine($" You got {bits} bits");
                            bitsNow += bits;
                            treasure--;
                        }
                    }
                    totalBits += bitsNow;
                    Console.WriteLine(TotalBit, bitsNow);
                    Console.WriteLine(CurrentBit, totalBits);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(PressToContinue);
                    Console.ReadKey();
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(OwnItems);
                    if (inventory.Length < 1)
                    {
                        Console.WriteLine(EmptyInv);
                    }
                    else
                    {
                        for (i = 0; i < inventory.Length; i++)
                        {
                            Console.WriteLine(inventory[i]);
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(PressToContinue);
                    Console.ReadKey();
                    break;
                case 5:
                    shopping = 0;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(WelcomeShop);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    do
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(InfoShop);
                        for (i = 0; i < shop.Length; i++)
                        {
                            Console.WriteLine($"{i}. {shop[i]} \t{priceTwo[i]}");
                        }
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ExitShop);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(CurrentBit, totalBits);
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(AskBuy);
                        try
                        {
                            answerShop = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine(ErrorShop);
                            answerShop = 5;
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine(ErrorShop);
                            answerShop = 5;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine(ErrorShop);
                            answerShop = 5;
                        }
                        if (answerShop < 0 || answerShop > 5)
                        {
                            Console.WriteLine(WrongItem);
                        }
                        else if (answerShop < 5)
                        {
                            item = answerShop;

                            if (totalBits < price[item])
                            {
                                Console.WriteLine(MoreMoney);
                            }
                            else
                            {
                                Console.WriteLine(EnoughMoney);
                                string tempItem = shop[item];
                                string[] tempInv = new string[inventory.Length + 1];
                                for (i = 0; i < inventory.Length; i++)
                                {
                                    tempInv[i] = inventory[i];
                                }
                                tempInv[tempInv.Length - 1] = tempItem;
                                inventory = tempInv;
                                totalBits = totalBits - price[item];
                            }
                        }
                        else
                        {
                            shopping = 5;
                        }
                    } while (shopping != 5);
                    break;
            }
        } while (op != 0);
    }
}