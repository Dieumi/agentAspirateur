using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace AgentAspirateur
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer dt = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            dt.Tick += Redessine_Tick;
            dt.Interval = new TimeSpan(0, 0, 0, 0, App.env.vitesse);
            initPlateau();
            Dessine();
            dt.Start();
           
            Thread tt = new Thread(App.env.Avance);
            tt.Start();
            Dessine();
        }
        private void Redessine_Tick(object sender, EventArgs e)
        {
           
                Dessine();
            

        }
        public void Dessine()
        {
            initPlateau();
            Image img = new Image();
            Uri uri = new Uri("img/robot.jpg", UriKind.Relative);
            img.Source = new BitmapImage(uri);
            Plateau.Children.Add(img);

            Grid.SetColumn(img, App.env.agent.Position.Y);
            Grid.SetRow(img, App.env.agent.Position.X);
            foreach (ObjetAbstrait unObjet in App.env.list)
            {
                Image obj = new Image();
                if (unObjet.GetType().Equals(typeof(Bijoux)))
                {
                    Uri urib = new Uri("img/bague.jpg", UriKind.Relative);
                    obj.Source = new BitmapImage(urib);
                }
                if (unObjet.GetType().Equals(typeof(Poussiere)))
                {
                    Uri urib = new Uri("img/poussiere.jpg", UriKind.Relative);
                    obj.Source = new BitmapImage(urib);
                }
                Plateau.Children.Add(obj);
                Grid.SetColumn(obj, unObjet.Position.Y);
                Grid.SetRow(obj, unObjet.Position.X);

            }

        }
        public void initPlateau()
        {
            Plateau.ColumnDefinitions.Clear();
            Plateau.RowDefinitions.Clear();
            Plateau.Children.Clear();
            for (int i = 0; i < App.env.DimensionX; i++)
            {
                Plateau.RowDefinitions.Add(new RowDefinition());

            }
            for (int j = 0; j < App.env.DimensionY; j++)
            {
                Plateau.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }
    }
}
