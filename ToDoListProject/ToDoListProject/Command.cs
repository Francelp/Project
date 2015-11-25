using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ToDoListProject
{
  public class Command : ICommand
  {
    private readonly Action _execute;
    private readonly Func<bool> _canExecute;
    public event EventHandler CanExecuteChanged;

    //=null makes sure that if nothing entered default = null
    public Command(Action execute, Func<bool> canExecute = null)
    {
      if (execute == null)
      {
        throw new ArgumentNullException("execute");
      }

      _execute = execute;
      //if can set canExecute do it else set it to null (short hand if statement)
      _canExecute = canExecute ?? (() => true);
    }

    [DebuggerStepThrough]
    public bool CanExecute(object parameter)
    {
      try
      {
        return _canExecute();
      }
      catch
      {
        return false;
      }
    }

    public void Execute(object parameter)
    {
      if (!CanExecute(parameter))
      {
        return;
      }
      try
      {
        _execute();
      }
      catch
      {
        Debugger.Break();
      }
    }

    //constantly checks if CanExecute command can be executed 
    public void RaiseCanExecuteChanged()
    {
      CanExecuteChanged.Invoke(this, EventArgs.Empty);
    }
  }

  public class Command<T> : ICommand
  {
    private readonly Action<T> _execute;
    private readonly Func<T, bool> _canExecute;
    public event EventHandler CanExecuteChanged;

    public Command(Action<T> execute, Func<T, bool> canexecute = null)
    {
      if (execute == null)
        throw new ArgumentNullException("execute");
      _execute = execute;
      _canExecute = canexecute ?? (e => true);
    }

    [DebuggerStepThrough]
    public bool CanExecute(object p)
    {
      try
      {
        var _Value = (T)Convert.ChangeType(p, typeof(T));
        return _canExecute == null ? true : _canExecute(_Value);
      }
      catch { return false; }
    }

    public void Execute(object p)
    {
      if (!CanExecute(p))
        return;
      var _Value = (T)Convert.ChangeType(p, typeof(T));
      _execute(_Value);
    }

    public void RaiseCanExecuteChanged()
    {
      CanExecuteChanged.Invoke(this, EventArgs.Empty);
    }
  }
}
