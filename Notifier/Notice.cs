using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;


namespace Notifier
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    class MagicAttribute : Attribute { }
    class NoMagicAttribute : Attribute { }

    [Magic]
    public class Notice : INotifyPropertyChanged
    {
        public String title { set; get; } = "Новое событие...";
        public String description { set; get; } = "";
        public DateTime date { set; get; } = DateTime.Now;
        public Boolean sometime { set; get; } = false;
        public TimeSpan interval { set; get; }
        public Boolean repeat { set; get; } = false;

        [NoMagic]
        public String eventDate
        {
            get
            {
                if (this.date.Year == DateTime.Now.Year)
                {
                    return (this.sometime) ? this.date.ToString("dd MMMM в HH:mm") : this.date.Date.ToString("dd MMMM");
                }
                else
                {
                    return (this.sometime) ? this.date.ToString("dd MMMM yyyy г. в HH:mm") : this.date.Date.ToString("dd MMMM yyyy г.");
                }
            }
        }

        [NoMagic]
        public String periodicity
        {
            get
            {
                return (!this.repeat || this.interval == null) ? "Один раз" : this.intervalPretty();
            }
        }

        public Notice()
        {
            this.interval = new TimeSpan(24, 0, 0);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged(string propName)
        {
            var e = this.PropertyChanged;
            if (e != null)
            {
                e(this, new PropertyChangedEventArgs(propName));
                //MessageBox.Show(propName + ": " + this.title);
            }
        }

        private String intervalPretty()
        {
            String result = "";

            if (this.interval.Days > 0)
            {
                result += " " + this.interval.Days + " " + this.declOfNum(this.interval.Days, new String[3] { "день", "дня", "дней", });
            }

            if (this.interval.Hours > 0)
            {
                result += " " + this.interval.Hours + " " + this.declOfNum(this.interval.Hours, new String[3] { "час", "часа", "часов", });
            }

            if (this.interval.Minutes > 0)
            {
                result += " " + this.interval.Minutes + " " + this.declOfNum(this.interval.Minutes, new String[3] { "минута", "минуты", "минут", });
            }

            if (this.interval.Minutes > 0)
            {
                result = this.declOfNum(this.interval.Minutes, new String[3] { "Каждую", "Каждые", "Каждые", }) + " " + result;
            }
            else if (this.interval.Hours > 0)
            {
                result = this.declOfNum(this.interval.Hours, new String[3] { "Каждый", "Каждые", "Каждые", }) + " " + result;
            }
            else if (this.interval.Days > 0)
            {
                result = this.declOfNum(this.interval.Days, new String[3] { "Каждый", "Каждые", "Каждые", }) + " " + result;
            }
            else
            {
                result = "Не установлено!";
            }

            return result;
        }

        private String declOfNum(int number, String[] titles)
        {
            int[] cases = { 2, 0, 1, 1, 1, 2 };
            return titles[(number % 100 > 4 && number % 100 < 20) ? 2 : cases[Math.Min(number % 10, 5)]];
        }
    }
}
