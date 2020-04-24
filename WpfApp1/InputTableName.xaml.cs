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
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для InputTableName.xaml
    /// </summary>
    public partial class InputTableName : Window
    {
        ComboBox Tables;
        List<string> TableNamesList = new List<string>();
        public InputTableName()
        {
            InitializeComponent();
            Tables = TablesNames;
            string ConString = @"Data Source=DESKTOP-ITGU7A9\SQLEXPRESS; Initial Catalog=РаботникиNEW; Integrated Security = True;";
            SqlConnection connection = new SqlConnection(ConString);
            connection.Open();
            string CMDstring = $"SELECT name FROM sysobjects WHERE type = 'U' OR type = 'V'";
            SqlCommand command = new SqlCommand(CMDstring, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                TableNamesList.Add(reader[0].ToString());
            }
            
            Tables.ItemsSource = TableNamesList;
        }

         

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        public string TableName 
        { 
            get 
            {
                if (Tables.SelectedItem==null)
                {
                    return null;
                }
                else
                {
                    return Tables.SelectedItem.ToString();
                }
                 
            } 
            set 
            {
                
            } 
        }
    }
}
