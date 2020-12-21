using System.Text;
using System.Collections.Generic;

namespace GenericSwapMethods
{
    public class Swapper<T>
    {
        public List<T> List { get; set; }

        public Swapper(List<T> list)
        {
            this.List = list;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            if (List.Count > firstIndex && List.Count > secondIndex && firstIndex > -1 && secondIndex > -1)
            {
                var temp = List[firstIndex];
                List[firstIndex] = List[secondIndex];
                List[secondIndex] = temp;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var item in this.List)
            {
                sb.AppendLine($"{typeof(T)}: {item}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}