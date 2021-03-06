﻿using System;
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
    private ObservableCollection<ToDoItem> _toDoItemList;
    public ObservableCollection<ToDoItem> toDoItemList
    {
      get { return _toDoItemList; }
      set
      {
        _toDoItemList = value;
        onPropertyChanged("toDoItemList");
      }
    }

    private ToDoItem _selectedItemToDo;
    public ToDoItem selectedItemToDo
    {
      get { return _selectedItemToDo; }
      set
      {
        _selectedItemToDo = value;
        onPropertyChanged("selectedItemToDo");
      }
    }

    private ICommand _addToList;
    public ICommand addToList
    {
      get
      {
        if (_addToList == null)
        {
          _addToList = new Command<string>(AddToList, CanAddToList);
        }
        return _addToList;
      }
      set { _addToList = value; }
    }

    private ICommand _removeFromList;
    public ICommand removeFromList
    {
      get
      {
        if (_removeFromList == null)
        {
          _removeFromList = new Command(RemoveFromList, CanRemoveFromList);
        }
        return _removeFromList;
      }
      set { _removeFromList = value; }
    }

    private ICommand _editList;
    public ICommand editList
    {
      get
      {
        if (_editList == null)
        {
          _editList = new Command<string>(EditList, CanEditList);
        }
        return _editList;
      }
      set { _editList = value; }
    }

    private ICommand _complete;
    public ICommand complete
    {
      get
      {
        if (_complete == null)
        {
          _complete = new Command(Complete, CanComplete);
        }
        return _complete;
      }
      set { _complete = value; }
    }

    public ViewModel()
    {
      toDoItemList = new ObservableCollection<ToDoItem>();
    }

    private bool CanComplete()
    {
      return true;
    }

    private void Complete()
    {
      if (selectedItemToDo != null)
      {
        selectedItemToDo.changed = true;
      }
    }

    private void AddToList(string toDoItemName)
    {
      if (toDoItemName != "")
      {
        ToDoItem newItem = new ToDoItem(toDoItemName, false);
        toDoItemList.Add(newItem);


        selectedItemToDo = toDoItemList[0];
      }
    }
    private bool CanAddToList(string toDoItemName)
    {
      return true;
    }

    private void RemoveFromList()
    {
      if (toDoItemList.Contains(selectedItemToDo))
      {
        toDoItemList.Remove(selectedItemToDo);
      }
    }
    private bool CanRemoveFromList()
    {
      return true;
    }

    private void EditList(string toDoItemName)
    {
      if (toDoItemName != "" && selectedItemToDo != null)
      {
        selectedItemToDo.name = toDoItemName;
      }
    }
    private bool CanEditList(string toDoItemName)
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
