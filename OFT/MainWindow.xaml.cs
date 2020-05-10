using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading.Tasks;

namespace TCG
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private OrthogonalTest orthogonalTest;
        public MainWindow()
        {
            InitializeComponent();
            orthogonalTest = new OrthogonalTest();
            orthogonalTest.setOrthogonalTable("../../ts723_Designs.txt");
        }

        
        /// <summary>
        /// 程序测试用例生成功能入口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void submit_click(object sender, RoutedEventArgs e)
        {
            result.Text = ""; //刷新结果文本框

            result.Text = orthogonalTest.getOrthogonalResult(input.Text);
        }
        private void exit_click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
