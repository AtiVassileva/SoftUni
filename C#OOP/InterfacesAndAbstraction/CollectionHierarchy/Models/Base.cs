using System.Collections.Generic;

namespace CollectionHierarchy.Models
{
    public abstract class Base
    {
        protected List<string> modelList;

        protected Base()
        {
            this.modelList = new List<string>();
        }

        public abstract int Add(string element);
    } 
}
