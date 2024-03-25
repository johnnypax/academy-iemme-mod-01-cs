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
using WPF_lez05_task_eventi.DAL;
using WPF_lez05_task_eventi.Models;

namespace WPF_lez05_task_eventi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            dgContatti.ItemsSource = PartecipanteDAL.getIstanza().GetAll();
        }

        private void btnSalva_Click(object sender, RoutedEventArgs e)
        {
            string? nomin = this.tbNominativo.Text;
            string? telef = this.tbTelefono.Text;

            Partecipante temp = new Partecipante()
            {
                Nome = nomin,
                Telefono = telef,
            };

            if (PartecipanteDAL.getIstanza().Insert(temp))
            {
                MessageBox.Show("Tutto ok!");
                dgContatti.ItemsSource = PartecipanteDAL.getIstanza().GetAll();
            }
            else
                MessageBox.Show("Errore di inserimento");

            this.tbNominativo.Text = "";
            this.tbTelefono.Text = "";
        }
    }
}