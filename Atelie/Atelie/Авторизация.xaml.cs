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
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Atelie
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string connectionString;
        public MainWindow()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings
                ["Atelie.Properties.Settings.AtelieConnectionString"].ConnectionString;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand("select *  from [avtoriz] where [avtoriz].[login] = '"
                            + Логин.Text + "'and [avtoriz].[Password] = '" + Пароль.Text + "'", connection);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)//если естьданные 
                        {
                            while (reader.Read())// построчно считываем данные
                            {
                                string rol = reader.GetValue(3).ToString();
                                MessageBox.Show("Добро пожаловать! " + rol + " " + reader.GetValue(4).ToString());

                                switch (rol)
                                {
                                    case "Директор":
                                        Ателье w1 = new Ателье(); w1.Show(); this.Close();
                                        break;
                                    case "Администратор":
                                        Ателье w2 = new Ателье(); w2.Show(); this.Close();
                                        break;
                                    case "Швея":
                                        Ателье w3 = new Ателье(); w3.Show(); this.Close();
                                        break;

                                    default:
                                        MessageBox.Show("Неизвестная роль");
                                        break;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Такого пользователя нет");
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Введите корректные данные");
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Регистрация w2 = new Регистрация();
            w2.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
    }

