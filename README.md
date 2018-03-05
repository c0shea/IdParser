# ID Parser

![Build Status](https://coshea.visualstudio.com/_apis/public/build/definitions/51c35e17-5e8a-4b8a-8c23-dabefcc52c57/5/badge)

ID Parser can be used to parse AAMVA-compliant driver's licenses and ID cards into objects that you can
work with. More information on the versions of the AAMVA standard can be found [here](http://www.aamva.org/DL-ID-Card-Design-Standard/).
More information on the D20 Data Dictionary can be found [here](https://www.aamva.org/D20/).

## Usage

1. Include the using
```cs
using IdParser;
```

2. Then you're off to the races!

```cs
var idCard = Barcode.Parse(barcode);
Console.WriteLine(idCard.Address.StreetLine1); // "123 NORTH STATE ST."
Console.WriteLine(idCard.IssuerIdentificationNumber.GetDescription()); // "New York"

if (idCard is DriversLicense license)
{
    Console.WriteLine(license.Jurisdiction.VehicleClass); // "C"
}
```

### More Examples

Take a look at the unit test project for more examples and usage.

## Client

The ```IdParser.Client``` project is a handy GUI application to help test and verify that an ID
will be parsed correctly. The app works with both OPOS and HID keyboard emulation scanners.

![](https://raw.githubusercontent.com/c0shea/IdParser/master/IdParser.Client.png)

## FAQ

* **I can't build ```IdParser.Client```. It's missing a required dependency.**
  You need to have [Microsoft POS for .NET](https://www.microsoft.com/en-us/download/details.aspx?id=55758&WT.mc_id=rss_alldownloads_all)
  installed. The ```Microsoft.PointOfService``` dll is GAC'd and will allow you to build and run
  the client app.

* **The ```Height``` class has the wrong ```TotalInches``` or ```Centimeters```.**
  The AAMVA standard has no decimal places in the height subfile record.
  As a result, the conversion between inches and centimeters will be off.

* **The library is throwing `ArgumentExcpetions` for every barcode I'm passing in.**
  By default, all barcodes are parsed using the `Strict` validation level. All barcodes are expected to
  adhere exactly to the AAMVA standard as defined in the PDFs for parsing to succeed. This is the
  recommended level for scanners using OPOS. However, if HID keyboard emulation is used, especially when
  scanning using a web browser, the expected data can become malformed. You can try using the `None`
  validation level, however this is not guaranteed to work in all cases. Data elements may be skipped
  and exceptions may still be thrown.