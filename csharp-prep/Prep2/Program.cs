<<<<<<< HEAD
        Console.Write("Enter your grade percentage: ");
        int percentage = int.Parse(Console.ReadLine());
        string letter = "";
        if (percentage >= 90)
        {
            letter = "A";
        }
        else if (percentage >= 80)
        {
            letter = "B";
        }
        else if (percentage >= 70)
        {
            letter = "C";
        }
=======
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Enter your grade percentage: ");
        int percentage = int.Parse(Console.ReadLine());
        string letter = "";
        if (percentage >= 95)
        {
            letter = "A+";
        }
        else if (percentage >= 92)
        {
            letter = "A";
        }
        else if (percentage >=89.75)
        {
            letter = "A-";
        }
        else if (percentage >= 85)
        {
            letter = "B+";
        }
        else if (percentage >= 82)
        {
            letter = "B";
        }
        else if (percentage >= 79.75)
        {
            letter = "B-";
        }
        else if (percentage >= 75)
        {
            letter = "C+";
        }
        else if (percentage >= 72)
        {
            letter = "C";
        }
        else if (percentage >= 69.89)
        {
            letter = "C-";
        }
>>>>>>> 0fed5b268f4f4e4eba0b53843d59ad8558c85142
        else if (percentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }
        Console.WriteLine($"Your grade is: {letter}");
<<<<<<< HEAD
        if (percentage >= 70)
=======
        if (percentage >= 69.89)
>>>>>>> 0fed5b268f4f4e4eba0b53843d59ad8558c85142
        {
            Console.WriteLine("Congratulations, you passed the course!");
        }
        else
        {
            Console.WriteLine("Don't give up, keep trying next time!");
<<<<<<< HEAD
        }
=======
        }
    }
}
>>>>>>> 0fed5b268f4f4e4eba0b53843d59ad8558c85142
