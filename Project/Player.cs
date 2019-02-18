using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Player : IPlayer
    {
        public string Name { get; set; }
        public List<Item> Inventory { get; set; }
 //       public int Moves { get; set; }

public string PlayerName()
    {
            Console.WriteLine("Please enter your name:");
            string userName = Console.ReadLine();
            return userName;
    }

public void ListInventory(Player player)
    {
        Console.Clear();         
        Console.WriteLine("Your inventory:");
         for (int i = 0; i < player.Inventory.Count; i++)
         {
                var inventory = player.Inventory[i];
                Console.WriteLine($"{inventory.Name} : {inventory.Description}");
         }
    }

        public Player()
        {
            Name = PlayerName();
            Inventory = new List<Item>();
          //  Moves = 0; // todo: think this needs to be moved outside of the construct and into a simple var.
        }
    }
}