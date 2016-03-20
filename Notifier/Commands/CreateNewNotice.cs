using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifier.Commands
{
    class CreateNewNotice : ICommand
    {
        private Window Window;

        public CreateNewNotice()
        {
            Notice notice = new Notice();
            this.Window = new NoticeWindow(notice);
        }

        public CreateNewNotice(Window window)
        {
            this.Window = window;
        }

        public void Execute()
        {
            this.Window.ShowDialog();
        }
    }
}
