using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListProject
{
    public class ToDoItem : INotifyPropertyChanged
    {
        private int _id;
        public int id
        {
            get { return _id; }
            set
            {
                _id = value;
                onPropertyChanged("id");
            }
        }

        private string _name;
        public string name
        {
            get { return _name; }
            set
            {
                _name = value;
                onPropertyChanged("name");
            }
        }

        private bool _changed;
        public bool changed
        {
            get { return _changed; }
            set
            {
                _changed = value;
                onPropertyChanged("changed");
            }
        }
        
        public ToDoItem(int Id, string Name, bool Changed)
        {
            id = Id;
            name = Name;
            changed = Changed;
        }

    }
}
