using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL_Bedrijf.Interfaces;

namespace CL_Bedrijf
{
    //Events: stap 1, functiedefinitie van event maken in vorm van een delegate
    public delegate void AchternaamIsLeeg_Delegate();

    public abstract class Persoon: IVolledigenaam
    {
        #region ContructorsDestructors

        public Persoon()//default constructor: zonder parameters
        {
            //initialisatie van velden, standaard waardes(een persoon heeft er in dit voorbeeld even geen...)
        }
        public Persoon(string voornaam, string achternaam):this(voornaam, achternaam, string.Empty)//Constructor chaining
        {
            //this.GeefNaam(voornaam, achternaam);
        }
        public Persoon(string voornaam, string achternaam, string tussenvoegsels)
        {
            this.GeefNaam(voornaam, achternaam, tussenvoegsels);
        }
        ~Persoon(){
            //destructors:
            //deze worden niet gebruikt, als je in .Net explicit cleanup wilt dan dien je gebruik te maken van de IDisposable interface 
        }

        #endregion

        #region Properties

        //auto implemented properties:
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Tussenvoegsels { get; set; }

        //manual implemented property:
        private DateTime geboortedatum;//private field, the actual container for dateofbirth
        public DateTime Geboortedatum
        {
            get { return geboortedatum; }
            set { geboortedatum = value; }
        }

        #endregion
        
        #region Procedures

        public void GeefNaam(string voornaam, string achternaam)
        {
            this.Voornaam = voornaam;
            this.Achternaam = achternaam;
        }

        public void GeefNaam(string voornaam, string achternaam, string tussenvoegsels)
        {
            GeefNaam(voornaam, achternaam);
            this.Tussenvoegsels = tussenvoegsels;
        }

        public void Opslaan() { 
            //Events stap 3: Bepalen wanneer het event getriggerd moet worden
            if(this.Achternaam == string.Empty)
            {
                if (AchternaamIsLeeg_Event != null)//Controle op null is verplicht: is er een handler gekoppeld aan dit event?
                {
                    AchternaamIsLeeg_Event();
                }
                else
                {
                    throw new NotImplementedException("Bij opslaan dient event AchternaamIsLeeg_Event geïmplementeerd te zijn.");
                }

            }    
        }

        #endregion

        #region Events

        //Events stap 2: Event van type delegate als member aanmaken
        public event AchternaamIsLeeg_Delegate AchternaamIsLeeg_Event;

        #endregion

        #region InterfaceImplementatie

        public virtual string Volledigenaam()
        {
            return string.Format("{0}{1}{2}",
                (this.Voornaam + " ").TrimStart(),
                (this.Tussenvoegsels + " ").TrimStart(),
                this.Achternaam);

            //return (this.Voornaam + " ").TrimStart() + (this.Tussenvoegsels + " ").TrimStart() + this.Achternaam;
        } 

        #endregion

        #region Overrides

        public override string ToString()
        {
            return this.Volledigenaam();
        }

        #endregion
    }

    public class Werknemer: Persoon {
        
        public string Functie { get; set; }//Maak hier een keuzelijst: enum van!
        public string Personeelsnummer { get; set; }
        public decimal Salaris { get; set; }
        public bool InBezitVanRijbewijs { get; set; }
    }

    public class Klant : Persoon {
        public string Klantnummer { get; set; }
        public string BtwNummer { get; set; }

        public override string Volledigenaam()
        {
            if (string.IsNullOrWhiteSpace(this.Voornaam) & string.IsNullOrWhiteSpace(this.Tussenvoegsels))
            {
                return string.Format("{0}", this.Achternaam);
            }
            else 
            {
                return string.Format("{0}, {1}{2}", 
                    this.Achternaam, 
                    (this.Voornaam + " ").TrimStart(), 
                    this.Tussenvoegsels);                
            }
            
        }
    }

    public sealed class Manager : Werknemer {
        public bool AutoVanDeZaak { get; set; }
        public string Afdeling { get; set; }
        public decimal Bonus { get; set; }

        public override string Volledigenaam()
        {
            if (string.IsNullOrWhiteSpace(this.Voornaam) & string.IsNullOrWhiteSpace(this.Tussenvoegsels))
            {
                return string.Format("Manager: {0}", this.Achternaam);
            }
            else 
            {
                return string.Format("Manager: {0}, {1}{2}", 
                    this.Achternaam, 
                    (this.Voornaam + " ").TrimStart(), 
                    this.Tussenvoegsels);                
            }
            
        }
    }

    //public class SpecializedManager:Manager { }//mag niet overerven van Manager: Sealed
}


