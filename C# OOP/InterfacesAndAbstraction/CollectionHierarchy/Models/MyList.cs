using CollectionHierarchy.Contracts;

namespace CollectionHierarchy.Models
{
    public class MyList : MLandArcCommon, IMyList
    {
        public int Used => this.modelList.Count;

        public string Remove()
        {
            var index = 0;
            var element = this.modelList[index];
            this.modelList.RemoveAt(index);
            return element;
        }
    }
}
