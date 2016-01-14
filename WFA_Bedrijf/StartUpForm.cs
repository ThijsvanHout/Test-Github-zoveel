using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CL_Bedrijf;
//using B = CL_Bedrijf;//alias voor de namespace indien conflict aanwezig: clashing names
using CL_Bedrijf.Interfaces;

namespace WFA_Bedrijf
{
    public partial class StartUpForm : Form
    {
        public StartUpForm()
        {
            InitializeComponent();
        }

        private void btnHallo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hallo Almere!");
        }

        private void btnNieuwePersoon_Click(object sender, EventArgs e)
        {
            Werknemer nieuwePersoon;//ruimte voor type persoon in geheugen vrijgemaakt/ gereserveerd 
            nieuwePersoon = new Werknemer();//persoon laden en aanmaken in geheugen, object is nu niet meer null en is dus te gebruiken
            nieuwePersoon.Geboortedatum = new DateTime(1970, 12, 31);//geboortedatum instellen: schrijven via setter van property procedure
            MessageBox.Show(nieuwePersoon.Geboortedatum.ToLongDateString());//geboortedatum weergeven, lezen via getter van property procedure
            nieuwePersoon.GeefNaam("Jan", "Jansen", "van der");//overloaded functie aanspreken, een functie kan met een code regel meerdere properties wijzigen

            //nieuwePersoon.dispose();
            nieuwePersoon = null;
        }

        private void btnNieuwePersoon2_Click(object sender, EventArgs e)
        {
            Klant nieuwePersoon;
            //auto initializers:
            nieuwePersoon = new Klant() {
                Voornaam="Jan",
                Achternaam="Jansen"
            };
        }

        private void btnNieuwePersoonOpslaan_Click(object sender, EventArgs e)
        {
            Werknemer opslaanPersoon = new Werknemer(){Voornaam="Jan", Achternaam = string.Empty};
            //Events stap 4: Handler koppelen aan event, source aan sink koppeling 
            opslaanPersoon.AchternaamIsLeeg_Event += opslaanPersoon_AchternaamIsLeeg_Event;
            opslaanPersoon.Opslaan();
        }

        void opslaanPersoon_AchternaamIsLeeg_Event()
        {
           //Events stap 5: bepalen wat er op dat moment moet gebeuren
            MessageBox.Show(
                "Persoon kon niet opgeslagen worden, achternaam ontbreekt, geef een achternaam op.",
                "Achternaam is leeg", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Information);
        }

        private void btnNieuweWerknemer_Click(object sender, EventArgs e)
        {
            Werknemer wkn = new Werknemer();
            wkn.GeefNaam("Jan","Jansen");
        }

        private void btnStrings_Click(object sender, EventArgs e)
        {
            //slecht gebruik van string:
            var slechtestring = "De " + "appel " + "valt " + "niet ver van de boom!";

            //goed gebruik van string:
            StringBuilder sb = new StringBuilder();
            sb.Append("De ");
            sb.Append("appel ");
            sb.Append("valt ");
            sb.Append("niet ver van de boom!");

            MessageBox.Show(sb.ToString());

            var veld = "achternaam";
            var bericht = string.Format("Het veld {0} is niet ingevuld, geef een waarde op voor {0}.", veld);

            MessageBox.Show(bericht);

            var code1 = "aapje";
            var code2 = "konijntje";
            var code3 = "muisje";
            var gecodeerd = string.Format("{2}-{1}-{2}-{0}", code1, code2, code3);//muisje-konijntje-muisje-aapje

        }

        private void btnVolledigenaamKlant_Click(object sender, EventArgs e)
        {
            var nieuweKlant = new Klant();
            nieuweKlant.Achternaam = "Klaassen";
            MessageBox.Show("Volledigenaam (met a): " + nieuweKlant.Volledigenaam());
            nieuweKlant.Tussenvoegsels = "van der";
            MessageBox.Show("Volledigenaam (met a & tv): " + nieuweKlant.Volledigenaam());
            nieuweKlant.Voornaam = "Klaas";
            MessageBox.Show("Volledigenaam (met v & tv & a): " + nieuweKlant.Volledigenaam());

            MessageBox.Show("ToString: " + nieuweKlant.ToString());
        }

        private void btnCasts_Click(object sender, EventArgs e)
        {
            Int16 int16=0;
            Int64 int64=0;
            try
            {
                int16 = 123;
                int64 = int16;//klein past altijd in groot dus: conversie impliciet
                int16 = (Int16)int64;//explicit cast
                
                //Simulate silent Overflow:
                int64 = Int64.MaxValue;
                int16 = (Int16)int64;//geen overflow exception: waarde komt op -1 te staan!
                //Simulate Overflow:
                //int16 = Int16.Parse(int64.ToString());

                if (Int16.TryParse(int64.ToString(), out int16))
                {
                    MessageBox.Show("Coversie gelukt!");
                }
                else
                { 
                    MessageBox.Show("Coversie mislukt!");                    
                }

                //Explicit convert function
                int16 = Convert.ToInt16(int64);

            }
            catch (Exception ex)
            {
                //catch will be executed if exception occurres
                MessageBox.Show("ErrorMessage: " + ex.Message);
            }
            finally 
            {
                //finally is always executed
                MessageBox.Show(int16.ToString());
            }


        }

