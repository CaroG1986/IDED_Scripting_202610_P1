namespace IDED_Scripting_202610_P1
{
    internal class TestMethods
    {
        public static void SeparateElements(Queue<int> input, out Stack<int> included, out Stack<int> excluded)
        {
            included = new Stack<int>();
            excluded = new Stack<int>();

            Stack<int> auxIncluded = new Stack<int>();
            Stack<int> auxExcluded = new Stack<int>();

            while (input.Count > 0)
            {
                int number = input.Dequeue();

                if (BelongsToSequence(number))
                {
                    auxIncluded.Push(number);
                }
                else
                {
                    auxExcluded.Push(number);
                }
            }

            while (auxIncluded.Count > 0)
            {
                included.Push(auxIncluded.Pop());
            }

            while (auxExcluded.Count > 0)
            {
                excluded.Push(auxExcluded.Pop());
            }
        }

        private static bool BelongsToSequence(int number)
        {
            if (number == 0)
                return false;

            int value = number;
            if (value < 0)
                value = -value;

            int root = (int)Math.Sqrt(value);

            if (root * root != value)
                return false;

            if (number > 0 && root % 2 == 0)
                return true;

            if (number < 0 && root % 2 == 1)
                return true;

            return false;
        }


        public static List<int> GenerateSortedSeries(int n) => null;

        public static bool FindNumberInSortedList(int target, in List<int> list) => false;

        public static int FindPrime(in Stack<int> list) => 0;

        public static bool IsPrime(int n) => false;

        public static Stack<int> RemoveFirstPrime(in Stack<int> stack) => null;

        public static Queue<int> QueueFromStack(Stack<int> stack) => null;
    }
}