using DGD208_Spring2025_UygarManis.Enums;

namespace DGD208_Spring2025_UygarManis
{
    public class Item
    {
        public string name { get; set; }
        public ItemType itemType { get; set; }
        public int effectAmount { get; set; }
        public int duration { get; set; } 

        public Item(string name, ItemType itemType, int effectAmount, int duration)
        {
            this.name = name;
            this.itemType = itemType;
            this.effectAmount = effectAmount;
            this.duration = duration;
        }
    }
}
