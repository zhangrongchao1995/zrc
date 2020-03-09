using CountManagerClient.APIManager;
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

namespace CountManagerClient
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RequestAPIManager manager = new RequestAPIManager();
            manager.getSomeTypeCount(2,0).ContinueWith(t =>
            {
                TypeCount x = t.Result;
                if (x == null) {
                    MessageBox.Show("获取数据失败");
                    return;
                }
                Console.WriteLine("总共数量：" + x.count);
                x.data.ForEach(item=> { Console.WriteLine(item.rm); });
            });

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RequestAPIManager manager = new RequestAPIManager();
            manager.getUsers(0).ContinueWith(t =>
            {
                UserPage x = t.Result;
                if (x == null)
                {
                    MessageBox.Show("获取数据失败");
                    return;
                }
                Console.WriteLine("总共数量：" + x.count);
                x.data.ForEach(item => { Console.WriteLine(item.rm); });
            });
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            RequestAPIManager manager = new RequestAPIManager();
            var u = new User();
            u.bh = 666;
            u.gsm = "";
            u.shuihao = "";
            u.rm = "";
            u.lianxifs = "";
            u._id = 23;
            u.address = "湖头";
            manager.UpdateCust(u).ContinueWith(t =>
            {
                Dictionary<string, string> x = t.Result;
                if (x == null)
                {
                    MessageBox.Show("获取数据失败");
                    return;
                }
                Console.WriteLine("返回消息：" + x["mes"]);
            
            });
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            RequestAPIManager manager = new RequestAPIManager();
            var u = new User();
            u.bh = 888;
            u.gsm = "888公司";
            u.shuihao = "888税号";
            u.rm = "888人名";
            u.lianxifs = "888联系";
     
            u.address = "湖头";
            manager.AddCustMes(u).ContinueWith(t =>
            {
                GetUser x = t.Result;
                if (x == null)
                {
                    MessageBox.Show("获取数据失败");
                    return;
                }
              
                Console.WriteLine("返回消息：" + x.mes);

            });
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            RequestAPIManager manager = new RequestAPIManager();
            manager.DelCustMes(372).ContinueWith(t =>
            {
                Dictionary<string, string> x = t.Result;
                if (x == null)
                {
                    MessageBox.Show("获取数据失败");
                    return;
                }

                Console.WriteLine("返回消息：" + x["mes"]);

            });
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            RequestAPIManager manager = new RequestAPIManager();
            manager.AddPj(370,666).ContinueWith(t =>
            {
                Countmes x = t.Result;
                if (x == null)
                {
                    MessageBox.Show("获取数据失败");
                    return;
                }

                Console.WriteLine("返回消息：" + x.ToString());

            });
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            RequestAPIManager manager = new RequestAPIManager();
            manager.getShuihaoAndGs().ContinueWith(t =>
            {
                List<ShuihaoAndGs> x = t.Result;
                if (x == null)
                {
                    MessageBox.Show("获取数据失败");
                    return;
                }
                x.ForEach(item => { Console.WriteLine("返回消息：" + item.ToString()); });
              

            });
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            RequestAPIManager manager = new RequestAPIManager();
            manager.AddState(703,0).ContinueWith(t =>
            {
                Dictionary<string, string> x = t.Result;
                if (x == null)
                {
                    MessageBox.Show("获取数据失败");
                    return;
                }
                Console.WriteLine("返回消息：" + x["mes"]);
            });
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            RequestAPIManager manager = new RequestAPIManager();
            manager.updatekdnum(703, 1234321).ContinueWith(t =>
            {
                Dictionary<string, string> x = t.Result;
                if (x == null)
                {
                    MessageBox.Show("获取数据失败");
                    return;
                }
                Console.WriteLine("返回消息：" + x["mes"]);
            });
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            RequestAPIManager manager = new RequestAPIManager();
            manager.checkpassword(703, 123456).ContinueWith(t =>
            {
                Dictionary<string, string> x = t.Result;
                if (x == null)
                {
                    MessageBox.Show("获取数据失败");
                    return;
                }
                Console.WriteLine("返回消息：" + x["mes"]);
            });

        }
    }
}
