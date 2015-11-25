using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListProject
{
    public class AddToList
    {
        public List<string> AddToList(List<string> listToAddTo, string itemToAdd)
        {
            List<string> newList = listToAddTo.Add(itemToAdd);

            return newList;
        }
    }
}
