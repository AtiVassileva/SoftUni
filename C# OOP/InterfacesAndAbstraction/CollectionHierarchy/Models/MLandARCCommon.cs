namespace CollectionHierarchy.Models
{
    public class MLandArcCommon : Base
    {
        public override int Add(string element)
        {
            var index = 0;
            this.modelList.Insert(0, element);
            return index;
        }
    }
}
