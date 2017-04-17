using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating required variables
            Client client;
            int selected;
            string answer;

            Console.WriteLine("Welcome to the Bank of North-South Kenya.");
            Console.WriteLine("Please enter the following information...");
            
            //Ask for name
            do
            {
                Console.Write("Name: ");
                answer = Console.ReadLine();
                if(answer == "")
                {
                    Console.WriteLine("I'm sorry, but you must enter something in as a name.");
                }
            } while (answer == "");

            client = new Client(answer);
            Console.WriteLine("Welcome " + client.Name + ". We'll set up an account for you right away.");
            Console.WriteLine("Establishing a new savings and checking account.");

            //This do while loop will keep on going until the user quits
            do
            {
                //Prompts the user what to do
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1: Check client information");
                Console.WriteLine("2: Check account information");
                Console.WriteLine("3: Deposit");
                Console.WriteLine("4: Withdraw");
                Console.WriteLine("5: Quit");
                Console.Write("\n> ");

                //Parses whatever the user types in
                answer = Console.ReadLine();
                if (!int.TryParse(answer, out selected) && answer.ToLower() == "doot")
                {
                    //Secret easter egg!
                    //If the program crashes if the user puts in "doot", then the Doot() method still doesn't work
                    //You can only experience this feature if you have the sound on
                    Doot();
                }
                else
                {
                    Console.WriteLine();
                }

                switch (selected)
                {
                    //Client info
                    case 1:
                        client.ClientInfo();
                        break;

                    //Check account info
                    case 2:
                        do
                        {
                            Console.WriteLine("Which account would you like to access?");
                            Console.WriteLine("a: Checking");
                            Console.WriteLine("b: Saving");
                            Console.Write("\n> ");
                            answer = Console.ReadLine();
                            client.AccountInfo(answer);
                        } while (answer.ToLower() != "a" && answer.ToLower() != "b");
                        break;

                    //Depositing
                    case 3:
                        do
                        {
                            Console.WriteLine("Which account would you like to access?");
                            Console.WriteLine("a: Checking");
                            Console.WriteLine("b: Saving");
                            Console.Write("\n> ");
                            answer = Console.ReadLine();
                            float result;
                            //Is answer a?
                            if (answer.ToLower() == "a")
                            {
                                Console.WriteLine("How much would you like to add?");
                                Console.Write("\n> $");
                                if (float.TryParse(Console.ReadLine(), out result))
                                {
                                    client.Checking.Deposit(result);
                                }
                                else
                                {
                                    Console.WriteLine("I'm sorry, that is not a acceptable response.");
                                }
                            }
                            //Is it b?
                            else if (answer.ToLower() == "b")
                            {
                                Console.WriteLine("How much would you like to add?");
                                Console.Write("\n> $");
                                if (float.TryParse(Console.ReadLine(), out result))
                                {
                                    client.Savings.Deposit(result);
                                }
                                else
                                {
                                    Console.WriteLine("I'm sorry, that is not a acceptable response.");
                                }
                            }
                            //Not a valid answer
                            else
                            {
                                Console.WriteLine("I'm sorry, that's not a valid answer.\n");
                            }
                        } while (answer.ToLower() != "a" && answer.ToLower() != "b");
                        break;

                    //Withdrawing
                    case 4:
                        do
                        {
                            Console.WriteLine("Which account would you like to access?");
                            Console.WriteLine("a: Checking");
                            Console.WriteLine("b: Saving");
                            Console.Write("\n> ");
                            answer = Console.ReadLine();
                            float result;
                            //Is answer a?
                            if (answer.ToLower() == "a")
                            {
                                Console.WriteLine("How much would you like to withdraw?");
                                Console.Write("\n> $");
                                if (float.TryParse(Console.ReadLine(), out result))
                                {
                                    client.Checking.Withdraw(result);
                                }
                                else
                                {
                                    Console.WriteLine("I'm sorry, that is not a acceptable response.");
                                }
                            }
                            //Is it b?
                            else if (answer.ToLower() == "b")
                            {
                                Console.WriteLine("How much would you like to withdraw?");
                                Console.Write("\n> $");
                                if (float.TryParse(Console.ReadLine(), out result))
                                {
                                    client.Savings.Withdraw(result);
                                }
                                else
                                {
                                    Console.WriteLine("I'm sorry, that is not a acceptable response.");
                                }
                            }
                            //Not a valid answer
                            else
                            {
                                Console.WriteLine("I'm sorry, that's not a valid answer.\n");
                            }
                        } while (answer.ToLower() != "a" && answer.ToLower() != "b");
                        break;
                    case 5:
                        Console.WriteLine("Thank you for doing business with us.");
                        break;
                    default:
                        if (answer.ToLower() != "doot")
                        {
                            Console.WriteLine("I'm sorry, that's not a valid response");
                        }
                        break;
                }
                Console.WriteLine();
            } while (selected != 5);
        }

        //This was a pain to set up, but I believe it works. Maybe?
        //I intended for this to be able to reach the sound file even if the location of the program is different
        public static void Doot()
        {
            SoundPlayer simpleSound = new SoundPlayer();
            
            //getting root path of the .exe program
            string rootLocation = typeof(Program).Assembly.Location;

            //Cut the root location so it only goes so far to the second "BankAccount" file
            rootLocation = rootLocation.Substring(0,rootLocation.LastIndexOf("BankAccount", rootLocation.LastIndexOf("BankAccount") - 1));

            // Getting the full sound location
            simpleSound.SoundLocation = Path.Combine(rootLocation, @"BankAccount\Properties\doot.wav");

            simpleSound.PlaySync();
        }
    }
}
