using System;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;

namespace wave_processor
{
    class RawDataProcessor
    {

        public void getData()
        {
            var filename = "rawData/2020-05-15_test.gpx";
            var currentDirectory = Directory.GetCurrentDirectory();
            var rawDataFilePath = Path.Combine(currentDirectory, filename);

            // XmlReader xmlReader = XmlReader.Create(rawDataFilePath);
            // while (xmlReader.Read())
            // {
            //     if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "trkpt"))
            //     {
            //         var lat = xmlReader.GetAttribute("lat");
            //         var lng = xmlReader.GetAttribute("lon");

            //         if (xmlReader.HasAttributes)
            //             Console.WriteLine("lat: " + lat + " lng: " + lng);
            //     }
            // }

            XElement trackData = XElement.Load(rawDataFilePath);
            // Console.WriteLine(trackData.ToString());
            // Console.WriteLine(trackData);

            IEnumerable<string> time = trackData.Descendants("metadata").Select(x => (string) x.Attribute("time"));
            Console.WriteLine(time.ToString());



        }

    }



}

