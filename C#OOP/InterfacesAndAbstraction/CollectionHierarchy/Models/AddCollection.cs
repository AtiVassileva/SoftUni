using System.Collections.Generic;
using CollectionHierarchy.Contracts;

namespace CollectionHierarchy.Models
{
    public class AddCollection : Base
    {
        public override int Add(string element)
        {
            var index = this.modelList.Count;
            this.modelList.Add(element);
            return index;
        }
    }
}
