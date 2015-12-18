using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using AbakonDataModel.LangKeys;

namespace AbakonDataModel 
{
    /*
    W przypadku inwestycji proponuję wstępnie uwzględnić następujące atrybuty:
1.Nazwisko Zamawiającego (w przypadku firmy, nazwisko osoby reprezentującej firmę)
2.Imię Zamawiającego (w przypadku firmy, imię osoby reprezentującej firmę)
3.Numer umowy (docelowej)
4.Lokalizacja inwestycji 
5.GPS inwestycji
6.Projekt (nazwa projektu)
7.Numer tel. kom. Zamawiającego
8.Ades e-mail Zamawiającego
9.Wartość umowy netto
Dodatkowo możliwość dodawania kolejnych atrybutów (dowolnej ilości) związanych z aneksami zwiększającymi lub zmniejszających
10.Wartość umowy z aneksami netto (sumująca atrybuty j.w.)
11.Szereg atrybutów, związanych z osobami prowadzącymi (Przedstawiciel Handlowy pozyskujący, Doradca Klienta prowadzący obsługę ofertowo-kosztorysową, Inżynier projektu, Inżynier budowy itd.)

Nietypowe jest może zastosowania nazwy „Zamawiający” zamiast „Inwestor” lub „Klient” ale chcę zachować spójność z nazewnictwem w umowach.
Chyba tyle. Jeżeli będzie Pan miał jeszcze jakieś propozycje lub pomysły, jesteśmy oczywiście otwarci.
*/
    [Table("Kontrakt")]
   public  class Contract
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContractId { get; set; }
        [MaxLength(60, ErrorMessageResourceType = typeof(ResourceLang), ErrorMessageResourceName = "_errMaxLegth60")]
        public string ContractSignature { get; set; }
        [MaxLength(60, ErrorMessageResourceType = typeof(ResourceLang), ErrorMessageResourceName = "_errMaxLegth60")]
        public string ProjectName { get; set; }

        [MaxLength(256, ErrorMessageResourceType = typeof(ResourceLang), ErrorMessageResourceName = "_errMaxLegth256")]
        public string Location { get; set; }
        [MaxLength(60, ErrorMessageResourceType = typeof(ResourceLang), ErrorMessageResourceName = "_errMaxLegth60")]
        public string GPSLocation { get; set; }
    }
}
