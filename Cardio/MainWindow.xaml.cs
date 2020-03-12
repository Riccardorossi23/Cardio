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

namespace Cardio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        List<string> bpm = new List<string>();
        private void btnRisultato_Click(object sender, RoutedEventArgs e)
        {
            txtSportivo.IsEnabled = true;
            txtMax.IsEnabled = true;
            txtCalorie.IsEnabled = true;
            txtrisultato.IsEnabled = true;
            string name = txtNome.Text;
            string surname = txtCognome.Text;
            int anni = int.Parse(txtAnni.Text);
            int ore = int.Parse(txtOre.Text);
            int kg = int.Parse(txtKg.Text);
            int max = 220 - anni;
            txtMax.Text = max.ToString();
            int frequenza = ((70 * max / 100) + (90 * max / 100));
            int sportivo =frequenza / 2;
            txtSportivo.Text = sportivo.ToString();
            int bpmriposo = int.Parse(txtriposo.Text);
            string bpmrisultato = "";
            if (bpmriposo < 60)
            {
               bpmrisultato = "bradicardico";
                txtrisultato.Text = bpmrisultato.ToString();
            }
            else if (bpmriposo > 60 && bpmriposo <= 100)
            {
               bpmrisultato = "normale";
                txtrisultato.Text = bpmrisultato.ToString();
            }
            else
            {
                bpmrisultato = "tachicardico";
                txtrisultato.Text = bpmrisultato.ToString();
            }
        
            string sesso = "";
            string Kcal = "";
            if (M.IsChecked == true)
            {
                sesso = "nato";
                 double calorie = ((anni * 0.2017) + (kg * 0.199) + (max * 0.6309) - 55.0969) * ore / 4.184;
                txtCalorie.Text = calorie.ToString();
                Kcal =$"{calorie}";
            }
            else if (F.IsChecked == true)
            {
                sesso = "nata";
                double calorie = ((anni * 0.074) + (kg * 0.126) + (max * 0.4472) - 20.4022) * ore / 4.184;
                txtCalorie.Text = calorie.ToString();
                Kcal = $"{calorie}";
            }
         

            lblRisultato.Content = ($"{name} {surname}, {sesso} il {anni}. Si allena {ore} per il suo peso corporiro di:{kg}, i bpm masimo è {max} per un allenamento efficace deve avere i battiti a {sportivo},i tuoi battiti a riposo sono{bpmriposo}qundi sei {bpmrisultato}le calorie bruciate sono {Kcal} Kcal");
            bpm.Add($"{surname};{name}; {sesso};{anni};{kg};{ore};{max};{sportivo};{bpmriposo};{bpmrisultato};{Kcal}");
        }

        private void btnNuovo_Click(object sender, RoutedEventArgs e)
        {
            txtNome.Clear();
            txtCognome.Clear();
            txtAnni.Clear();
            txtCalorie.Clear();
            txtKg.Clear();
            txtMax.Clear();
            txtOre.Clear();
            txtSportivo.Clear();
            M.IsChecked = null;
            F.IsChecked = null;
            txtSportivo.IsEnabled = false;
            txtMax.IsEnabled = false;
            txtCalorie.IsEnabled = false;
            txtrisultato.IsEnabled = false;


        }

        private void btnStampa_Click(object sender, RoutedEventArgs e)
        {
           bpm.Sort();
            using (StreamWriter w = new StreamWriter("Bpm.csv", false, Encoding.UTF8))
            {
                w.WriteLine("cognome;nome;sesso;anni;kg;ore;max;sportivo;bpm riposo;bpm risultato;calorie");
                foreach (string lblRisultato in bpm)

                {
                    w.WriteLine(lblRisultato);
                }
                w.Flush();
                w.Close();

            }

        }
    }
}

