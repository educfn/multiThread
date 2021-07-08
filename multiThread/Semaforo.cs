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
        private static bool usando_addItem = false;
        private static bool usando_removeItem = false;

        public static void addItem(SimpleClass simples) 
        {
            if (usando_addItem == false)
            {
                    usando_addItem = true;
                    Lista.Add(simples);
                    usando_addItem = false;            
            }
        }

        public static SimpleClass removeItem()
        {
            if (usando_removeItem == false)
            {
                if (Lista.Count() > 0)
                {
                    usando_removeItem = true;
                    SimpleClass tmp = Lista[0];
                    Lista.Remove(tmp);
                    usando_removeItem = false;
                    return tmp;
                }
                else return null; 
            }
            else return null;

        }

        public static int Count()
        {
            return Lista.Count;
        }

    }
    
}
