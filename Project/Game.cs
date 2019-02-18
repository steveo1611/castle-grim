using System.Collections.Generic;
using System;
//using static CastleGrimtol.Project.Story;
                          
namespace CastleGrimtol.Project
{
    public class Game : IGame
    {
        public Room CurrentRoom { get; set; }
        public Player CurrentPlayer { get; set; }
        public Boolean GameOn {get; set; }
        private List<Room> Rooms { get; set; }
        private List<Item> Items { get; set; }
    
        public void Setup()
        {
          Console.Clear();
            Console.WriteLine(@"
            Welcome to the 'LITTLE SHOP of Hasenpfeffer'
                May you enjoy the short moment of adventure
            ");


            // basic room configs
            Room room0 = new Room("GuardRoom", "You can see from the dim lighting provided by the way too high and too large \r\n rabbit hole that you are in what looks like it could have been a guard house \r\n in days gone by if it wasn't stuck in a RABBIT HOLE!!!! \r\n anyways looking around you see that there is a hallway to the left toward the 'west' that leads somewhere?..."); 
            Room room1 = new Room("Hallway", "In a Hallway...you reach the end of the hallway with doors to North and South... \r\n there is nothing but dust rabbit droppings in the hallway.  So which way do you want to go from here?");
            Room room2 = new Room("storageRoom", "As you open the door, you note that it seems to have been a LONG time since anyone was here, \r\n and you wish it had been even longer since anyone had opened this door. \r\n In the even dimmer lighting as you move away from the rabbit hole, you see there there are doors to the 'south' and what appears to be another door to the 'east'.");            
            Room room3 = new Room("bedchamber", "This room seems to be of no real interest except for a small gleam coming from something near the center of room, you guess it may have once been someones bedroom, there is a door to the 'north' and a second door to the 'east'");
            Room room4 = new Room("smallRoom", "Just a strange small room of no descripting features or worth noting.  There are doors to the 'north' and to the 'west'");
            Room room5 = new Room("Antechamber", "Appears to be an Antechamber to another bigger room, there are doors to the 'west' to the 'south' and a different looking door to the 'north' ");
            Room room6 = new Room("RabbitRoom", "As you open the door your eyes come upon a room full of bones most of them small animal bones but some appear to have been human.  \r\n As you look closer some of the bones have been picked clean and some not so much yet, \r\n in the middle of the room sits a huge floppy eared white rabbit, that appers to be sleeping.  \r\n Behind him to the 'north' you can see what appears to be another door with what looks like daylight slipping through the bottom crack and about this time you realize that the door you entered in closes with a loud noise of the lock engaing.");
         //   Room room7 = new Room("Room7", "something else to describe this room7");

            //add rooms
            Rooms.Add(room0);
            Rooms.Add(room1);
            Rooms.Add(room2);
            Rooms.Add(room3);
            Rooms.Add(room4);
            Rooms.Add(room5);
            Rooms.Add(room6);
          //  Rooms.Add(room7);

            // items
            Item ItRoom0 = new Item("GoldCoin", "You find a 'GoldCoin' over against the wall, one of the rabbits must have dropped it on the way out of the hole", 10);
            Item ItRoom1 = new Item("nothing", "Nothing to see here, not even for a thief", 10); // not being used: no items here.
            Item ItRoom2 = new Item("flashlight", "There didn't seem to be anything in this room until you notice a 'flashlight' handing on the back of door", 20);
            Item ItRoom3 = new Item("key", "Old rusty skeleton key discarded or perhaps lost on the ground in the center of the room", 30);
            Item ItRoom4 = new Item("SilverCoins", "small bag with a few 'silvercoins'", 40);
            Item ItRoom5 = new Item("nothing", "Nothing to see here no items worth stealing", 50); // not being used: no items here.
            Item ItRoom6 = new Item("Gold", "Sitting beside the sleeping rabbit was a couple of bags of 'gold'", 60);
            //Item ItRoom7 = new Item("itRoom7", "holder for item in room7", 70);
            
            // add items
            room0.Items.Add(ItRoom0);
            room1.Items.Add(ItRoom1);
            room2.Items.Add(ItRoom2);
            room3.Items.Add(ItRoom3);
            room4.Items.Add(ItRoom4);
            room5.Items.Add(ItRoom5);
            room6.Items.Add(ItRoom6);
         //   room7.Items.Add(ItRoom7);


            // movement dictionary (setting exits for rooms)

            room0.exits.Add("w", room1);
            room1.exits.Add("e", room0);
            room1.exits.Add("n", room2);
            room1.exits.Add("s", room3);
            room2.exits.Add("e", room5);
            room2.exits.Add("s", room1);
            room3.exits.Add("e", room4);
            room3.exits.Add("n", room1);
            room4.exits.Add("w", room3);
            room4.exits.Add("n", room5);
            room5.exits.Add("n", room6);
            room5.exits.Add("s", room4);
            room5.exits.Add("w", room2);
         //   room6.exits.Add("s", room5); 

            CurrentRoom = room0;
      //      Console.WriteLine(CurrentRoom.Description);
        }

     //method to handle moving between rooms:
    public void MoveRoom(string direction)
    {  
         //   string nextRoom;
         if (CurrentRoom.exits.TryGetValue(direction, out Room nextRoom))
                {
                CurrentRoom = nextRoom;
                if (CurrentRoom.Name == "RabbitRoom")
                    {
                    if (!CurrentPlayer.Inventory.Exists(i => i.Name == "key"))
                        {
                        //string tempz = CurrentPlayer.Inventory.Find("key");
                        Loser();
                    }
                    }

                }
            else
                {
                Console.WriteLine("That way does not lead anywhere");
                }
    }

    public void UseItem(string itemName)
        {
            // need to select item and call out what (if anything) happens when item is used
            Item item = CurrentPlayer.Inventory.Find(Item => Item.Name.ToLower() == itemName );
            if (item != null && item.Name.ToLower() == "goldcoin")
                {
                Console.WriteLine("You look at the coin, it appears to be just like the coins you always dreamed of having in your pocket...so you decide to flip the coin so you toss it into the air with an easy flip of the thumb and.....");
                System.Threading.Thread.Sleep(5000);
                Console.WriteLine("it falls back into your hand, hum nothing happened with that");
                }
            if (item != null && item.Name.ToLower() == "flashlight")
                {
                Console.WriteLine("You click the switch on the flashlight while thanking yourself that now you will be able to see in the dark corners.  But nothing happens, batteries were not duracell's and are drained.*sigh*");
                }
            if (item != null && item.Name.ToLower() == "key")
                {
                if (CurrentRoom.Name != "RabbitRoom")
                    {
                     Console.WriteLine(@"
                    You look around but do not find any doors or chest where this key works in, you wonder why do I even hold onto this stupid thing for?");   
                    }
                else
                    {
                    Console.WriteLine(@"
                As you creep by the sleeping rabbit, you notice that this door indeed does have a keyhole that this key fits.  You place the key in and turn it...the door opens and you step out not too far from where you fell down the rabbit hole");

                    }
                  Winning();
                }
            if (item != null && item.Name.ToLower() == "silvercoin")
                {
                Console.WriteLine("You look at the coin, it appears to be just like the coins you always dreamed of having in your pocket...so you decide to flip the coin so you toss it into the air with an easy flip of the thumb and.....");
                System.Threading.Thread.Sleep(3000);
                Console.WriteLine("it falls back into your hand, hum nothing happened with that");
                }
            if (item != null && item.Name.ToLower() == "gold")
                {
                Console.WriteLine("You take the bag of gold, you do know that's stealing don't you?");
                }
      /* if (item != null && item.Name.ToLower() == "ItRoom5")   // one of these needs to cause the player to LOSE
                {
                Console.WriteLine(" item ItRoom5 does nothing.");
                }
            if (item != null && item.Name.ToLower() == "ItRoom6")
                {
                Console.WriteLine(" item ItRoom6 does nothing.");
                }
            if (item != null && item.Name.ToLower() == "ItRoom7")
                {
                Console.WriteLine(" item ItRoom7 does nothing.");
                }
    */        if (item == null)
                {
                Console.WriteLine("errrr, that don't make sense, you want to try again?");
                }

        }

    public string GetInput()
            {
            Console.WriteLine();
            Console.WriteLine("What to do .. What to do...what do you think?");
            string command = Console.ReadLine();
            return command;
}
       
    public void Help()
            {
            Console.WriteLine(@"Hello, here are some basic help and instructions for the adventure
            To refer back to these helps just type in 'h' or 'Help'.

Commands:

    'reset' : will reset the game to the beginning.

    'go <<direction>> : (options are n, s, e, w ) enter 'go and then the first letter of the direction that you want to go.  
    (ie: 'go n' will take you north)

    'look' : Command to give current room's description. And search room for any items.

    'take <item name>' : Command to take an item found in the room and add to inventory.  (item name will be listed in single quotes)

    'use <item name>' : Command to try and use an item that is in the inventory in the current room. (item name will be listed in single quotes)

    'quit' : Not that you should EVER use this but this is the command to end the game.

");
            }

    public void Look(Room room)
            {
            Console.WriteLine(CurrentRoom.Description);
            Console.WriteLine(@"Items:
                ");
                for (int i = 0; i < room.Items.Count; i++)
                 {
                Console.WriteLine($"{room.Items[i].Name}");
                Console.WriteLine($"{room.Items[i].Description}");
                 } 
            }

    public void TakeItem(string itemname)
            {
            //handle grabbing items and adding to inventory
            Item item = CurrentRoom.Items.Find(Item => Item.Name.ToLower() == itemname);
            if (item != null)
             {
                CurrentRoom.Items.Remove(item);
                CurrentPlayer.Inventory.Add(item);

                CurrentPlayer.ListInventory(CurrentPlayer);
             }
            else
             { 
             Console.WriteLine("nuting to take");   
             }
            }

        public void Loser()
        {
            Console.WriteLine("You find the door you came in locked with no apparent way to unlock it, You notice that the rabbit as started to stir so you run toward the door to the north but find it locked with a key hole beckoning to be used but it is locked and you have not key.  The rabbit wakes up and turns toward you...and leaps toward you..that is the last thing you see....");
            Console.WriteLine("You have lost...");
            Console.WriteLine("Would you like to play again? Y/N");
            string again = Console.ReadLine().ToLower();
            if (again == "y" || again == "yes")
            {
                Reset();
            }
            else
            {
                Quit();
            }
        }


        public void Winning()
        {
            Console.WriteLine("Congratulations!!! you have escaped from the horrors of the LITTLE SHOP of Hasenpfeffer");
            Console.WriteLine("Would you like to play again? Y/N");
            string again = Console.ReadLine().ToLower();
            if (again == "y" || again == "yes")
            {
                Reset();
            }
            else
            {
                Quit();
            }
        }

        public Boolean Quit ()
            {
        Console.WriteLine("You sure you want to quit?  All will be lost.  Y/N");
            string input = Console.ReadLine().ToLower();
            if (input == "y" || input == "yes")
                {
              return GameOn = false;
            }
        else
         {
        Console.WriteLine("Glad to hear you will carry on");
                return GameOn = true;
         }
             }   

        public void Reset()
        {
            GameOn = true;
            Setup();
        }
          
 public Game()
        {
  //          CurrentRoom = currentRoom;
    //        CurrentPlayer = currentPlayer;
            Rooms = new List<Room>();
            Items = new List<Item>();
        }
    }
}