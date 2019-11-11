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

namespace WeatherApp
{
    public partial class Form1 : Form
    {

        public string location;
        public string currentLocation;
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
            location = "dsada"; //String.Format("loc: {0}", e.Position.Location);
            currentLocation = String.Format("loc: {0}", e.Position.Location);
            label1.Text = location;
            button1.Text = "Текущая локация";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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
            location = currentLocation;
            label1.Text = location;
            
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
