using System;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System.IO;
using System.Xml.Linq;

namespace wave_processor
{
    class RawDataProcessor
    {

        public void getData()
        {
            var filename = "rawData/2020-05-15.gpx";
            var currentDirectory = Directory.GetCurrentDirectory();
            var rawDataFilePath = Path.Combine(currentDirectory, filename);

            XmlReader xmlReader = XmlReader.Create(rawDataFilePath);
            while (xmlReader.Read())
            {
                if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "trkpt"))
                {
                    if (xmlReader.HasAttributes)
                        Console.WriteLine(xmlReader.GetAttribute("lat") + ": " + xmlReader.GetAttribute("lon"));
                }
            }
        }

    }



}

