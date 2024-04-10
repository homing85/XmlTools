using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using imx122;
using pgt;
using System.Xml.Schema;
using System.IO;

namespace XmlConsoleAppDotNetFramework
{
    internal class Program
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

            XmlSerializer serializer2 = new XmlSerializer(typeof(pgt.FeatureCollectionType));
            pgt.FeatureCollectionType deserializeRequest2 = (pgt.FeatureCollectionType)serializer2.Deserialize(new XmlTextReader(exampleXmlPath2));

            
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

            ////create xsd using xml
            //XmlReader reader2 = XmlReader.Create(@"C:\Repository\XmlTools\Voorbeelden\IMGeo_Naiade_Export_17_08_2022T12_42_33.xml");
            //XmlSchemaSet schemaset = new XmlSchemaSet();
            //XmlSchemaInference schema = new XmlSchemaInference();

            //schemaset = schema.InferSchema(reader2);
            //XmlWriter writer;
            //int count = 0;
            //foreach (XmlSchema s in schemaset.Schemas())
            //{
            //    writer = XmlWriter.Create((count++).ToString() + "_pgt.xsd");
            //    s.Write(writer);
            //    writer.Close();
            //    Console.WriteLine("done " + count);
            //}
            //reader2.Close();

            // using a modified cpt_in_out, the modified parts comes from a class auto-generated from xsd's that are auto-generated from a fugro generated cpt xml.
            selfpgt.FeatureCollection selfpgt = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(selfpgt.FeatureCollection));
                using (XmlTextReader reader = new XmlTextReader(exampleXmlPath2))
                {
                    selfpgt = (selfpgt.FeatureCollection)serializer.Deserialize(reader);
                }

            }
            catch (Exception exception)
            {
                //Do nothing
            }
            WriteToXml(selfpgt, @"C:\Repository\XmlTools\Voorbeelden\IMGeo_Naiade_Export_17_08_2022T12_42_33_test2.xml");


        }

        private static void WriteToXml<T>(T registrationRequest, string v)
        {
            using (Stream stream = File.Open(v, FileMode.Create))
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("gml", "http://www.opengis.net/gml");
                ns.Add("imgeo-pgt", "http://www.prorail.nl/imgeo-pgt/2.1");
                //ns.Add("ns4", "http://www.broservices.nl/xsd/cptcommon/1.1");
                //ns.Add("ns5", "http://www.w3.org/1999/xlink");
                //ns.Add("ns6", "http://www.opengis.net/sampling/2.0");
                //ns.Add("ns7", "http://www.opengis.net/om/2.0");
                //ns.Add("ns8", "http://www.opengis.net/swe/2.0");
                //ns.Add("ns3", "http://www.opengis.net/gml/3.2");
                //ns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(stream, registrationRequest, ns);
                stream.Flush();
            }
        }
    }
}
