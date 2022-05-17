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

namespace Digital
{
    /// <summary>
    /// Page_Photography.xaml 的交互逻辑
    /// </summary>
    public partial class Page_Photography : Page
    {
        public static string connString = SqlConnect.connstring;
        SqlConnection conn = new SqlConnection(connString);
        public Page_Photography()
        {
            InitializeComponent();
        }
    }
}
