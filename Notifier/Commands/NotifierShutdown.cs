using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Notifier.Commands
{
    public class NotifierShutdown : ICommand
    {
        private Application App;

        public NotifierShutdown()
        {
            this.App = Application.Current;
        }

        public NotifierShutdown(Application app)
        {
            this.App = app;
        }

        public void Execute()
        {
            this.App.Shutdown();
        }
    }
}
