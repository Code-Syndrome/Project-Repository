using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace Digital
{
    public partial class Window_Main : Window
    {
        Page_HomePage homePage;
        public Window_Main()
        {
            InitializeComponent();
            homePage = new Page_HomePage();
            CenterContent.Content = homePage;
        }

        private void MoveWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == true)
            {
                tt_photography.Visibility = Visibility.Collapsed;
                tt_Intelligence.Visibility = Visibility.Collapsed;
                tt_video.Visibility = Visibility.Collapsed;
                tt_game.Visibility = Visibility.Collapsed;
                tt_usercenter.Visibility = Visibility.Collapsed;
            }
            else
            {
                tt_photography.Visibility = Visibility.Visible;
                tt_Intelligence.Visibility = Visibility.Visible;
                tt_video.Visibility = Visibility.Visible;
                tt_game.Visibility = Visibility.Visible;
                tt_usercenter.Visibility = Visibility.Visible;
            }
        }

        private void Tg_Btn_Unchecked(object sender, RoutedEventArgs e)
        {
            img_bg.Opacity = 1;
        }

        private void Tg_Btn_Checked(object sender, RoutedEventArgs e)
        {
            img_bg.Opacity = 0.3;
        }

        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tg_Btn.IsChecked = false;
        }

        private void MinBtn_Click(object sender, RoutedEventArgs e)
        {
            // 最小化
            WindowState = WindowState.Minimized;
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            // 关闭
            Close();
        }

        private void HomePageBtn_Click(object sender, RoutedEventArgs e)
        {
            CenterContent.Content = new Frame
            {
                Content = homePage
            };
        }

        private void Photography_Click(object sender, RoutedEventArgs e)
        {
            Page_Photography Photography = new Page_Photography();
            CenterContent.Content = new Frame
            {
                Content = Photography
            };
        }

        private void Intelligence_Click(object sender, RoutedEventArgs e)
        {
            Page_Intelligence Intelligence = new Page_Intelligence();
            CenterContent.Content = new Frame
            {
                Content = Intelligence
            };
        }

        private void Video_Click(object sender, RoutedEventArgs e)
        {
            Page_Video Video = new Page_Video();
            CenterContent.Content = new Frame
            {
                Content = Video
            };
        }

        private void Game_Click(object sender, RoutedEventArgs e)
        {
            Page_Game Game = new Page_Game();
            CenterContent.Content = new Frame
            {
                Content = Game
            };
        }

        private void User_Click(object sender, RoutedEventArgs e)
        {
            Page_User User = new Page_User();
            CenterContent.Content = new Frame
            {
                Content = User
            };
        }

        private void ShoppingCart_Click(object sender, RoutedEventArgs e)
        {
            // 跳转购物车页面
            Window_ShoppingCart shoppingCart = new Window_ShoppingCart();
            App.Current.MainWindow = shoppingCart;
            shoppingCart.ShowDialog();
        }
    }
}

