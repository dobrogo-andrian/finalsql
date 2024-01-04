using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
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

namespace finalsql
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection connection;
        public MainWindow()
        {
            InitializeComponent();
            connection = new SqlConnection("Data Source=HYRAIKSA22;Initial Catalog=learn;Persist Security Info=True;User ID=sa;Password=***********;Pooling=False;Encrypt=False;Trusted_Connection=true");
            connection.Open();
            ShowZoos();
        }
        private void ShowZoos()
        {

            try
            {
                string query = "select * from Zoo";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, connection);
                using (sqlDataAdapter)
                {
                    DataTable zooTable = new DataTable();


                    sqlDataAdapter.Fill(zooTable);
                    listzoo.DisplayMemberPath = "Location";
                    listzoo.SelectedValuePath = "Id";
                    listzoo.ItemsSource = zooTable.DefaultView;


                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show("listzooclicked");
        }
    }
}