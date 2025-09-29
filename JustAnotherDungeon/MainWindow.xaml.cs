using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JustAnotherDungeon
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Dungeon dungeon = new Dungeon();
            //Временный булщит
            dungeon.ReloadContent("C:\\Users\\Артём\\Desktop\\Dungeon");
            test.Text = dungeon.LoadedContent[0].Rooms[0].Name.ToString();
        }
    }
}
