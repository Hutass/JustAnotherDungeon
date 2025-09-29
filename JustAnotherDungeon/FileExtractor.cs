using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace JustAnotherDungeon
{
    public interface FileExtractor
    {
        ContentContainer ExtractFile(string filePath);
    }

    public class FileExtractorCSV : FileExtractor
    {
        /// <summary>
        /// Извлечение содержимого из файла формата .csv в формате Excel с разделителем ';'. Работает не всегда, лучше не использовать файлы этого формата
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        /// <returns></returns>
        public ContentContainer ExtractFile(string filePath)
        {
            ContentContainer container = new ContentContainer();
            StreamReader extractedFile;

            try
            {
                extractedFile = new StreamReader(filePath);
            }
            catch (FileNotFoundException)
            {
                Debug.WriteLine("Файл не найден: " +  filePath);
                return container;
            }

            container.Name = Path.GetFileNameWithoutExtension(filePath);
            string[] colNames = extractedFile.ReadLine().Split(';');
            while (!extractedFile.EndOfStream)
            {
                string[] things = extractedFile.ReadLine().Split(';');

                for(int i = 0; i< things.Length; i++)
                {
                    if (things[i] == "")
                        break;
                    switch(colNames[i])
                    {
                        case "Room":
                            container.Rooms.Add(new Room
                            {
                                Name = things[i],
                                Description = things[Array.FindIndex(colNames, element => element == "RoomDesc")],
                                NumberOfDoors = Convert.ToInt32(things[Array.FindIndex(colNames, element => element == "NumberOfDoors")])
                            });
                            break;
                        case "Door":
                            container.Doors.Add(new Door
                            {
                                Name = things[i],
                                Description = things[Array.FindIndex(colNames, element => element == "DoorDesc")],
                            });
                            break;
                        case "Item":
                            container.Items.Add(new Item
                            {
                                Name = things[i],
                                Description = things[Array.FindIndex(colNames, element => element == "ItemDesc")],
                            });
                            break;
                        case "Wall":
                            container.Walls.Add(things[i]);
                            break;
                        case "OutWall":
                            container.OuterWalls.Add(things[i]);
                            break;
                        case "Floor":
                            container.Floors.Add(things[i]);
                            break;
                        case "OutFloor":
                            container.OuterFloors.Add(things[i]);
                            break;
                        case "Ceiling":
                            container.Ceilings.Add(things[i]);
                            break;
                        case "OutCeiling":
                            container.OuterCeilings.Add(things[i]);
                            break;
                    }
                }              
            }

            return container;
        }
    }

    public class FileExtractorTSV : FileExtractor
    {
        /// <summary>
        /// Извлечение содержимого из файла формата .tsv
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        /// <returns></returns>
        public ContentContainer ExtractFile(string filePath)
        {
            ContentContainer container = new ContentContainer();
            StreamReader extractedFile;

            try
            {
                extractedFile = new StreamReader(filePath);
            }
            catch (FileNotFoundException)
            {
                Debug.WriteLine("Файл не найден: " + filePath);
                return container;
            }

            container.Name = Path.GetFileNameWithoutExtension(filePath);
            string[] colNames = extractedFile.ReadLine().Split('\t');
            while (!extractedFile.EndOfStream)
            {
                string[] things = extractedFile.ReadLine().Split('\t');

                for (int i = 0; i < things.Length; i++)
                {
                    if (things[i] == "")
                        continue;
                    switch (colNames[i])
                    {
                        case "Room":
                            container.Rooms.Add(new Room
                            {
                                Name = things[i],
                                Description = things[Array.FindIndex(colNames, element => element == "RoomDesc")],
                                NumberOfDoors = Convert.ToInt32(things[Array.FindIndex(colNames, element => element == "NumberOfDoors")]),
                                Volume = Convert.ToInt32(things[Array.FindIndex(colNames, element => element == "RoomVolume")])
                            });
                            break;
                        case "Door":
                            container.Doors.Add(new Door
                            {
                                Name = things[i],
                                Description = things[Array.FindIndex(colNames, element => element == "DoorDesc")],
                            });
                            break;
                        case "Item":
                            container.Items.Add(new Item
                            {
                                Name = things[i],
                                Description = things[Array.FindIndex(colNames, element => element == "ItemDesc")],
                                Volume = Convert.ToInt32(things[Array.FindIndex(colNames, element => element == "ItemVolume")]),
                                Value = Convert.ToInt32(things[Array.FindIndex(colNames, element => element == "ItemValue")])
                            });
                            break;
                        case "Mob":
                            int[] stats = things[Array.FindIndex(colNames, element => element == "MobStat")].Split(',').Select(int.Parse).ToArray();
                            container.Mobs.Add(new Mob
                            {
                                Name = things[i],
                                Description = things[Array.FindIndex(colNames, element => element == "MobDesc")],
                                Volume = Convert.ToInt32(things[Array.FindIndex(colNames, element => element == "MobVolume")]),
                                Strenght = stats[0],
                                Dexterity = stats[1],
                                Endurance = stats[2],
                                Will = stats[3],
                                Advertency = stats[4],
                                Knowledge = stats[5],
                                Thinking = stats[6],
                                Insight = stats[7],
                                Pretense = stats[8],
                                Impression = stats[9]
                            });
                            break;
                        case "Event":
                            container.Events.Add(new Event
                            {
                                Name = things[i],
                                Description = things[Array.FindIndex(colNames, element => element == "EventDesc")],
                            });
                            break;

                        case "Wall":
                            container.Walls.Add(things[i]);
                            break;
                        case "OutWall":
                            container.OuterWalls.Add(things[i]);
                            break;
                        case "Floor":
                            container.Floors.Add(things[i]);
                            break;
                        case "OutFloor":
                            container.OuterFloors.Add(things[i]);
                            break;
                        case "Ceiling":
                            container.Ceilings.Add(things[i]);
                            break;
                        case "OutCeiling":
                            container.OuterCeilings.Add(things[i]);
                            break;
                    }
                }
            }
            extractedFile.Close();

            return container;
        }
    }
}
