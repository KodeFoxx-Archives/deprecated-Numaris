using Kf.Numaris.Api.Specifications.Field;
using Kf.Numaris.Api.Specifications.Numbers;

namespace Kf.Numaris.Implementations.InszNumber.Specification
{
    /*
     * Het Rijksregisternummer of INSZ (Identifucatie nummer Sociale Zekerheid) is een uniek identificatienummer toegekend 
     * aan natuurlijke personen ingeschreven in België. Iedere burger met ofwel een Belgisch identiteitsdocument 
     * ofwel een Belgisch verblijfsdocument heeft zo'n nummer. Rechtspersonen hebben als uniek identificatienummer een ondernemingsnummer, 
     * geregistreerd bij de Kruispuntbank van Ondernemingen. Het rijksregisternummer wordt officieel het 
     * identificatienummer bij het Rijksregister van de natuurlijke personen genoemd, 
     * of ook nog: het nationale nummer. 
     * Het rijksregisternummer is eveneens het unieke nummer voor de sociale zekerheid (het INSZ-nummer).
     * 
     * Voorbeeld: 
     * - Is een man geboren op 18 mei 1993, 
     *   dan is een mogelijk nummer 93051822361. 
     *   Immers, 930518223 gedeeld door 97 is 9592971+36.
     *   Het verschil van 97 en de rest levert 97 - 36 = 61 op.
     * 
     * Referenties: 
     * - https://nl.wikipedia.org/wiki/Rijksregisternummer
     */
    public sealed class InszNumberSpecification : NumberSpecification
    {
    }

    /*
     * Een eerste groep van zes cijfers, gevormd door de geboortedatum in de volgorde: jaar, maand, dag. 
     * Maand en/of dag kunnen nul zijn indien de exacte geboortedatum niet bekend is. 
     * Indien de persoon niet ingeschreven is in het Rijksregister, maar er toch gegevens moeten worden bijgehouden voor 
     * de sociale zekerheid, bijvoorbeeld buitenlandse werknemers die minder dan drie maanden in België verblijven 
     * of grensarbeiders, dan wordt een bisnummer toegekend. 
     * Bij het bisnummer wordt de geboortemaand verhoogd met 20 of 40. Als bij de aanvraag het geslacht bekend is, 
     * wordt de geboortemaand verhoogd met 40, anders wordt ze verhoogd met 20. 
     * Indien de persoon vluchteling is en de geboortedatum niet gekend is, wordt de geboortemaand op 00 gezet en de 
     * geboortedag op 00 gezet.
    */
    public sealed class DateOfBirthYearFieldSpecification : FieldSpecification<InszNumberSpecification>
    {
        public override int Order => 11;
    }
    public sealed class DateOfBirthMonthFieldSpecification : FieldSpecification<InszNumberSpecification>
    {
        public override int Order => 12;
    }
    public sealed class DateOfBirthDayFieldSpecification : FieldSpecification<InszNumberSpecification>
    {
        public override int Order => 13;
    }

    /*
     * Een tweede groep van drie cijfers dient als herkenning van de personen die op dezelfde dag geboren zijn. 
     * Dit reeksnummer is even voor een vrouw en oneven voor een man. 
     * Het is de dagteller van de geboortes. Voor een man van 001 tot 997 en voor een vrouw van 002 tot 998.
     */
    public sealed class DayCounterFieldSpecification : FieldSpecification<InszNumberSpecification>
    {
        public override int Order => 20;
    }

    /*
     * Een derde groep van twee cijfers is een controlegetal op basis van de 9 voorafgaande cijfers. 
     * Dat wordt berekend door het getal van negen cijfers, dat gevormd wordt door de aaneenschakeling 
     * van de geboortedatum en het reeksnummer, te delen door 97. De rest van deze deling ("modulo") 
     * wordt van 97 afgetrokken. Het aldus verkregen verschil is het controlenummer. 
     * Voor personen geboren in of na 2000 moet men een 2 voor het getal van negen cijfers zetten 
     * (+ 2000000000) alvorens te delen door 97.
     */
    public sealed class CheckDigitsFieldSpecification : FieldSpecification<InszNumberSpecification>
    {
        public override int Order => 30;
    }
}
