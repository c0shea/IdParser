# ID Parser

![](https://coshea.visualstudio.com/_apis/public/build/definitions/51c35e17-5e8a-4b8a-8c23-dabefcc52c57/1/badge)

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

### More Examples

Take a look at the unit test project for more examples and usage.

## Client

The ```IdParser.Client``` project is a handy GUI application to help test and verify that an ID will be parsed correctly. The app works with both OPOS and HID keyboard emulation scanners.

![](https://raw.githubusercontent.com/c0shea/IdParser/master/IdParser.Client.png)

## FAQ

* **I can't build ```IdParser.Client```. It's missing a required dependency.** You need to have [Microsoft POS for .NET](https://www.microsoft.com/en-us/download/details.aspx?id=5355) installed. The ```Microsoft.PointOfService``` dll is GAC'd and will allow you to build and run the client app. If you have POS for .NET version 1.12 installed, only the .NET 2.0 and 3.5 versions of the client will work with OPOS. You can still use the HID keyboard emulation in any .NET version of the client.

* **The ```Height``` class has the wrong ```TotalInches``` or ```Centimeters```.** The AAMVA standard has no decimal places in the height subfile record. As a result, the conversion between inches and centimeters will be off.