using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListProject
{
    public class ViewModel
    {
        private List<string> _items;
        public List<string> items
        {
            get { return _item; }
            set { _item = value; }
        }

        public ViewModel()
        {
        }


    }
}
