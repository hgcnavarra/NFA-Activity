using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string again;

        do
        {
            Console.Write("Enter string: ");
            string input = Console.ReadLine();

            // Start state
            HashSet<string> states = new HashSet<string>();
            states.Add("q0");

            // Store the path of each possible state
            Dictionary<string, string> paths =
                new Dictionary<string, string>();

            paths["q0"] = "q0";

            // Read the input one character at a time
            for (int i = 0; i < input.Length; i++)
            {
                char symbol = input[i];

                HashSet<string> nextStates =
                    new HashSet<string>();

                Dictionary<string, string> nextPaths =
                    new Dictionary<string, string>();

                foreach (string state in states)
                {
                    // q0 --/--> q1
                    if (state == "q0" && symbol == '/')
                    {
                        nextStates.Add("q1");
                        nextPaths["q1"] =
                            paths[state] + " --/--> q1";
                    }

                    // q1 --*--> q2
                    if (state == "q1" && symbol == '*')
                    {
                        nextStates.Add("q2");
                        nextPaths["q2"] =
                            paths[state] + " --*--> q2";
                    }

                    // q2 --h--> q2
                    if (state == "q2" && symbol == 'h')
                    {
                        nextStates.Add("q2");

                        if (!nextPaths.ContainsKey("q2"))
                        {
                            nextPaths["q2"] =
                                paths[state] + " --h--> q2";
                        }
                    }

                    // q2 --/--> q2
                    if (state == "q2" && symbol == '/')
                    {
                        nextStates.Add("q2");

                        if (!nextPaths.ContainsKey("q2"))
                        {
                            nextPaths["q2"] =
                                paths[state] + " --/--> q2";
                        }
                    }

                    // q2 --*--> q3
                    if (state == "q2" && symbol == '*')
                    {
                        nextStates.Add("q3");

                        if (!nextPaths.ContainsKey("q3"))
                        {
                            nextPaths["q3"] =
                                paths[state] + " --*--> q3";
                        }
                    }

                    // q2 --*--> q5
                    if (state == "q2" && symbol == '*')
                    {
                        nextStates.Add("q5");

                        if (!nextPaths.ContainsKey("q5"))
                        {
                            nextPaths["q5"] =
                                paths[state] + " --*--> q5";
                        }
                    }

                    // q3 --h--> q2
                    if (state == "q3" && symbol == 'h')
                    {
                        nextStates.Add("q2");

                        if (!nextPaths.ContainsKey("q2"))
                        {
                            nextPaths["q2"] =
                                paths[state] + " --h--> q2";
                        }
                    }

                    // q3 --*--> q3
                    if (state == "q3" && symbol == '*')
                    {
                        nextStates.Add("q3");

                        if (!nextPaths.ContainsKey("q3"))
                        {
                            nextPaths["q3"] =
                                paths[state] + " --*--> q3";
                        }
                    }

                    // q3 --/--> q4
                    if (state == "q3" && symbol == '/')
                    {
                        nextStates.Add("q4");

                        if (!nextPaths.ContainsKey("q4"))
                        {
                            nextPaths["q4"] =
                                paths[state] + " --/--> q4";
                        }
                    }

                    // q5 --h--> q2
                    if (state == "q5" && symbol == 'h')
                    {
                        nextStates.Add("q2");

                        if (!nextPaths.ContainsKey("q2"))
                        {
                            nextPaths["q2"] =
                                paths[state] + " --h--> q2";
                        }
                    }

                    // q5 --*--> q3
                    if (state == "q5" && symbol == '*')
                    {
                        nextStates.Add("q3");

                        if (!nextPaths.ContainsKey("q3"))
                        {
                            nextPaths["q3"] =
                                paths[state] + " --*--> q3";
                        }
                    }
                }

                states = nextStates;
                paths = nextPaths;

                // No possible NFA path remains
                if (states.Count == 0)
                {
                    break;
                }
            }

            Console.WriteLine("\nStates:");

            // q4 is the accepting state
            if (states.Contains("q4"))
            {
                Console.WriteLine(paths["q4"]);
                Console.WriteLine("\nAccepted");
            }
            else
            {
                Console.WriteLine("No accepting path.");
                Console.WriteLine("\nRejected");
            }

            Console.Write("\nDo you want to enter another string? (y/n): ");
            again = Console.ReadLine().ToLower();

            Console.WriteLine();

        } while (again == "y");

        Console.WriteLine("Program ended.");
    }
}