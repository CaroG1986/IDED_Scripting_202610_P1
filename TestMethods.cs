namespace IDED_Scripting_202610_P1
{
    internal class TestMethods
    {
        public static void SeparateElements(Queue<int> input, out Stack<int> included, out Stack<int> excluded)
        {
            //Aqui se inician las dos pilas
            included = new Stack<int>();
            excluded = new Stack<int>();

            Stack<int> auxIncluded = new Stack<int>();
            Stack<int> auxExcluded = new Stack<int>();

            // se dividen dependiendo de que pila pertenece
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

            //Meter lo que va saliendo de la fila auxiliar
            while (auxIncluded.Count > 0)
            {
                included.Push(auxIncluded.Pop());
            }

            while (auxExcluded.Count > 0)
            {
                excluded.Push(auxExcluded.Pop());
            }

        }

        //Una función  para revisar si pertenece a la secuencia
        private static bool BelongsToSequence(int number)
        {
            if (number == 0)
                return false;

            // como hay varios numeros negativos los pasa a positivos para revisar mejor su raiz cuadrada 
            int value = number;
            if (value < 0)
                value = -value;

            // debe verificar que tengan raiz cuadrada exacta 
            int root = (int)Math.Sqrt(value);

            if (root * root != value)
                return false;

            // si el numero es positivo debe ser par
            if (number > 0 && root % 2 == 0)
                return true;

            // si es negativo debe ser impar

            if (number < 0 && root % 2 == 1)
                return true;

            return false;
        }


        public static List<int> GenerateSortedSeries(int n)
        {
            // se crea la lista
            List<int> lista = new List<int>();

            for (int i = 1; i <= n; i++)
            {
                int termino = i * i;   // n^2

                // Si i es impar, el signo es negativo
                if (i % 2 == 1)
                {
                    termino = -termino;
                }

                lista.Add(termino);
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
            // Crear copia manual para no modificar la original
            List<int> sortedList = new List<int>();

            for (int i = 0; i < list.Count; i++)
            {
                sortedList.Add(list[i]);
            }

            // Ordenamiento descendente (Bubble Sort manual)
            for (int i = 0; i < sortedList.Count - 1; i++)
            {
                for (int j = 0; j < sortedList.Count - 1 - i; j++)
                {
                    if (sortedList[j] < sortedList[j + 1])
                    {
                        int temp = sortedList[j];
                        sortedList[j] = sortedList[j + 1];
                        sortedList[j + 1] = temp;
                    }
                }
            }

            // Búsqueda binaria en lista descendente
            int left = 0;
            int right = sortedList.Count - 1;

            while (left <= right)
            {
                int middle = (left + right) / 2;

                if (sortedList[middle] == target)
                    return true;

                // OJO: lógica para orden descendente
                if (target < sortedList[middle])
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