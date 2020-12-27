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
using System.IO;
using Microsoft.Win32;
using ТпЛр2.Models;
using Products.Kontroller;

namespace Products
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
   
        }
        int[] polesnost;
        int[] zena;
        public List<Ware> Pokupki = new List<Ware>();
        public List<int> BestPokupki = new List<int>();

        public void ChooseFileClick(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog opfidi = new OpenFileDialog();
                opfidi.ShowDialog();
                List<string> Einkaufsliste = new List<string>();
                string productString;
                if (opfidi.FileName != "")
                {
                    productString = File.ReadAllText(opfidi.FileName);
                    Einkaufsliste.AddRange(productString.Split('\n'));
                }
                int c = 3 * Einkaufsliste.Count;
                polesnost = new int[c];
                zena = new int[c];
                Pokupki.Clear();
                Menu.Items.Clear();
                int n = 0;
                for (int i = 1; i <= Einkaufsliste.Count; i++)
                {
                    string[] gad = new string[4]; 
                    gad = Einkaufsliste[i - 1].Split(':');
                    Pokupki.Add(item: new Items() { category = gad[0], name = gad[1], price = Convert.ToInt32(gad[2]), healthiness = Convert.ToInt32(gad[3]) });
                    zena[n] = Convert.ToInt32(gad[2]);
                    polesnost[n] = Convert.ToInt32(gad[3]);
                    n++;
                    Menu.Items.Add(gad[1] + " " + gad[2] + "р.");
                    Pokupki.Add(item: new Items() { category = gad[0], name = gad[1], price = Convert.ToInt32(gad[2]), healthiness = (int)Math.Round(0.8 * Convert.ToInt32(gad[3])) });
                    zena[n] = Convert.ToInt32(gad[2]);
                    polesnost[n] = (int)Math.Round(0.8 * Convert.ToInt32(gad[3]));
                    n++;
                    Pokupki.Add(item: new Items() { category = gad[0], name = gad[1], price = Convert.ToInt32(gad[2]), healthiness = (int)Math.Round(0.8 * 0.8 * Convert.ToInt32(gad[3])) });
                    zena[n] = Convert.ToInt32(gad[2]);
                    polesnost[n] = (int)Math.Round(0.8 * 0.8 * Convert.ToInt32(gad[3]));
                    n++;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Проверьте формат файла и путь");
                Path.Text = "Путь к файлу";
            }
        }

        public void Count_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int i = 0;
                Knapsack.Items.Clear();
                int money = Math.Abs(Convert.ToInt32(Summ.Text));
                BestPokupki = Knapsack_problem.knapsack(zena, polesnost, money);
                for (i = 0; i < (BestPokupki.Count - 1); i++)
                    Knapsack.Items.Add(Pokupki[BestPokupki[i]].name);
                Knapsack.Items.Add("Итоговая полезность: " + BestPokupki[i]);
                //Knapsack.ItemsSource = BestPokupki;
            }
            catch (Exception)
            { 
                MessageBox.Show("Введите корректно сумму денег");
                Summ.Text = "Сумма денег";
            }
        }
    }
}
