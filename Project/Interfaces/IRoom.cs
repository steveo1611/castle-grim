using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public interface IRoom
    {
        string Name { get; set; }
        string Description { get; set; }
        List<Item> Items { get; set; }
 //       Dictionary<string, IRoom> Exits { get; set; } //this was dropped in after we started project: how do I incorp?
        void UseItem(Item item);

    }
}