        private void btnTryCatchExceptions_Click(object sender, EventArgs e)
        {
            Int16 int16 = 0;
            Int16 int17 = 0;
            int result = 0;
            try
            {
                result = int17 / int16;
            }
            catch (DivideByZeroException dbzEx)
            {
                MessageBox.Show("Delen door nul kan vandaag even niet probeer het morgen nogmaals!");
            }
            catch (ArithmeticException ae)
            {
                MessageBox.Show("Er heeft zich een wiskundige fout voorgedaan!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Er heeft zich een uitzondering voorgedaan!");
            }
        }

        private void btnNullable_Click(object sender, EventArgs e)
        {
            int? nullableInt = null;
            int nietNullable = 0;

            nietNullable = nullableInt.GetValueOrDefault(123);
            MessageBox.Show(nietNullable.ToString());

            if (nullableInt.HasValue)
            {
                nietNullable = nullableInt.Value;
            }
            MessageBox.Show(nietNullable.ToString());
        }

        private void btnImmediateStatements_Click(object sender, EventArgs e)
        {
            int waarde1 = 1;
            int waarde2 = 2;
            int result = waarde2 >= waarde1 ? waarde2 : waarde1;

            Werknemer w1 = null;
            Werknemer w2 = null;
            w2 = w1 ?? new Werknemer() {Voornaam = "Jan", Achternaam="Jansen" };
        }

        private void btnWerknemerEnManager_Click(object sender, EventArgs e)
        {
            //Zelfs met een expliciete cast mag dit niet:
            //Werknemer w1 = new Werknemer() {Voornaam="Willem", Achternaam="Willemse" };
            //Manager m1 = (Manager)w1;

            Manager m2 = new Manager() { Voornaam="Manfred", Achternaam="Manfredsen"};
            Werknemer w2 = m2;//dit is het kopieeren/ gelijk instellen van de pointer, 
            //      beide variabelen wijzen naar hetzelfde geheugengebied lees: zelfde object!
            w2.Voornaam = "Jan";
            //MessageBox.Show(m2.Voornaam);//output: Jan
            ToonVolledigenaam(m2);
            ToonVolledigenaam(w2);

        }

        private void ToonVolledigenaam(Persoon p)
        {
            MessageBox.Show("p " + p.Volledigenaam());
        }

        private void ToonVolledigenaam(IVolledigenaam iv) {
            MessageBox.Show("iv " + iv.Volledigenaam());
        }


        private void btnGenerics_Click(object sender, EventArgs e)
        {
            List<Werknemer> werknemers = new List<Werknemer>();
            werknemers.Add(new Werknemer() { Voornaam="Jan", Achternaam="Jansen"});
            werknemers.Add(new Werknemer() { Voornaam="Jaap", Achternaam="Jaapsen"});
            werknemers.Add(new Werknemer() { Voornaam="Miep", Achternaam="Miepersen"});

            var jan = werknemers.FirstOrDefault(w => w.Voornaam == "Jan");//lambda expressie, w is werknemer, of type van item in collectie: zoek op voornaam
            MessageBox.Show("Jan gevonden: " + jan.Volledigenaam());

            List<Manager> managers = new List<Manager>();
            managers.Add(new Manager() { Voornaam="Jan", Achternaam="Jansen"});
            //Voeg managers toe:
            List<Manager> managers2= new List<Manager>();
            managers2.AddRange( managers.Skip(1).Take(1).Skip(1).Take(1));
            //hoe kun je testen of er een manager met de voornaam jan in zit? Geef een voorbeeld van het gebruik van de Any() functie
            
            //geef voorbeeld van SelectMany, ?
            //wat kun je met skip en take?
            //kun je een voorbeeld geven waarbij alle personen met de voornaam jan teruggegeven worden
        }

        private void btnCollections_Click(object sender, EventArgs e)
        {
            SampleCollections sc = new SampleCollections();//Zie code file Collections.cs
            //Debug of ga stap voor stap door de code om te volgen en open het Output window waar de resultaten naar toe worden geschreven met Debug.WriteLine();
            //Voer eventueel iedere keer maar één van UseOf functies uit om goed te zien welke output deze geeft
            sc.UseOfList();
            sc.UseOfSortedList();
            sc.UseOfDictionary();
            sc.UseOfStack();
            sc.UseOfQueue();
        }


    }
}
