using System;
namespace Uppgift_5
{
    public class Backpack
    {
        // Text-vektor för att hålla 5 text-variabler
        string[] content = new string[5];

        // Heltals-variabel för att hålla reda på vilket index som är ledigt i "content"-vektorn
        // 
        //Fråga:
        // Kan man tilldela värden i vektorer på ett bättre sätt utan att skriva över något värde?
        // I detta fall skulle man också kunna loopa igenom vektorn och se ifall index-värdet är null och bara tilldela då
        int emptyIndex = 0;

        // Metod för att lägga till föremål i ryggsäcken
        public void AddItem()
        {
            // Kollar om ryggsäcken är full
            if(IsFull())
            {
                throw new Exception("Din ryggsäck är full!\n");
            }
         
            Console.Write("Föremål att lägga till: ");

            // Tilldelar användarens text till en tom index-plats i vektorn
            content[emptyIndex] = Console.ReadLine();

            // Öka variabeln med 1 för nästa inläsning
            emptyIndex++;

            Console.WriteLine();
        }

        // Metod för att skriva ut innehållet i ryggsäcken
        public void DisplayContent()
        {
            // Kollar om ryggsäcken är tom
            if(IsEmpty())
            {
                throw new Exception("Din ryggsäck är tom!\n");
            }

            Console.WriteLine("Din ryggsäck innehåller: ");

            // For-loopen går igenom varje variabel i vektorn och skriver ut om variabeln inte är lika med "null"
            for (int i = 0; i < content.Length; i++)
            {
                if(content[i] != null)
                {
                    // Skriv ut föremål
                    Console.WriteLine(content[i]);
                }
            }

            Console.WriteLine();
        }

        // Metod för att söka efter ett föremål i ryggsäcken
        public void SearchItem()
        {
            // Kollar om ryggsäcken är tom
            if (IsEmpty())
            {
                throw new Exception("Din ryggsäck är tom! Du kan inte söka efter något.\n");
            }

            Console.Write("Vad vill du söka efter: ");
            string item = Console.ReadLine();

            // For-loopen går igenom varje variabel i ryggsäcken. Om den hittar en matchande text skriver den ut föremålet.
            // Om man har fler föremål med samma namn skriver den bara ut den första den hittar
            for (int i = 0; i < content.Length; i++)
            {
                // Jämför variablerna i små bokstäver
                if(content[i].ToLower() == item.ToLower())
                {
                    Console.WriteLine("Du hittade en/ett {0}", content[i]);
                    break;
                }
            }

            Console.WriteLine();
        }

        // Metod för att tömma innehållet i ryggsäcken
        public void ClearContent()
        {
            // Kollar om ryggsäcken är tom
            if (IsEmpty())
            {
                throw new Exception("Din ryggsäck är redan tom!\n");
            }

            // For-loopen går igenom varje variabel i vektorn och "skriver över" dem med "null"
            for (int i = 0; i < content.Length; i++)
            {
                content[i] = null;
            }

            Console.WriteLine("Du har tömt din ryggsäck!\n");

            // Tilldelar "emptyIndex" 0 för nästa föremål som läggs till eftersom ryggsäcken är nu tom.
            emptyIndex = 0;
        }

        // Privat metod som kollar om ryggsäcken är full
        //
        // Fråga:
        // Eftersom jag bara använder denna metod en gång i programmet, är det onödigt att ha med den? Blir i alla fall tydligt när man gör så här.
        bool IsFull()
        {
            // Returnerar SANT om "emptyIndex" är mer än 4. 0-4 = 5 platser i en vektor
            if(emptyIndex > 4)
            {
               return true; 
            }
            return false;
        }

        // Privat metod som kollar om ryggsäcken är tom
        bool IsEmpty()
        {
            // Returnerar SANT om "emptyIndex" är lika med noll
            if(emptyIndex == 0)
            {
                return true;
            }
            return false;
        }
    }
}
