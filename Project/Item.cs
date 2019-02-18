using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Item : IItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ItemNum { get; set; }
        public bool Inpossession { get; set; }


        public Item(string name, string description, int itemNum)
        {
            Name = name;
            Description = description;
            ItemNum = itemNum;
            Inpossession = false;
        }
    }

}