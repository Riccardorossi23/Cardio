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
            string name = txtNome.Text;
            string surname = txtCognome.Text;
            int anni = int.Parse(txtAnni.Text);
            int ore = int.Parse(txtOre.Text);
            int kg = int.Parse(txtKg.Text);
            int max = 220 - anni;
            txtMax.Text = max.ToString();
            int sportivo = (max * 70 / 100 + max * 90 / 100) / 2;
            txtSportivo.Text = sportivo.ToString();
            string Sport = sport.Text;
            string sesso = "";
            if (M.IsChecked == true)
            {
                sesso = "nato";

            }
            else if (F.IsChecked == true)
            {
                sesso = "nata";
            }

            lblRisultato.Content = ($"{name}{surname} frequenta {Sport}, {sesso} il {anni}. Si allena{ore} per il suo peso corporiro di:{kg}, i bpm masimo è{max} per un allenamento efficace deve avere i battiti a {sportivo}");
            bpm.Add($"{surname}, {name}, {sesso}, {anni}, {Sport},{kg}, {ore}, {max},{sportivo}");
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
            sport.SelectedValue = null;

        }

        private void btnStampa_Click(object sender, RoutedEventArgs e)
        {
           bpm.Sort();
            using (StreamWriter w = new StreamWriter("Bpm.csv", false, Encoding.UTF8))
            {
                w.WriteLine("cognome;nome;sesso;anni;kg;sport;ore;max;sportivo"); 
                foreach (string btnCalcola in bpm)

                {

                   
                    string name = txtNome.Text;
                    string surname = txtCognome.Text;
                    int anni = int.Parse(txtAnni.Text);
                    int ore = int.Parse(txtOre.Text);
                    int kg = int.Parse(txtKg.Text);
                    int max = 220 - anni;
                    txtMax.Text = max.ToString();
                    int sportivo = (max * 70 / 100 + max * 90 / 100) / 2;
                    txtSportivo.Text = sportivo.ToString();
                    string Sport = sport.Text;
                    string sesso = "";
                    if (M.IsChecked == true)

                    {
                        sesso = "M";

                    }
                    else if (F.IsChecked == true)
                    {
                        sesso = "F";
                    }
                    w.WriteLine($"{surname};{name};{sesso};{anni};{kg};{Sport};{ore};{max};{sportivo}");
                }
                w.Flush();
                w.Close();
            }

        }
    }
}

