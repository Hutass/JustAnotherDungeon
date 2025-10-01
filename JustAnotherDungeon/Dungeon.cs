using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustAnotherDungeon
{
    internal class Dungeon
    {
        public List<ContentContainer> LoadedContent {  get; set; }
        public List<ContentContainer> CurrentContentPool { get; set; }
        public int Size { get; set; }
        public int MaxItemsPerRoom { get; set; }
        public int MaxMobsPerRoom { get; set; }
        public int MaxEventsPerRoom { get; set; }
        public double MobSpawnRate { get; set; }
        public double EventSpawnRate { get; set; }

        public Dungeon() 
        {
            LoadedContent = new List<ContentContainer>();
            MaxItemsPerRoom = 1;
            MaxMobsPerRoom = 1;
            MaxEventsPerRoom = 1;
            MobSpawnRate = 50;
            EventSpawnRate = 50;
            Size = 10;
        }

        public void ReloadContent(string contentDirectoryPath)
        {
            string[] files = Directory.GetFiles(contentDirectoryPath, "*.*", SearchOption.AllDirectories)
                .Where(file => file.EndsWith(".tsv") || file.EndsWith(".csv"))
                .ToArray();

            LoadedContent = new List<ContentContainer>();

            foreach (string file in files)
            {
                //if(file.EndsWith(".csv"))
                //{
                //    LoadedContent += new FileExtractorCSV().ExtractFile(file);
                //}
                if (file.EndsWith(".tsv"))
                {
                    LoadedContent.Add(new FileExtractorTSV().ExtractFile(file));
                }
            }
        }
        public void Generate()
        {

        }
    }
}
