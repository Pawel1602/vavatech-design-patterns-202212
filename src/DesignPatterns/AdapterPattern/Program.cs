using CrystalDecisions.CrystalReports;
using NGeoHash;
using System;

namespace AdapterPattern
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Adapter Pattern!");

            MotorolaRadioTest();

            HyteriaRadioTest();

            CrystalReportTest();

        }


        // http://geohash.co/
        private static void ConvertGeoHashToLocationTest()
        {
            string geohash = "u3ky1z5793cb";

            var coordinates = GeoHash.Decode(geohash).Coordinates;

            var location = new Location { Latitude = coordinates.Lat, Longitude = coordinates.Lon };
        }

        private static void ConvertLocationToGeohashTest()
        {
            var location = new Location { Latitude = 52.22967605, Longitude = 21.01222912 };

            string geohash = GeoHash.Encode(location.Latitude, location.Longitude);
        }

        
        // dotnet add package NGeoHash
     


        private static void CrystalReportTest()
        {
            ReportDocument rpt = new ReportDocument();
            rpt.Load("report1.rpt");

            ConnectionInfo connectInfo = new ConnectionInfo()
            {
                ServerName = "MyServer",
                DatabaseName = "MyDb",
                UserID = "myuser",
                Password = "mypassword"
            };

            foreach (Table table in rpt.Database.Tables)
            {
                table.LogOnInfo.ConnectionInfo = connectInfo;
                table.ApplyLogOnInfo(table.LogOnInfo);
            }

            rpt.ExportToDisk(ReportDocument.ExportFormatType.PortableDocFormat, "report1.pdf");
        }

        private static void MotorolaRadioTest()
        {
            MotorolaRadio radio = new MotorolaRadio();
            radio.PowerOn("1234");
            radio.SelectChannel(10);
            radio.Send("Hello World!");
            radio.PowerOff();
        }

        private static void HyteriaRadioTest()
        {
            HyteraRadio radio = new HyteraRadio();
            radio.Init();
            radio.SendMessage(10, "Hello World!");
            radio.Release();
        }
    }

    


}
