using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace CL_Bedrijf
{
    public class SampleCollections
    {
        public void UseOfList() {
            List<Werknemer> werknemers = new List<Werknemer>();
            Werknemer piet = new Werknemer() { Voornaam="Piet", Achternaam="Pietersen"};
            Werknemer jan = new Werknemer() { Voornaam="Jan", Achternaam="Jansen"};
            Werknemer peter = new Werknemer() { Voornaam="Peter", Achternaam="Petersen"};
            Werknemer marieke = new Werknemer() { Voornaam="Marieke", Achternaam="Mariekersen"};

            werknemers.Add(piet);
            werknemers.Add(jan);
            werknemers.Add(peter);
            werknemers.Add(marieke);

            foreach (Werknemer w in werknemers) {
                Debug.WriteLine(w.Volledigenaam());
            }

            werknemers.Remove(marieke);

            List<Werknemer> werknemersCopy = new List<Werknemer>();
            werknemersCopy.AddRange(werknemers.Where(w => w.Voornaam.StartsWith("P")));

            werknemers.Clear();
        }   
     
        public void UseOfSortedList() { 
            //SortedList is eigenlijk een sorted dictionary...
            SortedList<string, Werknemer> werknemers = new SortedList<string, Werknemer>();
            Werknemer piet = new Werknemer() { Voornaam="Piet", Achternaam="Pietersen"};
            Werknemer jan = new Werknemer() { Voornaam="Jan", Achternaam="Jansen"};
            Werknemer peter = new Werknemer() { Voornaam="Peter", Achternaam="Petersen"};
            Werknemer marieke = new Werknemer() { Voornaam="Marieke", Achternaam="Mariekersen"};

            werknemers.Add("PietKey", piet);
            werknemers.Add("JanKey", jan);
            werknemers.Add("PeterKey", peter);
            werknemers.Add("MariekeKey", marieke);

            werknemers.Remove("JanKey");

            foreach (string key in werknemers.Keys)
            {
                Debug.WriteLine(werknemers[key].Volledigenaam());
            }

        
        }

        public void UseOfDictionary() { 
            Dictionary<string, Werknemer> werknemers = new Dictionary<string, Werknemer>();
            Werknemer piet = new Werknemer() { Voornaam="Piet", Achternaam="Pietersen"};
            Werknemer jan = new Werknemer() { Voornaam="Jan", Achternaam="Jansen"};
            Werknemer peter = new Werknemer() { Voornaam="Peter", Achternaam="Petersen"};
            Werknemer marieke = new Werknemer() { Voornaam="Marieke", Achternaam="Mariekersen"};

            werknemers.Add("PietKey", piet);
            werknemers.Add("JanKey", jan);
            werknemers.Add("PeterKey", peter);
            werknemers.Add("MariekeKey", marieke);

            werknemers.Remove("JanKey");

            foreach (string key in werknemers.Keys)
            {
                Debug.WriteLine(werknemers[key].Volledigenaam());
            }
        }

        public void UseOfStack() { 
            Stack<Werknemer> werknemers = new Stack<Werknemer>();
            Werknemer piet = new Werknemer() { Voornaam="Piet", Achternaam="Pietersen"};
            Werknemer jan = new Werknemer() { Voornaam="Jan", Achternaam="Jansen"};
            Werknemer peter = new Werknemer() { Voornaam="Peter", Achternaam="Petersen"};
            Werknemer marieke = new Werknemer() { Voornaam="Marieke", Achternaam="Mariekersen"};

            werknemers.Push(piet);
            werknemers.Push(jan);
            werknemers.Push(peter);
            werknemers.Push(marieke);

            Debug.WriteLine("Pop "+werknemers.Pop().Volledigenaam());
            Debug.WriteLine("Pop "+werknemers.Pop().Volledigenaam());

            werknemers.Push(peter);
            werknemers.Push(marieke);

            Debug.WriteLine("Peek "+werknemers.Peek().Volledigenaam());
            Debug.WriteLine("Peek "+werknemers.Peek().Volledigenaam());
        }

        public void UseOfQueue() { 
            Queue<Werknemer> werknemers = new Queue<Werknemer>();
            Werknemer piet = new Werknemer() { Voornaam="Piet", Achternaam="Pietersen"};
            Werknemer jan = new Werknemer() { Voornaam="Jan", Achternaam="Jansen"};
            Werknemer peter = new Werknemer() { Voornaam="Peter", Achternaam="Petersen"};
            Werknemer marieke = new Werknemer() { Voornaam="Marieke", Achternaam="Mariekersen"};

            werknemers.Enqueue(piet);
            werknemers.Enqueue(jan);
            werknemers.Enqueue(peter);
            werknemers.Enqueue(marieke);

            Debug.WriteLine("Dequeue " + werknemers.Dequeue().Volledigenaam());
            Debug.WriteLine("Dequeue " + werknemers.Dequeue().Volledigenaam());

            werknemers.Enqueue(piet);
            werknemers.Enqueue(jan);

            Debug.WriteLine("Peek " + werknemers.Peek().Volledigenaam());
            Debug.WriteLine("Peek " + werknemers.Peek().Volledigenaam());
        }
    }

}
