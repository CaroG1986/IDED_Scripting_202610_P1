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
        public static bool FindNumberInSortedList(int target, in List<int> list)
        {
            // Primero ordenamos manualmente descendente
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = 0; j < list.Count - 1 - i; j++)
                {
                    if (list[j] < list[j + 1])
                    {
                        int temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }
            }

            // Luego búsqueda binaria
            int left = 0;
            int right = list.Count - 1;

            while (left <= right)
            {
                int middle = (left + right) / 2;

                if (list[middle] == target)
                    return true;

                if (target < list[middle])
                    left = middle + 1;
                else
                    right = middle - 1;
            }

            return false;
        }


        public static int FindPrime(in Stack<int> list)
        {
            foreach (int value in list)
            {
                if (IsPrime(value))
                    return value;
            }

            return 0;
        }

        public static bool IsPrime(int n)
        {
            if (n <= 1)
                return false;

            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0)
                    return false;
            }

            return true;
        }

        public static Stack<int> RemoveFirstPrime(in Stack<int> stack)
        {
            Stack<int> auxiliar = new Stack<int>();
            Stack<int> resultado = new Stack<int>();
            bool eliminado = false;

            // Copiamos a auxiliar para invertir
            foreach (int valor in stack)
            {
                auxiliar.Push(valor);
            }

            // Reconstruimos sin el primer primo
            while (auxiliar.Count > 0)
            {
                int valor = auxiliar.Pop();

                if (!eliminado && IsPrime(valor))
                {
                    eliminado = true;
                    continue;
                }

                resultado.Push(valor);
            }

            return resultado;
        }

        public static Queue<int> QueueFromStack(Stack<int> stack)
        {
            Stack<int> auxiliar = new Stack<int>();
            Queue<int> cola = new Queue<int>();

            // Invertimos la pila
            foreach (int valor in stack)
            {
                auxiliar.Push(valor);
            }

            // Pasamos a la cola
            while (auxiliar.Count > 0)
            {
                cola.Enqueue(auxiliar.Pop());
            }

            return cola;
        }
    }
}