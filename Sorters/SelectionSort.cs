namespace Sorter.Sorters
{
    public class SelectionSort
    {
        public SelectionSort() { }

        public List<int> SelectionSorter(List<int> input)
        {
            int minindex = 0;
            int minVal = 0;
            for(int i = 0; i < input.Count; i++)
            {
                for(int f = i+1; f < input.Count; f++)
                {
                    if (input[f] < input[minindex])
                    {
                        minindex = f;
                        minVal = input[f];
                    }
                }
                int tmpVal = input[i];
                input[i] = input[minindex];
                input[minindex] = tmpVal;
            }
            return input;
        }
    }
}
