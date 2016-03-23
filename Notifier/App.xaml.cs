using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Windows.Controls;
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.DataGrid;

namespace Notifier
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static List<Notice> Notices = new List<Notice>();
        protected MainWindow mw;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            App.Notices.Add(new Notice());
            App.Notices.Add(new Notice());

            Notice notice = new Notice();
            notice.sometime = true;
            notice.repeat = true;
            notice.interval = new TimeSpan(7, 1, 2, 0);
            App.Notices.Add(notice);

            this.mw = new MainWindow();
            this.mw.Show();
        }
    }
}
