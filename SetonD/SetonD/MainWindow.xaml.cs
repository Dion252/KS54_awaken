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
using SetonD.WindS;

namespace SetonD
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        List<Person> peoplelist = new List<Person>();

        public MainWindow()
        {

            for (int i = 1; i < 3; i++)
            {
                peoplelist.Add(new Person
                {
                    ID = i,
                    Name = $"Пользователь{i}",
                    Login = $"User{i}",
                    Password = $"Pass{i}",
                }
                  );

            }

            InitializeComponent();
        }

        private void Login1(object sender, RoutedEventArgs e)
        {
            if (Login.Text == "Логин")
            {
                Login.Clear();
            }
        }

        private void Login_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Login.Text == "")
            {
                Login.Text = "Логин";
            }
        }


        private void Password1_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Password.Text == "Пароль")
            {
                Password.Clear();
            }
        }

        private void Password_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Password.Text == "")
            {
                Password.Text = "Пароль";
            }
        }

        private void CapchaEnter_GotFocus(object sender, RoutedEventArgs e)
        {
            if (CapchaEnter.Text == "Символы на рисунке")
            {
                CapchaEnter.Clear();
            }
        }

        private void CapchaEnter_LostFocus(object sender, RoutedEventArgs e)
        {
            if (CapchaEnter.Text == "")
            {
                CapchaEnter.Text = "Символы на рисунке";
            }
        }

        

        
        
            private void Capcha1_Click(object sender, RoutedEventArgs e)
            {
                Random rnd = new Random();
                string text = "";
                string simvol = "123456789QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";
                for (int i = 0; i < 5; i++)
                {
                    text += simvol[rnd.Next(simvol.Length)];
                }
                CapchaBlock1.Text = text;
            }

        bool b = false;


        private void SaveInfo_Checked(object sender, RoutedEventArgs e)
        {
            b = true;
        }
       

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            bool a = false;

            if (peoplelist.Where(pl => pl.Login == Login.Text && pl.Password == Password.Text).FirstOrDefault() != null)
            {
                //MessageBox.Show("Авторизация проведена успешно");
                DoneWindow1 DW = new DoneWindow1();
                this.Hide();
                DW.ShowDialog();
                this.Close();
            }

            else
            {
                HidenObj1.Visibility = Visibility; HidenObj2.Visibility = Visibility; CapchaEnter.Visibility = Visibility;
                

                Random rnd = new Random();
                string text = "";
                string simvol = "123456789QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";
                for (int i = 0; i < 5; i++)
                {
                    text += simvol[rnd.Next(simvol.Length)];
                }
                CapchaBlock1.Text = text;

                a = true;
            }

            if (a==true)
            {
                if (peoplelist.Where(pl => pl.Login == Login.Text && pl.Password == Password.Text).FirstOrDefault() != null && CapchaBlock1.Text == CapchaEnter.Text)
                {
                    MessageBox.Show("Авторизация проведена успешно");
                }
                else
                {
                    MessageBox.Show("Что-то пошло не так.     " +
                                    "Проверьте логин и пароль.     " +
                                    "Проверьте правильность капчи.");
                }
            }

            if (b == true)
            {
                Login.Text = Login.Text;
                Password.Text = Password.Text;

                    //SaveInfo.Checked = Properties.Settings.Default.IsRemember;
                
                    //Properties.Settings.Default.IsRemember = checkBox1.Checked;
                    //Properties.Settings.Default.Save();
            }

            
            
        }

        //MessageBox.Show($"Что-то пошло не так.   " +
        //                        "Проверьте логин и пароль.   " +
        //                        "Введите капчу.");

    }
}
