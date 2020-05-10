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
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 将factor集合按水平数从小到大排列
        /// </summary>
        /// <param name="factor">存放输入结果的factor集合</param>
        private void sortByHorizontalNumber(List<List<string>> factor)
        {
            for (int i = 0; i < factor.Count - 1; i++)
            {
                int flag = 1;
                for (int j = 0; j < factor.Count - 1 - i; j++)
                {
                    if (factor[j].Count > factor[j + 1].Count)
                    {
                        List<string> mid;
                        mid = factor[j];
                        factor[j] = factor[j + 1];
                        factor[j + 1] = mid;
                        flag = 0;
                    }
                }
                if (flag == 1) break;
            }
        }

        /// <summary>
        /// 生成用于查询正交表的字符串
        /// </summary>
        /// <param name="factor">存放输入结果的factor集合</param>
        /// <returns>用于查询正交表的字符串</returns>
        private string buildQueryString(List<List<string>> factor) 
        {
            string query = "";
            List<int> count = new List<int>();
            int sum = 0;
            for (int i = 0; i < factor.Count; i++)
            {
                if (sum != factor[i].Count)
                {
                    sum = factor[i].Count;
                    count.Add(1);
                }
                else
                {
                    count[count.Count - 1] = count.Last() + 1;
                }
            }
            sum = 0;
            for (int i = 0; i < count.Count; i++)
            {
                if (i != 0)
                    query += " ";
                sum += count[i];
                query += factor[sum - 1].Count - 1 + "^" + count[i];
            }
            return query;
        }
        /// <summary>
        /// 将输入字符串的一行拆分成一个因素和多个水平
        /// </summary>
        /// <param name="p">输入字符串的一行</param>
        /// <returns>切割好的一个因素</returns>
        private List<string> splitInputLine(ref string p)
        {
            List<string> oneFactor;
            string[] temp = Regex.Split(p, ":|,|：|，", RegexOptions.IgnoreCase);
            oneFactor = temp.ToList();
            return oneFactor;
        }
        /// <summary>
        /// 查询正交表，匹配生成正交测试用例
        /// </summary>
        /// <param name="query">用于查询正交表的字符串</param>
        /// <param name="factor">存放输入结果的factor集合</param>
        private async Task<string> generateTestCases(string query, List<List<string>> factor)
        {
            string result = "";
            await Task.Run(()=> {
                
                //根据_query查找对应正交表
                #region
                string[] table = File.ReadAllLines("../../ts723_Designs.txt");
                int hitIndex = 0;
                try
                {
                    foreach (string temp in table)
                    {
                        hitIndex++;
                        if (query == temp)
                        {
                            throw new Exception();
                        }
                    }
                }
                catch (Exception e) { }
                // 没有对应正交表
                if (hitIndex == table.Length)
                {

                    MessageBox.Show("没有对应正交表");
                    return;
                }
                #endregion
                /**
                 * 根据正交表，生成测试用例
                 */
                #region
                int i = factor.Count - 1;
                int oneFactorSum = 0;
                int oneFactorNum = 0;
                hitIndex += 2;
                string line = table[hitIndex];
                while (line != "#")
                {
                    if (i == -1)
                        i = factor.Count - 1;
                    string text = "";
                    for (int j = line.Length - 1; j >= 0; j--)
                    {
                        oneFactorSum = factor[i].Count - 1;
                        if (oneFactorSum > 11 && j - 1 >= 0)
                        {
                            oneFactorNum = Convert.ToInt32(line[j - 1].ToString() + line[j].ToString()) + 1;
                            j--;
                        }
                        else
                        {
                            oneFactorNum = Convert.ToInt32(line[j].ToString()) + 1;
                        }
                        text = "\t" + text;
                        text = (factor[i])[oneFactorNum] + text;
                        oneFactorNum = 0;
                        i--;
                    }
                    result = result + text + "\r\n";
                    hitIndex++;
                    line = table[hitIndex];
                }
                #endregion
            });
            return result;
            
        }
        /// <summary>
        /// 程序测试用例生成功能入口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void submit_click(object sender, RoutedEventArgs e)
        {
            result.Text = ""; //刷新结果文本框
        
            //切割输入字符串
            #region
            //factor变量
            //用处:factor用于存放切割输入字符串的结果
            //结构:factor每个元素都是一个list，一个list代表着一个因子和它的水平取值
            //举例:如果输入为"操作系统:centos,windows,ubuntu",那么factor只有一个元素(list)，factor[0][0]="操作系统"，factor[0][1]="centos"...
            List<List<string>> factor = new List<List<string>>();
            string[] temp = Regex.Split(input.Text, "\\\r\\\n", RegexOptions.IgnoreCase); //根据换行符，切割每个因素
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] == "") continue;
                factor.Add(splitInputLine(ref temp[i])); //切割每行因素的水平
            }
            #endregion

            //构建能查询ts723_Designs.txt对应正交表的字符串
            //例如 2^3 n=4
            sortByHorizontalNumber(factor);
            string query = "";
            query = buildQueryString(factor);

            var resultTemp= await generateTestCases(query, factor);//生成测试用例
            result.Text = resultTemp;
        }
        private void exit_click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
