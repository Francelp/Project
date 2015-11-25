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

    public ToDoItem(string Name, bool Changed)
    {
      name = Name;
      changed = Changed;
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
