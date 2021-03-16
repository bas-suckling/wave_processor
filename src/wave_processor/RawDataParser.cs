using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;
using Microsoft.Spatial;

namespace wave_processor

{
    class RawDataParser
    {

        public void ParseXml()
        {
            var filename = "2020-05-15_test.gpx";
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

            List<TrackPoint> AllPoints = new List<TrackPoint>();

            foreach (var record in records)
            {
                TrackPoint point = new TrackPoint();
                point.lat = Convert.ToDouble(record.Latitude);
                point.lng = Convert.ToDouble(record.Longitude);
                point.timeStamp = Convert.ToDateTime(record.Time);
                AllPoints.Add(point);

                Console.WriteLine("lat: {0}", point.lat);
                Console.WriteLine("lng: {0}", point.lng);
                Console.WriteLine("time: {0}", point.timeStamp);


            }




        }
        public string calculateDistance(TrackPoint p1, TrackPoint p2)
        {
            var distance = 

        }
    }



}

