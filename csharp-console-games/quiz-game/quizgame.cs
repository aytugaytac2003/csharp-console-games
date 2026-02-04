using System;
using System.Collections.Generic;

class Question
{
    public string Text { get; set; }
    public List<string> Options { get; set; }
    public int CorrectAnswerIndex { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        List<Question> questions = new List<Question>
        {
            new Question
            {
                Text = "C# hangi programlama paradigmasını destekler?",
                Options = new List<string> { "Procedural", "Object-Oriented", "Functional", "All of the above" },
                CorrectAnswerIndex = 3
            },
            new Question
            {
                Text = "Which keyword is used to create a class in C#?",
                Options = new List<string> { "class", "struct", "object", "new" },
                CorrectAnswerIndex = 0
            },
            new Question
            {
                Text = "Which data type is used to store true or false?",
                Options = new List<string> { "int", "string", "bool", "char" },
                CorrectAnswerIndex = 2
            }
        };

        int score = 0;

        Console.WriteLine("Welcome to the Quiz Game!");
        Console.WriteLine("----------------------------");

        foreach (var question in questions)
        {
            Console.WriteLine($"\n{question.Text}");

            for (int i = 0; i < question.Options.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {question.Options[i]}");
            }

            Console.Write("Your answer (1-4): ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int answer))
            {
                if (answer - 1 == question.CorrectAnswerIndex)
                {
                    Console.WriteLine("Correct!");
                    score++;
                }
                else
                {
                    Console.WriteLine("Wrong!");
                }
            }
            else
            {
                Console.WriteLine("Invalid input!");
            }
        }

        Console.WriteLine($"\n Quiz finished! Your score: {score}/{questions.Count}");
        Console.WriteLine("Thanks for playing!");
    }
}
