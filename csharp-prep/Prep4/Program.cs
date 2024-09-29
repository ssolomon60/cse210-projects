        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (true)
        {
            Console.Write("Enter number: ");
            int input = int.Parse(Console.ReadLine());
            if (input == 0) break;
            numbers.Add(input);
        }

        if (numbers.Count > 0)
        {
            int sum = 0, max = numbers[0];
            int smallestPositive = int.MaxValue;
            List<int> positiveNumbers = new List<int>();

            foreach (int number in numbers)
            {
                sum += number;
                if (number > max) max = number;
                if (number > 0)
                {
                    positiveNumbers.Add(number);
                    if (number < smallestPositive) smallestPositive = number;
                }
            }

            Console.WriteLine($"The sum is: {sum}");
            Console.WriteLine($"The average is: {(double)sum / numbers.Count}");
            Console.WriteLine($"The largest number is: {max}");

            if (positiveNumbers.Count > 0)
            {
                positiveNumbers.Sort();
                Console.WriteLine($"The smallest positive number is: {smallestPositive}");
                Console.WriteLine("Sorted list of positive numbers: " + string.Join(", ", positiveNumbers));
            }
            else
            {
                Console.WriteLine("No positive numbers were entered.");
            }
        }
        else
        {
            Console.WriteLine("No numbers were entered.");
        }