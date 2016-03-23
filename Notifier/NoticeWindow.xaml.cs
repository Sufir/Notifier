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
using System.Windows.Shapes;

namespace Notifier
{
    /// <summary>
    /// Логика взаимодействия для NoticeWindow.xaml
    /// </summary>
    public partial class NoticeWindow : Window
    {
        protected Notice Notice;
        //protected List<Notice> Notices;

        public NoticeWindow(Notice notice/*, ref List<Notice> notices*/)
        {
            InitializeComponent();
            this.Notice = notice;
            this.DataContext = notice;

            //this.Notices = notices;

            /*Binding bind = new Binding();
            bind.Source = this.NoticeTitle;
            bind.Path = new PropertyPath("Text");
            bind.Mode = BindingMode.TwoWay;
            this.NoticeTitle.SetBinding(TextBox.TextProperty, bind);*/

            /*Binding bind = new Binding();
            bind.Source = this.Notice;
            bind.Path = new PropertyPath("title");
            bind.Mode = BindingMode.TwoWay;
            this.NoticeTitle.SetBinding(TextBox.TextProperty, bind);*/

            /* Text="{Binding ElementName=NoticeTitle, Path=Text, Mode=TwoWay}" */

            /*DependencyProperty dp = DependencyProperty.Register("title", typeof(String), typeof(Notice));
            this.NoticeTitle.SetBinding(dp, new Binding("title"));*/
    }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            App.Notices.Add(this.Notice);
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (this.Notice != null)
            {
                this.Notice.title = "Qwery...";
            }
        }
    }
}
