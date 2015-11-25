using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoListProject;

namespace TestsToDo
{
  /// <summary>
  /// Summary description for AddTest
  /// </summary>
  [TestClass]
  public class AddTest
  {
    ViewModel viewModel;

    [TestInitialize]
    public void Setup()
    {
      viewModel = new ViewModel();
    }

    [TestMethod]
    public void Test_Complete_SelectedItemKeptTrue_WhenItIsTrue()
    {
      //Arrange
      viewModel.toDoItemList.Add(new ToDoItem("", true));
      viewModel.selectedItemToDo = new ToDoItem("", true);

      //Act
      viewModel.Complete();

      //Assert
      Assert.IsTrue(viewModel.selectedItemToDo.changed);
    }
    [TestMethod]
    public void Test_Complete_ChangesSelectedItemChangedToTrue_WhenItIsFalse()
    {
      //Arrange
      viewModel.toDoItemList.Add(new ToDoItem("", true));
      viewModel.selectedItemToDo = new ToDoItem("", false);

      //Act
      viewModel.Complete();

      //Assert
      Assert.IsTrue(viewModel.selectedItemToDo.changed);
    }
    [TestMethod]
    public void Test_Complete_DoesntChangeIfNothingInList()
    {
      //Arrange
      viewModel.selectedItemToDo = new ToDoItem("", false);

      //Act
      viewModel.Complete();

      //Assert
      Assert.IsFalse(viewModel.selectedItemToDo.changed);
    }
    [TestMethod]
    public void Test_CanComplete_ReturnsTrue_WhenCalled()
    {
      //Arrange
      //Act
      bool actualValue = viewModel.CanComplete();
      //Assert
      Assert.IsTrue(actualValue);
    }
  }
}
