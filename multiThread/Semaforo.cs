using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace multiThread
{
    public static class Semaforo
    {
        private static List<SimpleClass> Lista = new List<SimpleClass>();

        public static void addItem(SimpleClass simples) 
        {
            Lista.Add(simples);
        }

        public static SimpleClass removeItem(SimpleClass simples)
        {
            SimpleClass tmp = Lista[0];
            Lista.Remove(tmp);
            return tmp;
        }

        public static int Count()
        {
            return Lista.Count;
        }
    }
    
}
