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

namespace WPF_lez03_TextBox
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

        private void btnSalva_Click(object sender, RoutedEventArgs e)
        {
            string nome = this.txtNome.Text;
            string cogn = this.txtCognome.Text;

            if (nome.Trim().Equals("") || cogn.Trim().Equals(""))
            {
                MessageBox.Show("Errore nome o cognome");
                return;
            }
                
            this.txtRisultato.Text = $"Nominativo inserito: {nome} {cogn}";
        }

        private void txtProfessione_SelectionChanged(object sender, RoutedEventArgs e)
        {
            lblProf.Content = txtProfessione.Text;
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListViewItem? lvi = sender as ListViewItem;
            if (lvi != null)
            {
                MessageBox.Show($"Hai cliccato su: {lvi.Content}");
            }
        }
    }
}