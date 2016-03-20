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
       protected List<Notice> Notices = new List<Notice>();
        protected MainWindow mw;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            this.Notices.Add(new Notice());
            this.Notices.Add(new Notice());

            Notice notice = new Notice();
            notice.sometime = true;
            notice.repeat = true;
            notice.interval = new TimeSpan(7, 1, 2, 0);
            this.Notices.Add(notice);

            this.mw = new MainWindow(this.Notices);
            this.mw.Show();
        }
    }
}
