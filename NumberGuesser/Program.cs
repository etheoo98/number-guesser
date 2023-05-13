namespace NumberGuesser;

internal class NumberGuesser
{
    private static void Main()
    {
        // Set the number of guesses allowed for a close guess
        const int closeGuess = 5;

        // Start the game loop
        do
        {
            // Clear any previous output
            Console.Clear();
            // Generate a random number between 1 and 100
            var randomizer = new Random();
            var secretNumber = randomizer.Next(1, 101);

            // Initialize the guess count and previous guess variables
            var guessCount = 0;
            var previousGuess = -1;

            // Start the game message
            Console.WriteLine("I'm going to think of a number between 1 and 100, that you are going to try and guess.");

            // Start the game loop
            while (true)
            {
                // Prompt the user for their guess
                Console.Write("Enter a number (1-100): ");
                var input = Console.ReadLine();

                // If input is a valid integer between 1 and 100
                if (int.TryParse(input!, out var userGuess) && userGuess is >= 1 and <= 100)
                {
                    // Increment the guess count
                    guessCount++;

                    // If the user guess is too low
                    if (userGuess < secretNumber && Math.Abs(userGuess - secretNumber) > closeGuess)
                    {
                        Console.WriteLine("Your guess is too low. Try again.");
                    }
                    // If the user guess is too high
                    else if (userGuess > secretNumber && Math.Abs(userGuess - secretNumber) > closeGuess)
                    {
                        Console.WriteLine("Your guess is too high. Try again.");
                    }
                    // If the user guess is within 5 numbers of the secret number
                    else if (Math.Abs(userGuess - secretNumber) <= closeGuess && userGuess != secretNumber)
                    {
                        // If this is the first guess, output a message without comparing to the previous guess
                        if (previousGuess == -1)
                        {
                            Console.WriteLine("You're getting close!");
                        }
                        // Otherwise, compare to the previous guess
                        else
                        {
                            // Calculate the differences between the current and previous guess and the secret number
                            var prevDifference = Math.Abs(previousGuess - secretNumber);
                            var currentDifference = Math.Abs(userGuess - secretNumber);

                            // Output a message indicating whether the user is getting closer or further from the secret number
                            Console.WriteLine(currentDifference < prevDifference
                                ? "You're getting closer!"
                                : "You're getting further away");
                        }

                        // Set the previous guess variable to the current guess
                        previousGuess = userGuess;
                    }
                    // If the user guess is correct
                    else
                    {
                        // Output a message indicating the number of guesses it took to guess the correct number
                        Console.WriteLine($"Congratulations! You guessed the secret number in {guessCount} tries.");
                        // Exit the loop after a correct guess
                        break;
                    }
                }
                else
                {
                    // Output an error message if the user input is invalid
                    Console.WriteLine("Error: The input must be a whole number between 1 and 100. Please try again.");
                }
            }

            // Ask the user if they want to play again
            Console.WriteLine("Do you want to play again? (Y/n)");

            // Keep looping until the user enters 'n'
        } while (Console.ReadKey().KeyChar != 'n');
    }
}