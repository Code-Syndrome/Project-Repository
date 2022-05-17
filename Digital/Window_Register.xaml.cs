using System;
using System.Collections;
using System.Windows;
using System.Windows.Input;
using Window = System.Windows.Window;

namespace Digital
{
    public partial class Window_Register : Window
    {
        public static Hashtable userall;
        public Window_Register()
        {
            InitializeComponent();
        }
        private void Register_Button(object sender, RoutedEventArgs e)
        {
            string u = Re_Account.Text.ToString();
            string p = Re_Password.Password.ToString();
            string rp = Re_PasswordAgain.Password.ToString();
            SqlConnect sqlconnect = new SqlConnect();


            if (string.IsNullOrEmpty(u))
            {
                MessageBox.Show("user is not null");
                return;
            }
            if (string.IsNullOrEmpty(p))
            {
                MessageBox.Show("password is not null");
                return;
            }
            if (string.IsNullOrEmpty(rp))
            {
                MessageBox.Show("Repassword is not null");
                return;
            }
            if (!p.Equals(rp))
            {
                MessageBox.Show("password is not equals repassword");
                return;
            }

            userall = sqlconnect.Sql_Read();
            if (userall == null)
            {
                userall = new Hashtable();
                userall.Add(u, p);
            }
            else
            {
                bool isexist = userall.ContainsKey(u);
                if (isexist)
                {
                    MessageBox.Show("user is exist!");
                    return;
                }
                else
                {
                    userall.Add(u, p);
                    Console.WriteLine(userall.Count);
                }
            }

            System.Windows.Application.Current.Properties["user"] = userall;
            sqlconnect.Sql_Insert(u, p);
            MessageBox.Show("regist success!");

            Window_Main main = new Window_Main();
            main.WindowStartupLocation = WindowStartupLocation.Manual;
            main.Left = this.Left;
            main.Top = this.Top;
            this.Close();
            main.ShowDialog();
        }

        private void MoveWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ReClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ReMin_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void TextBlock_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            // 跳转登录页面
            Window_Login login = new Window_Login();
            Close();
            login.ShowDialog();
        }
    }
}