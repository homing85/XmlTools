// See https://aka.ms/new-console-template for more information
using System.Xml.Serialization;
using System.Xml;
using imx122;
Console.WriteLine("Hello, World!");


// Test creation imx122
string exampleXmlPath = @"C:\Repository\XmlTools\Voorbeelden\20220418_V28_F_Eindhoven_Venlo_D_OK0213.xml";
// .
imx122.IMSpoor im122 = null;
try
{
    XmlSerializer serializer = new XmlSerializer(typeof(imx122.IMSpoor));
    using (XmlTextReader reader = new XmlTextReader(exampleXmlPath))
    {
        im122 = (imx122.IMSpoor)serializer.Deserialize(reader);
    }

}
catch (Exception exception)
{
    //Do nothing
}

// Test creation imx122
string exampleXmlPath2 = @"C:\Repository\XmlTools\Voorbeelden\20220418_V28_F_Eindhoven_Venlo_D_OK0213.xml";
// .
imx122.IMSpoor pgt = null;
try
{
    XmlSerializer serializer = new XmlSerializer(typeof(imx122.IMSpoor));
    using (XmlTextReader reader = new XmlTextReader(exampleXmlPath2))
    {
        pgt = (imx122.IMSpoor)serializer.Deserialize(reader);
    }

}
catch (Exception exception)
{
    //Do nothing
}

Console.WriteLine("lets create some classes from xsd first");