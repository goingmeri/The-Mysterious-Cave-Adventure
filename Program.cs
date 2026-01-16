// Text-Based Adventure Game with Number Guessing Challenge
using System;

class Program
{
    static int difficultyLevel = 3; // Default: 3 attempts

    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("╔════════════════════════════════════════╗");
        Console.WriteLine("║   THE MYSTERIOUS CAVE ADVENTURE        ║");
        Console.WriteLine("║   Version 2.0 - TEMPORARY CHANGE       ║");
        Console.WriteLine("╔════════════════════════════════════════╗");
        Console.ResetColor();
        Console.WriteLine();

        SelectDifficulty();
        StartAdventure();
    }

    static void SelectDifficulty()
    {
        Console.WriteLine("Select your difficulty level:");
        Console.WriteLine("1. Easy (5 attempts for puzzles)");
        Console.WriteLine("2. Normal (3 attempts for puzzles)");
        Console.WriteLine("3. Hard (2 attempts for puzzles)");
        
        string choice = GetPlayerChoice(3);
        
        difficultyLevel = choice switch
        {
            "1" => 5,
            "2" => 3,
            "3" => 2,
            _ => 3
        };
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n✓ Difficulty set! You'll have {difficultyLevel} attempts for challenges.\n");
        Console.ResetColor();
    }

    static void StartAdventure()
    {
        Console.WriteLine("You wake up at the entrance of a dark, mysterious cave.");
        Console.WriteLine("Strange sounds echo from within...\n");
        
        Console.WriteLine("What do you do?");
        Console.WriteLine("1. Enter the cave bravely");
        Console.WriteLine("2. Look around the entrance first");
        Console.WriteLine("3. Run away");
        
        string choice = GetPlayerChoice(3);

        switch (choice)
        {
            case "1":
                EnterCave();
                break;
            case "2":
                LookAround();
                break;
            case "3":
                RunAway();
                break;
        }
    }

    static void EnterCave()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("\n🕯️  You step into the darkness...\n");
        Console.ResetColor();
        
        Console.WriteLine("As your eyes adjust, you see two paths:");
        Console.WriteLine("1. A narrow tunnel with glowing crystals");
        Console.WriteLine("2. A wide passage with strange markings");
        
        string choice = GetPlayerChoice(2);

        if (choice == "1")
        {
            CrystalTunnel();
        }
        else
        {
            MarkedPassage();
        }
    }

    static void CrystalTunnel()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\n✨ The crystals illuminate your path...\n");
        Console.ResetColor();
        
        Console.WriteLine("You find a mystical guardian blocking your way!");
        Console.WriteLine("'Solve my riddle to pass,' it says.\n");
        
        bool solved = NumberGuessingChallenge();
        
        if (solved)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n🎉 The guardian steps aside, revealing a treasure chest!");
            Console.WriteLine("You found 1000 gold coins and a magical sword!");
            Console.WriteLine("\n✨ VICTORY! You've completed the adventure! ✨");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n💀 The guardian casts a spell, teleporting you back outside.");
            Console.WriteLine("GAME OVER - Better luck next time!");
            Console.ResetColor();
        }
    }

    static void MarkedPassage()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("\n⚠️  The markings glow ominously...\n");
        Console.ResetColor();
        
        Console.WriteLine("You trigger an ancient trap!");
        Console.WriteLine("Arrows fly from the walls!");
        Console.WriteLine("\nQuick! What do you do?");
        Console.WriteLine("1. Duck and roll forward");
        Console.WriteLine("2. Run back the way you came");
        
        string choice = GetPlayerChoice(2);

        if (choice == "1")
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n🎯 You narrowly dodge the arrows!");
            Console.ResetColor();
            Console.WriteLine("You find a small pouch with 100 gold coins.");
            Console.WriteLine("You escape safely through a side exit.");
            Console.WriteLine("\n✨ SUCCESS! You survived the cave! ✨");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n💔 An arrow grazes your leg as you flee.");
            Console.WriteLine("You make it out, but empty-handed.");
            Console.WriteLine("GAME OVER");
            Console.ResetColor();
        }
    }

    static void LookAround()
    {
        Console.Clear();
        Console.WriteLine("\n🔍 You search the area carefully...\n");
        Console.WriteLine("You find an old map showing a safe path through the cave!");
        Console.WriteLine("Armed with knowledge, you enter confidently.\n");
        
        Console.WriteLine("Following the map, you navigate safely to a hidden chamber.");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("You discover an ancient artifact worth 500 gold!");
        Console.WriteLine("\n✨ SMART CHOICE! You win! ✨");
        Console.ResetColor();
    }

    static void RunAway()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("\n🏃 You run away from the cave...\n");
        Console.WriteLine("Sometimes discretion is the better part of valor.");
        Console.WriteLine("You live to adventure another day!");
        Console.WriteLine("\nGAME OVER - Safe, but no treasure.");
        Console.ResetColor();
    }

    static bool NumberGuessingChallenge()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("═══════════════════════════════════════");
        Console.WriteLine("  NUMBER GUESSING CHALLENGE");
        Console.WriteLine("═══════════════════════════════════════");
        Console.ResetColor();
        
        Random random = new Random();
        int secretNumber = random.Next(1, 11);
        int attempts = difficultyLevel; // Use difficulty setting
        
        Console.WriteLine("I'm thinking of a number between 1 and 10.");
        Console.WriteLine($"You have {attempts} attempts to guess it!\n");

        for (int i = 1; i <= attempts; i++)
        {
            Console.Write($"Attempt {i}/{attempts}: Enter your guess: ");
            
            if (int.TryParse(Console.ReadLine(), out int guess))
            {
                if (guess == secretNumber)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"🎯 Correct! The number was {secretNumber}!");
                    Console.ResetColor();
                    return true;
                }
                else if (guess < secretNumber)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("📈 Too low! Try higher.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("📉 Too high! Try lower.");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Invalid input! That counts as an attempt.");
                Console.ResetColor();
            }
        }
        
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n❌ Out of attempts! The number was {secretNumber}.");
        Console.ResetColor();
        return false;
    }

    static string GetPlayerChoice(int maxOptions)
    {
        while (true)
        {
            Console.Write("\nYour choice: ");
            string input = Console.ReadLine();
            
            if (int.TryParse(input, out int choice) && choice >= 1 && choice <= maxOptions)
            {
                return choice.ToString();
            }
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"❌ Please enter a number between 1 and {maxOptions}.");
            Console.ResetColor();
        }
    }
}
