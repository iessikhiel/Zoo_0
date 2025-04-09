//Редьков Михаил ИП2-24
using System;

namespace Zoo
{

   public class Program
   {
      static void Main()
      {
         Console.Clear();
         bool IsOpen = true;
         int find_Id;

         List<Animal> animals = new List<Animal>()
         { 
            new Animal(1, "Boo", "Black Bear", 4, false),
            new Animal(2, "Monk", "Black Bear", 9, false),
            new Animal(3, "Ieshua", "Goat", 2, false),
            new Animal(4, "Lad", "Panda", 6, false)            
         };
         while(IsOpen)
         {
            for (int j = 0; j < animals.Count(); j++)
            {
               animals[j].ListAll();
            }
            Console.WriteLine("_____________________");

            Console.WriteLine("1. Info\n2. Add\n3. Update\n4. Feed\n5. Exit");

            int input = GetUserInput("Select menu position: ");
            switch (input)
            {
               case 1:
                  Console.Write("\nSelect Id: ");
                  find_Id = Convert.ToInt32(Console.ReadLine());

                  var AnimalToShow = animals.Find(a => a.Id == find_Id);
                  if (AnimalToShow != null)
                  {
                     AnimalToShow.GetById();
                  }
                  else
                  {
                     Console.WriteLine("Animal not found");
                  }
                  Console.WriteLine("\npress any button to continue\n");                  
                  Console.ReadKey();
                  break;

               case 2:
                  int t_Id;
                  string t_Name;
                  string t_Species;
                  int t_Age;
                  bool t_IsFed;

                  Console.WriteLine("Adding new animal...\n");

                  Console.Write("Animal ID: ");
                     t_Id = Convert.ToInt32(Console.ReadLine());
                  Console.Write("Animal name: ");
                     t_Name = Console.ReadLine();
                  Console.Write("Animal species: ");
                     t_Species = Console.ReadLine();
                  Console.Write("Animal age: ");
                     t_Age = Convert.ToInt32(Console.ReadLine());
                  Console.Write("Animal is fed (true/false): ");
                     t_IsFed = Convert.ToBoolean(Console.ReadLine());

                  animals.Add(new Animal(t_Id, t_Name, t_Species, t_Age, t_IsFed));

                  Console.WriteLine("\npress any button to continue\n");
                  Console.ReadKey();
                  break;
               case 3:
                  Console.Write("\nSelect Id of the animal to update: ");
                  find_Id = Convert.ToInt32(Console.ReadLine());

                  var AnimalToUpdate = animals.Find(a => a.Id == find_Id);
                  if (AnimalToUpdate != null)
                  {
                     Console.WriteLine("Updating animal...\n");

                     Console.Write("New Animal name (leave blank to keep current): ");
                     string newName = Console.ReadLine();
                     if (!string.IsNullOrEmpty(newName))
                     {
                           AnimalToUpdate.Name = newName;
                     }

                     Console.Write("New Animal species (leave blank to keep current): ");
                     string newSpecies = Console.ReadLine();
                     if (!string.IsNullOrEmpty(newSpecies))
                     {
                           AnimalToUpdate.Species = newSpecies;
                     }

                     Console.Write("New Animal age (leave blank to keep current): ");
                     string ageInput = Console.ReadLine();
                     if (int.TryParse(ageInput, out int newAge))
                     {
                           AnimalToUpdate.Age = newAge;
                     }

                     Console.Write("Is the animal fed? (true/false, leave blank to keep current): ");
                     string fedInput = Console.ReadLine();
                     if (bool.TryParse(fedInput, out bool isFed))
                     {
                           AnimalToUpdate.IsFed = isFed;
                     }

                     Console.WriteLine("Animal updated successfully!");
                  }
                  else
                  {
                     Console.WriteLine("Animal not found");
                  }

                  Console.WriteLine("\npress any button to continue\n");
                  Console.ReadKey();
                  break;
               case 4:
                  Console.Write("\nSelect Id: ");
                  find_Id = Convert.ToInt32(Console.ReadLine());

                  var AnimalToFed = animals.Find(a => a.Id == find_Id);
                  if (AnimalToFed != null)
                  {
                     AnimalToFed.FeedAnimal();
                     Console.WriteLine("Animal is fed\npress any button to continue\n");  
                  }
                  else
                  {
                     Console.WriteLine("Animal not found...");
                  }
                
                  Console.ReadKey();
                  break;
               case 5:
                  IsOpen = false;
                  break;         
               default:
                  Console.WriteLine("Invalid position...");
                  Console.WriteLine("\npress any button to continue\n");
                  Console.ReadKey();
                  break;   
            }
            Console.Clear();  
         }
      }
         static int GetUserInput(string prompt)
        {
            int result;
            Console.Write(prompt);
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                Console.Write(prompt);
            }
            return result;
        }
   }
   
   public class Animal
   {
      public int Id;
      public string Name;
      public string Species;
      public int Age;
      public bool IsFed = false;
      
      public Animal(int id, string name, string species, int age, bool is_fed)
      {
         Id = id;
         Name = name;
         Species = species;
         Age = age;
         IsFed = is_fed;
      }

      public Animal()
      {
         Id = 0;
         Name = "X";
         Species = "Y";
         Age = 0;
      }
      public void FeedAnimal()
      {
         IsFed = true;
      }

      public void ListAll()
      {
         Console.WriteLine($"Id: {Id}\n*{Species} - \"{Name}\"\nIs fed: {IsFed}");
      }

      public void GetById()
      {
         Console.WriteLine($"\nId: {Id}\nName: \"{Name}\"\nSpecies: {Species}\nAge: {Age}\nIs fed - {IsFed}\n");
      }
   }
}
