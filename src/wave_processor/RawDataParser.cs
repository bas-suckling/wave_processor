using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Xml;

namespace wave_processor
{
    class RawDataParser
    {

        public void getData()
        {
            var filename = "rawData/2020-05-15_test.gpx";
            var currentDirectory = Directory.GetCurrentDirectory();
            var rawDataFilePath = Path.Combine(currentDirectory, filename);

            // XElement trackData = XElement.Load(rawDataFilePath);
            // Console.WriteLine(trackData.GetType());

            // IEnumerable<string> trackPoints = trackData.Descendants("time").Select(x => (string)x.Value);

            // Console.WriteLine(trackData.GetType());

            // if (trackPoints != null)
            // {
            //     Console.WriteLine("trackPoints:");
            //     foreach (string trackPoint in trackPoints)
            //     {
            //         Console.WriteLine(trackPoint);
            //     }
            // }
            // else
            // {
            //     Console.WriteLine("trackPoints is null");
            // }


            XmlReader xmlReader = XmlReader.Create(rawDataFilePath);
            while (xmlReader.Read())
            {
                if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "trkpt"))
                {
                    var lat = xmlReader.GetAttribute("lat");
                    var lng = xmlReader.GetAttribute("lon");
                    var time = xmlReader.GetAttribute("time");

                    if (xmlReader.HasAttributes)
                        Console.WriteLine("lat: " + lat + " lng: " + lng);
                }
            }

        }
    }



}

