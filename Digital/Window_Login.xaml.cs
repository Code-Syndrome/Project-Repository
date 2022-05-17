using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Digital
{
    public partial class Window_Login : Window
    {
        public string UserName;
        public string UserPassword;
        public int border = 1;
        public static Hashtable userall_harsh;

        public Window_Login()
        {
            InitializeComponent();
        }

        private void MoveWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Login_Button(object sender, RoutedEventArgs e)
        {
            SqlConnect sqlconnect = new SqlConnect();
            userall_harsh = sqlconnect.Sql_Read();

            if (userall_harsh == null)
            {
                MessageBox.Show("无此账户，请先注册!");
                return;
            }
            else
            {
                IDictionaryEnumerator Enumerator = userall_harsh.GetEnumerator();
                while (Enumerator.MoveNext())
                {

                    UserName = Enumerator.Key.ToString();
                    UserPassword = Enumerator.Value.ToString();

                    if (Account.Text.ToString() == UserName && Password.Password.ToString() == UserPassword)
                    {
                        this.DialogResult = Convert.ToBoolean(1);
                        this.Close();
                        break;
                    }
                    else if (border <= userall_harsh.Count - 1)
                    {
                        border++;
                    }
                    else
                        MessageBox.Show("账号或密码错误，请重试！");
                }
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            // 关闭
            Close();
        }

        private void Min_Click(object sender, RoutedEventArgs e)
        {
            // 最小化
            WindowState = WindowState.Minimized;
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // 跳转注册页面
            Window_Register register = new Window_Register();
            Close();
            register.ShowDialog();
        }
    }
}


