using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    const string FileName = "characters.txt";

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\nSuper Mario Characters App");
            Console.WriteLine("1. Add character");
            Console.WriteLine("2. Display all characters");
            Console.WriteLine("3. Exit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddCharacter();
                    break;
                case "2":
                    DisplayCharacters();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }

    static void AddCharacter()
    {
        Console.Write("Enter Id: ");
        string id = Console.ReadLine();
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();
        Console.Write("Enter Relationship to Mario: ");
        string relationship = Console.ReadLine();

        string line = $"{id},{name},{relationship}";
        File.AppendAllText(FileName, line + Environment.NewLine);
        Console.WriteLine("Character added successfully.");
    }

    static void DisplayCharacters()
    {
        if (!File.Exists(FileName))
        {
            Console.WriteLine("No characters saved yet.");
            return;
        }

        string[] lines = File.ReadAllLines(FileName);
        int count = 0;
        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            string[] parts = line.Split(',');
            if (parts.Length == 3)
            {
                Console.WriteLine($"Id: {parts[0]}\nName: {parts[1]}\nRelationship to Mario: {parts[2]}\n");
                count++;
            }
        }
        Console.WriteLine($"{count} character{(count == 1 ? "" : "s")} saved to file.");
    }
}
