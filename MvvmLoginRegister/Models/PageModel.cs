using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmLoginRegister.Models
{
    public class PageModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public PageModel(int sk, int tk)
        {
            this.skip = sk;
            this.take = tk;
        }

        private int totalPageNo;
        public int TotalPageNo
        {
            get { return totalPageNo; }
            set { totalPageNo = value; OnPropertyChanged("TotalPageNo"); }
        }

        private int currentPageNo;
        public int CurrentPageNo
        {
            get { return currentPageNo; }
            set { currentPageNo = value; OnPropertyChanged("CurrentPageNo"); }
        }

        private int skip;
        public int Skip
        {
            get { return skip; }
            set { skip = value; }
        }

        private int take;
        public int Take
        {
            get { return take; }
            set { take = value; }
        }
    }
}
