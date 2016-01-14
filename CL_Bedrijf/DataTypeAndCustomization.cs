using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_Bedrijf
{
    public enum Geslacht {
        Man=2, Vrouw=1, Onbekend=3
    }

    //KinderKlasse, normaal gesproken niet gebruiken, 
    //  initieel is een struct bedoeld als DataStructure: transport van data
    //  een struct is een value-type en niet zoals een classe(reference type)
    //  -> overerven is niet toegestaan
    //  -> geen default constructors

    public struct StructPersoon
    {
        public string Voornaam;
        public string Achternaam;
        public string Tussenvoegsels { get; set; }
        public Geslacht Geslacht { get; set; }

        public void GeefNaam(string voornaam, string achternaam) {
            this.Voornaam = voornaam;
            this.Achternaam = achternaam;
        }
    }

    public class SampleStruct
    {
        public void Test_StructPersoon() {
            StructPersoon piet = new StructPersoon();
            piet.Voornaam = "Piet";
            piet.Geslacht = Geslacht.Man;
        }
    }


    public class SampleEnum {

        public void TestEnum(Geslacht geslacht) 
        {
            switch (geslacht) {
                case Geslacht.Man:
                case Geslacht.Vrouw:
                    //deze wordt uitgevoerd bij man en vrouw
                    break;
                case Geslacht.Onbekend:
                    //deze wordt alleen uitgevoerd bij onbekend
                    break;
                default:
                    //deze wordt uitgevoerd bij eventuele andere/nieuwe enum waardes
                    break;
            }
        }
    }


    public class DataTypeAndCustomization
    {
        public void DataTypeDefinitionCharacter() 
        {
            int myInt = new int();
            myInt = 10;
            int myInt2 = 10;


            var myVar = 10;
            var myVar2 = 10D;
            var myVar3 = 1000.001F;
            var myVar4 = 1000.001M;
            var myVar5 = 12.5;

            string.Format("{0}{1}{2}{3}{4}{5}",myInt, myInt2, myVar, myVar2, myVar3, myVar4, myVar5);
        }


    }
}
