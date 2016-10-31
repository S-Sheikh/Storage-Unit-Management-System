using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using StorageUnitManagementSystem.Annotations;

namespace StorageUnitManagementSystem.BL.Binding
{
    class LabelBinding : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        private string _myContent;

        public string MyContent
        {
            get
            {
                return _myContent;
            }

            set
            {
                if (_myContent == value)
                    return;

                _myContent = value;
                OnPropertyChanged("MyContent");
            }
        }
    }
}
