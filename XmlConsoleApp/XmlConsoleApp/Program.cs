﻿
using System.Xml.Serialization;
using System.Xml;
using imx122;
using pgt;

namespace XmlConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
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
            string exampleXmlPath2 = @"C:\Repository\XmlTools\Voorbeelden\IMGeo_Naiade_Export_17_08_2022T12_42_33.xml";
            // .
            pgt.FeatureCollectionType pgt = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(pgt.FeatureCollectionType));
                using (XmlTextReader reader = new XmlTextReader(exampleXmlPath2))
                {
                    pgt = (pgt.FeatureCollectionType)serializer.Deserialize(reader);
                }

            }
            catch (Exception exception)
            {
                //Do nothing
            }

            Console.WriteLine("lets create some classes from xsd first");

        } 
    } 
}
