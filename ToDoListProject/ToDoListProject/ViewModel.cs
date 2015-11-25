using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ToDoListProject
{
    public class ViewModel : INotifyPropertyChanged
    {
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value;
            onPropertyChanged("id");
            }
        }

        private string _name;
        public string name
        {
            get { return _name; }
            set { _name = value;
            onPropertyChanged("name");
            }
        }

        private bool _changed;
        public bool changed
        {
            get { return _changed; }
            set { _changed = value;
            onPropertyChanged("changed");    
            }
        }

        private ICommand _addToList;
        public ICommand addToList
        {
            get {
                if (_addToList == null)
                {
                    _addToList = new Command(AddToList, CanAddToList);
                }
                return _addToList; }
            set { _addToList = value; }
        }

        private ICommand _removeFromList;
        public ICommand removeFromList
        {
            get {
                if (_removeFromList == null)
                {
                    _removeFromList = new Command(RemoveFromList, CanRemoveFromList);
                }
                return _removeFromList; }
            set { _removeFromList = value; }
        }

        private ICommand _editList;

        public ICommand editList
        {
            get {
                if (_editList == null)
                {
                    _editList = new Command(EditList, CanEditList);
                }
                return _editList; }
            set { _editList = value; }
        }
        
        


        private void AddToList()
        { 
        }
        private bool CanAddToList()
        {
            return true;
        }

        private void RemoveFromList()
        {
        }
        private bool CanRemoveFromList()
        {
            return true;
        }
        
        private void EditList()
        {

        }
        private bool CanEditList()
        {
            return true;
        }
        
        
        public event PropertyChangedEventHandler PropertyChanged;
        private void onPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
