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
using System.ComponentModel;
using Notifier.Commands;

namespace Notifier
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public List<Notice> Notices;

        public MainWindow(/*ref List<Notice> notices*/)
        {
            InitializeComponent();
            //App.Notices = notices;

            this.noticesList.ItemsSource = App.Notices;

            /*this.noticesList.Columns[3].Visible = false;
            this.noticesList.Columns[4].Visible = false;
            this.noticesList.Columns[5].Visible = false;
            this.noticesList.Columns[6].Visible = false;*/

            /*System.Windows.Forms.NotifyIcon ni = new System.Windows.Forms.NotifyIcon();
            ni.Icon = new System.Drawing.Icon("Main.ico");
            ni.Visible = true;
            ni.DoubleClick +=
                delegate (object sender, EventArgs args)
                {
                    this.Show();
                    this.WindowState = WindowState.Normal;
                };*/
        }
        
        private void MainMenuNewNotice_Click(object sender, RoutedEventArgs e)
        {
            Commands.ICommand Command = new CreateNewNotice(ref App.Notices);
            Command.Execute();
        }

        private void MainMenuExit_Click(object sender, RoutedEventArgs e)
        {
            Commands.ICommand Command = new NotifierShutdown();
            Command.Execute();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            this.noticesList.Items.Refresh();
        }
    }
}
