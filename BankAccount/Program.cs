using System;
using System.Collections.Generic;
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
            Client client;
            string name;
            int selected;
            string answer;

            Console.WriteLine("Welcome to the Bank of North-South Kenya.");
            Console.WriteLine("Please enter the following information...");
            
            //Ask for name
            do
            {
                Console.Write("Name: ");
                name = Console.ReadLine();
                if(name == "")
                {
                    Console.WriteLine("I'm sorry, but you must enter something in as a name.");
                }
                else if(name.ToLower() == "doot")
                {
                    //Ignore: When transfering over to another computer, this will not work
                    //Doot();
                }
            } while (name == "");

            Console.WriteLine("Welcome " + name + ". We'll set up an account for you right away.");
            Console.WriteLine("Establishing a new savings and checking account.");
            client = new Client(name);

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
                if(!int.TryParse(Console.ReadLine(), out selected))
                {
                    Console.WriteLine("I'm sorry, that is not an acceptable response.");
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
                        break;
                }
                Console.WriteLine();
            } while (selected != 5);
        }
        public static void Doot()
        {
            SoundPlayer simpleSound = new SoundPlayer();
            simpleSound.SoundLocation = @"C:\Users\WeCanCodeIT\Documents\Visual Studio 2015\Projects\BankAccount\BankAccount\Properties\doot.wav";
            simpleSound.PlaySync();
        }
    }
}
