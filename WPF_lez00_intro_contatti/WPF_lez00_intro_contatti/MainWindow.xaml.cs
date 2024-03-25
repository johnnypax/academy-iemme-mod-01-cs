using Microsoft.VisualBasic.ApplicationServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_lez00_intro_contatti.Models;

namespace WPF_lez00_intro_contatti
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Persona> personas = new List<Persona>();

        public MainWindow()
        {
            InitializeComponent();

            using (EfLez02OneToManyContext ctx = new EfLez02OneToManyContext())
            {
                personas = ctx.Personas.ToList();
                dgSimple.ItemsSource = personas;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Persona tmp = new Persona()
            {
                Nome = this.tbNome.Text,
                Cognome = this.tbCognome.Text,
                Email = this.tbEmail.Text,
            };

            using (EfLez02OneToManyContext ctx = new EfLez02OneToManyContext())
            {
                try
                {
                    ctx.Personas.Add(tmp);
                    ctx.SaveChanges();  // Save the changes to the database

                    personas = ctx.Personas.ToList();  // Refetch the updated data
                    dgSimple.ItemsSource = personas;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
               
            }
        }
    }
}