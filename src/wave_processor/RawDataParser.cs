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

        public void ParseXml()
        {
            var filename = "2020-05-15.gpx";
            var currentDirectory = "C:\\Users\\bas.suckling\\projects\\wave_processor\\src\\wave_processor\\rawData";
            var rawDataFilePath = Path.Combine(currentDirectory, filename);

            XDocument rawTrackData = XDocument.Load(rawDataFilePath);

            XNamespace ns = "http://www.topografix.com/GPX/1/1";
            XNamespace gpxtpx = "http://www.garmin.com/xmlschemas/TrackPointExtension/v1";

            var records = rawTrackData
                   .Descendants(ns + "trkpt")
                   .Select(r =>
                           new
                           {
                               Latitude = r.Attribute("lat").Value,
                               Longitude = r.Attribute("lon").Value,
                               Time = r.Element(ns + "time").Value,
                               Hr = r.Element(ns + "extensions")
                                   .Element(gpxtpx + "TrackPointExtension")
                                   .Element(gpxtpx + "hr").Value
                           }
                       );

            foreach (var record in records)
            {
                Console.WriteLine("TrackPoint");
                Console.WriteLine("Latitude: {0}", record.Latitude);
                Console.WriteLine("Longitude: {0}", record.Longitude);
                Console.WriteLine("Time: {0}", record.Time);
                Console.WriteLine("Hr: {0}", record.Hr);
                Console.WriteLine();
            }
        }
    }



}

