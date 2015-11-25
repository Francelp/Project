using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ToDoListProject
{
    public class ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ToDoItem> _toDoItem;
        public ObservableCollection<ToDoItem> toDoItem
        {
            get { return _toDoItem; }
            set { _toDoItem = value;
            onPropertyChanged("toDoItem");
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

        private ICommand _complete;

        public ICommand complete
        {
            get {
                if (_complete == null)
                {
                    _complete = new Command(Complete,CanComplete);
                }
                return _complete; }
          set { _complete = value; }
        }

        private bool CanComplete()
        {
          throw new NotImplementedException();
        }

        private void Complete()
        {
          throw new NotImplementedException();
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
