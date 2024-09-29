        Random random = new Random();
        string playAgain;

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

        Console.WriteLine("Thanks for playing! Goodbye.");