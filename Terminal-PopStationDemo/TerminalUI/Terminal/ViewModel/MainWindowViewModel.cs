using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Terminal.ViewModel;
using System.IO;
using System.Reflection;
using TerminalLayoutService.Model;

namespace Terminal.ViewModel
{
    /// <summary>
    /// ViewModel class hosting the WCF Client call and provides
    /// the objects to the view.
    /// </summary>
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<LockerInfo> _lockers = new ObservableCollection<LockerInfo>();
        private int _columns = 0;

        public MainWindowViewModel()
        {
            LockerKioskClient client = new LockerKioskClient();
            var lockerObjFromSvc = client.GetLockers().ToList();
            lockerObjFromSvc.ForEach(_lockers.Add);

            Func<LockerInfo, int> maxcolumns = (info) => { return info.ColumnNo; };
            _columns = lockerObjFromSvc.Max(maxcolumns);
        }

        #region Properties
        /// <summary>
        /// Locker depicted as object
        /// </summary>
        public ObservableCollection<LockerInfo> Lockers
        {
            get
            {
                return _lockers;
            }

            set
            {
                _lockers = value;
            }
        }

        public int Columns
        {
            get
            {
                return _columns;
            }

            set
            {
                _columns = value;
            }

        }
        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
