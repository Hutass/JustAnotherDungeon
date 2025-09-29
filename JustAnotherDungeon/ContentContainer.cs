using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace JustAnotherDungeon
{
    public class ContentContainer
    {
        public List<Room> Rooms { get; set; }
        public List<Door> Doors { get; set; }
        public List<Item> Items { get; set; }
        public List<Mob> Mobs { get; set; }
        public List<Event> Events { get; set; }
        public List<string> Walls { get; set; }
        public List<string> OuterWalls { get; set; }
        public List<string> Floors { get; set; }
        public List<string> OuterFloors { get; set; }
        public List<string> Ceilings { get; set; }
        public List<string> OuterCeilings { get; set; }
        public double Weight { get; set; }
        public string Name { get; set; }

        public ContentContainer()
        {
            Rooms = new List<Room>();
            Doors = new List<Door>();
            Items = new List<Item>();
            Mobs = new List<Mob>();
            Events = new List<Event>();
            Walls = new List<string>();
            OuterWalls = new List<string>();
            Floors = new List<string>();
            OuterFloors = new List<string>();
            Ceilings = new List<string>();
            OuterCeilings = new List<string>();
            Weight = 1;
        }
        /// <summary>
        /// Сложение сущностей контейнеров
        /// </summary>
        /// <param name="firstContainer">Первый контейнер</param>
        /// <param name="secondContainer">Второй контейнер</param>
        /// <returns></returns>
        public static ContentContainer operator +(ContentContainer firstContainer, ContentContainer secondContainer) 
        {
            ContentContainer containerSum = secondContainer;
            return new ContentContainer() {
                Rooms = firstContainer.Rooms.Concat(secondContainer.Rooms).ToList(),
                Doors = firstContainer.Doors.Concat(secondContainer.Doors).ToList(),
                Items = firstContainer.Items.Concat(secondContainer.Items).ToList(),
                Mobs = firstContainer.Mobs.Concat(secondContainer.Mobs).ToList(),
                Events = firstContainer.Events.Concat(secondContainer.Events).ToList(),
                Walls = firstContainer.Walls.Concat(secondContainer.Walls).ToList(),
                OuterWalls = firstContainer.OuterWalls.Concat(secondContainer.OuterWalls).ToList(),
                Floors = firstContainer.Floors.Concat(secondContainer.Floors).ToList(),
                OuterFloors = firstContainer.OuterFloors.Concat(secondContainer.OuterFloors).ToList(),
                Ceilings = firstContainer.Ceilings.Concat(secondContainer.Ceilings).ToList(),
                OuterCeilings = firstContainer.OuterCeilings.Concat(secondContainer.OuterCeilings).ToList(),
            };
        }
    }

    public struct Room
    {
        public string Name; 
        public string Description;
        public int NumberOfDoors;
        public int Volume;
    }
    public struct Door
    {  
       public string Name;
       public string Description;
    }
    public struct Item
    {
        public string Name;
        public string Description;
        public int Value;
        public int Volume;
    }
    public struct Mob
    {
        public string Name;
        public string Description;
        public int Volume;
        public int Strenght;
        public int Dexterity;
        public int Endurance;
        public int Will;
        public int Advertency;
        public int Knowledge;
        public int Thinking;
        public int Insight;
        public int Pretense;
        public int Impression;
    }
    public struct Event
    {
        public string Name;
        public string Description;
    }
}
