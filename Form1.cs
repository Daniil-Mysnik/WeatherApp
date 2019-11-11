using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Device.Location;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace WeatherApp
{
    public partial class Form1 : Form
    {
        public string lon;
        public string lat;
        public string currentLon;
        public string currentLat;
        public string city;

        public Form1()
        {
            InitializeComponent();
        }

        static String GetLocationProperty()
        {
            GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();
            watcher.Start();

            GeoCoordinate coord = watcher.Position.Location;
            return String.Format("Lat: {0}, Long: {1}",
                coord.Latitude,
                coord.Longitude);
        }

        private void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            lat = String.Format("loc: {0}", e.Position.Location.Latitude);
            lon = String.Format("loc: {0}", e.Position.Location.Longitude);
            currentLat = String.Format("loc: {0}", e.Position.Location.Latitude);
            currentLon = String.Format("loc: {0}", e.Position.Location.Longitude);
            label1.Text = lat + lon;
            button1.Text = "Текущая локация";
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            WebRequest request = WebRequest.Create("https://http://api.openweathermap.org/data/2.5/weather?lat=" + lat + "&lon=" + lon + "APPID=1499f87b39982a746c16f0c3ff09b18b&lang=ru");
            request.Method = "POST";
            request.ContentType = "application/x-www-urlencoded";
            WebResponse response = await request.GetResponseAsync();
            string answer = string.Empty;
            using (Stream s = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(s))
                {
                    answer = await reader.ReadToEndAsync();
                }
            }
            response.Close();


            GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();
            watcher.PositionChanged += watcher_PositionChanged;
            watcher.Start();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            lon = currentLon;
            lat = currentLat;
            label1.Text = lon + lat;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = city;
            textBox1.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            city = textBox1.Text;
        }
    }
}
