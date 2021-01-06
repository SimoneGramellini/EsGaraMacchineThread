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
using System.Threading;

namespace EsercizioGaraMacchineThread
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> classifica = new List<string>();
        string output = "Ecco i risultati della gara!\n";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnIniziaGara_Click(object sender, RoutedEventArgs e)
        {
            btnIniziaGara.IsEnabled = false;

            btnIniziaGara.Content = "Attendere...";

            Thread tGara = new Thread(new ThreadStart(IniziaGara));
            tGara.Start();
        }

        private void IniziaGara()
        {
            Thread t1 = new Thread(new ThreadStart(muoviMacchina1));
            t1.Start();

            Thread t2 = new Thread(new ThreadStart(muoviMacchina2));
            t2.Start();

            Thread t3 = new Thread(new ThreadStart(muoviMacchina3));
            t3.Start();

            t1.Join();
            t2.Join();
            t3.Join();

            MessageBox.Show(output);
        }

        public void muoviMacchina1()
        {
            try
            {
                for (int i = 30; i < 450; i += 10)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(0.03));
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        macchina1.Margin = new Thickness(i, 10, 0, 0);
                    }));
                }
                output += "macchina1\n";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void muoviMacchina2()
        {
            try
            {
                for (int i = 30; i < 450; i += 10)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(0.03));
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        macchina2.Margin = new Thickness(i, 140, 0, 0);
                    }));
                }
                output += "macchina2\n";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void muoviMacchina3()
        {
            try
            {
                for (int i = 30; i < 450; i += 10)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(0.03));
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        macchina3.Margin = new Thickness(i, 145, 0, 0);
                    }));
                }
                output += "macchina3\n";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
