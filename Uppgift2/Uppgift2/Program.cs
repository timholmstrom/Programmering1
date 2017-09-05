using System;
using System.Collections.Generic;

namespace Uppgift2
{
	class MainClass
	{
        // The variable myPack holds the class Backack
        public static Backpack myPack = new Backpack();

		public static void Main(string[] args)
		{
            // Bool for quitting program and for the first run
			bool quitProgram = false;
			bool firstRun = true;

			while (!quitProgram)
			{
				try
				{
                    if (firstRun) { Console.WriteLine("Välkommen till ryggsäcken!"); }

                    Console.WriteLine("\n[1] Lägg till ett föremål" +
									  "\n[2] Visa innehållet i ryggsäcken" +
									  "\n[3] Ta bort ett föremål" +
									  "\n[4] Töm ryggsäcken" +
									  "\n[5] Avsluta\n");

					Console.Write("Välj: ");
					int choise = Convert.ToInt32(Console.ReadLine());

                    // Setting firstRun to false
					firstRun = false;

                    // Clearing the console
					Console.Clear();

					switch (choise)
					{
						case 1:
                            // Calling method "AddToBackpack"
                            AddToBackpack();
							break;

						case 2:
                            // Calling method "PrintContent", passing the method "GetContent" from "myPack"
                            PrintContent(myPack.GetContent());
							break;

						case 3:
                            // Calling method "RemoveSomething"
                            RemoveSomething();
							break;

						case 4:
                            // Calling method "EmptyBackpack" from "myPack"
                            myPack.EmptyBackpack();
							break;

						case 5:
                            // Set variable "quitProgram" to true, break the loop and quit
							quitProgram = true;
							break;

                        default:
                            throw new Exception("Du kan bara välja ett nummer mellan 1 - 5!\n");
					}
				}
                catch(FormatException)
                {
                    Console.Clear();

                    // If using the wrong format for values
                    Console.WriteLine("Du måste ange rätt värden!");
                }
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}
		}

        // Ask user for what to put in the backpack, calls AddItem from myPack, passes in name as argument
        public static void AddToBackpack()
        {
            Console.Write("Vad vill du lägga till: ");
            string name = Console.ReadLine();

            myPack.AddItem(name);
        }

        // Prints the items to the console, with weight and quantity
        public static void PrintContent(List<Item> content)
        {
            Console.WriteLine("Din ryggsäck innehåller:\n");

            float itemWeights = 0;

            foreach (Item item in content)
            {
                Console.WriteLine("{0} {1} som väger: {2}kg", item.Quantity, item.Name, (item.Weight * item.Quantity));
                itemWeights += item.Weight * item.Quantity;
            }

            myPack.BackpackWeight = itemWeights;
            Console.WriteLine("\nDin ryggsäck väger sammanlagt {0}kg.", myPack.BackpackWeight);
        }

        // If myPack is not empty, ask user what to remove
        // Calls the method RemoveItem from myPack, passes itemToRemove as argument
        public static void RemoveSomething()
        {
            if (myPack.IsPackEmpty())
            {
                throw new Exception("Du kan inte ta bort något. Din ryggsäck är tom!");
            }

            Console.Write("Vad vill du ta från din ryggsäck: ");
            string itemToRemove = Console.ReadLine();

            myPack.RemoveItem(itemToRemove);
        }
    }
}
