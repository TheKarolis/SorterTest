namespace Sorter.Sorters
{
    public class BubbleSorter
    {
        public BubbleSorter() { }

        public List<int> BubbleSort(List<int> numbers)
        {
            for (int i = numbers.Count- 1; i >= 0; i--)
            {
                for (int f = 0; f < i; f++)
                {
                    if (numbers[f] > numbers[f + 1])
                    {
                        int tmpNumb = numbers[f];
                        numbers[f] = numbers[f + 1];
                        numbers[f + 1] = tmpNumb;
                    }
                }
            }

            return numbers;
        }

    }
}
