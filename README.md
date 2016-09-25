# ID Parser

ID Parser can be used to parse AAMVA-compliant driver's licenses and ID cards into objects that you can work with.  [More information on the versions of the AAMVA standard.](http://www.aamva.org/DL-ID-Card-Design-Standard/)

## Usage

```cs
var idCard = IdParser.Parse(barcode);
Console.WriteLine(idCard.StreetLine1); // "123 NORTH STATE ST."
Console.WriteLine(idCard.IssuerIdentificationNumber.GetDescription()); // "New York"

if (idCard is DriversLicense) {
    var license = (DriversLicense)idCard;
    Console.WriteLine(license.Jurisdiction.VehicleClass); // "C"
}
```