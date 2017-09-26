using System;

namespace Uppgift_5
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // Initiering av klassen "Backpack"
            Backpack backpack = new Backpack();

            // Boolesk variabel för att avsluta programmet/loopen
            bool continueProgram = true;

            while(continueProgram)
            {
                Console.WriteLine("[1] Lägg till ett föremål.\n" +
                                  "[2] Skriv ut innehåll.\n" +
                                  "[3] Sök i ryggsäcken.\n" +
                                  "[4] Rensa innehåll.\n" + 
                                  "[5] Avsluta.\n");
                
                Console.Write("Menyval: ");

                try
                {
                    // Deklarerar heltals-variabeln "menuChoise" för användarens menyval
                    int menuChoise;

                    // Tryparse metoden för att hantera felaktig inmatning. Skickar ut 0 om något annat än heltal
                    // 
                    //Fråga:
                    // Skriver man bokstäver osv tilldelas menuChoise 0. 
                    // Eftersom jag använder default i switch-menyn får man väl aldrig ett undantag?
                    Int32.TryParse(Console.ReadLine(), out menuChoise);

                    // Rensar konsolen på text
                    Console.Clear();

                    switch (menuChoise)
                    {
                        case 1:
                            backpack.AddItem();
                            break;
                        case 2:
                            backpack.DisplayContent();
                            break;
                        case 3:
                            backpack.SearchItem();
                            break;
                        case 4:
                            backpack.ClearContent();
                            break;
                        case 5:
                            continueProgram = false;
                            break;
                        default:
                            Console.WriteLine("Du kan bara välja mellan 1 - 5!");
                            break;
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message); 
                }
            }
        }
    }
}
