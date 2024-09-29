        Random random = new Random();
        string playAgain;

<<<<<<< HEAD
=======
class Program
{
    static void Main(string[] args)
    {
                Random random = new Random();
        string playAgain;

>>>>>>> 0fed5b268f4f4e4eba0b53843d59ad8558c85142
        do
        {
            int magicNumber = random.Next(1, 101), guessCount = 0, guess;
            Console.WriteLine("I have picked a magic number between 1 and 100. Try to guess it!");

            do
            {
                Console.Write("Your guess: ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;

                Console.WriteLine(guess < magicNumber ? "Higher" : guess > magicNumber ? "Lower" : $"You guessed it in {guessCount} guesses!");

            } while (guess != magicNumber);

            Console.Write("Play again? (yes/no): ");
            playAgain = Console.ReadLine().Trim().ToLower();

        } while (playAgain == "yes");

<<<<<<< HEAD
        Console.WriteLine("Thanks for playing! Goodbye.");
=======
        Console.WriteLine("Thanks for playing! Goodbye.");
    }
}
>>>>>>> 0fed5b268f4f4e4eba0b53843d59ad8558c85142
