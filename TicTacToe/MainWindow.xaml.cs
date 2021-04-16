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

namespace TicTacToe
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string playerToggle { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            playerToggle = "O";
            foreach (UIElement item in MainRoot.Children)
            {
                if (item is Button)
                {
                    ((Button)item).Click += Button_Click;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((string)((Button)e.OriginalSource).Content == string.Empty)
            {
                ((Button)e.OriginalSource).Content = playerToggle;
                if (CheckWinner())
                {
                    MessageBox.Show("Выиграл " + playerToggle);
                }
                if (playerToggle == "X")
                {
                    playerToggle = "O";
                }
                else
                {
                    playerToggle = "X";
                }


            }
        }

        private bool CheckWinner()
        {
            for (int i = 0; i < 3; i++)
            {
                if (((string)((Button)MainRoot.Children[i * 3]).Content != ""
                    && ((Button)MainRoot.Children[i * 3]).Content == ((Button)MainRoot.Children[i * 3 + 1]).Content
                    && ((Button)MainRoot.Children[i * 3]).Content == ((Button)MainRoot.Children[i * 3 + 2]).Content)
                    ||
                       ((string)((Button)MainRoot.Children[i]).Content != ""
                    && ((Button)MainRoot.Children[i]).Content == ((Button)MainRoot.Children[i+3]).Content
                    && ((Button)MainRoot.Children[i]).Content == ((Button)MainRoot.Children[i+6]).Content))
                {
                    return true;
                }
            }

            if (((string)((Button)MainRoot.Children[0]).Content != "" 
                && ((Button)MainRoot.Children[0]).Content == ((Button)MainRoot.Children[4]).Content
                && ((Button)MainRoot.Children[0]).Content == ((Button)MainRoot.Children[8]).Content) 
                ||
                ((string)((Button)MainRoot.Children[2]).Content != "" 
                && ((Button)MainRoot.Children[2]).Content == ((Button)MainRoot.Children[4]).Content
                && ((Button)MainRoot.Children[2]).Content == ((Button)MainRoot.Children[6]).Content))
            {
                return true;
            }

            return false;
        }
    }
}
