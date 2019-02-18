// using System;
using System.Collections.Generic;
//using static CastleGrimtol.Project.Story;


namespace CastleGrimtol.Project
{
    public class Room : IRoom
    {
        public Dictionary<string, Room> exits = new Dictionary<string, Room>();
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Item> Items { get; set; }

        public void UseItem(Item item)
        {
         //need to figure out what the item is, if there are any uses.
            //if useable generate "action"
            //currently doing this in game class : should I move this? *sigh this is setup on interface guess I suppose to use it...


        }

        //method to handle moving between rooms:
     /*   public void moveRoom(string direction)
            {  
            if (exits.TryGetValue(direction, out Room))
                {
                console.writeLine();
                }
            else
                {
                Console.WriteLine("Fail");
                }
            }
    */    
        public void SetExits(string direction, Room room) //currently not using this: may use in refactor
        {
          //  exits.Add(direction, room);

        }
        
        public Room(string name, string description)
        {
            Name = name;
            Description = description;
            Items = new List<Item>();
        }
    }
}