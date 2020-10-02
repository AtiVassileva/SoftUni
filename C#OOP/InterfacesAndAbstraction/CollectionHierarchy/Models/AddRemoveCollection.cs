using CollectionHierarchy.Contracts;

namespace CollectionHierarchy.Models
{
    public class AddRemoveCollection : MLandArcCommon, IAddRemoveCollection
    {
        
        public string Remove()
        {
            var index = this.modelList.Count - 1;
            var element = this.modelList[index];
            this.modelList.RemoveAt(index);

            return element;
        }
    }
}
