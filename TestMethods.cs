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


        public static List<int> GenerateSortedSeries(int n)
        {
            if (n % 2 == 0)
            {
                Console.WriteLine("El tamaño debe ser impar.");
                return null;
            }

            List<int> lista = new List<int>();
            Random rnd = new Random();

           
            for (int i = 0; i < n; i++)
            {
                lista.Add(rnd.Next(0, 100));
            }

          
            for (int i = 0; i < lista.Count - 1; i++)
            {
                for (int j = 0; j < lista.Count - 1 - i; j++)
                {
                    if (lista[j] < lista[j + 1])
                    {
                        int temp = lista[j];
                        lista[j] = lista[j + 1];
                        lista[j + 1] = temp;
                    }
                }
            }

            return lista;
        }
        public static bool BuscarNumero(List<int> lista, int numero)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i] == numero)
                    return true;
            }

            return false;
        }
        public static bool FindNumberInSortedList(int target, in List<int> list) => false;

        public static int FindPrime(in Stack<int> list) => 0;

        public static bool IsPrime(int n) => false;

        public static Stack<int> RemoveFirstPrime(in Stack<int> stack) => null;

        public static Queue<int> QueueFromStack(Stack<int> stack) => null;
    }
}