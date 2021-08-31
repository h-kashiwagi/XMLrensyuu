using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace XMLrennsyuu
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void goButtan_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            XmlDocument myDoc = new XmlDocument();
            string fileName = Path.Combine(Application.StartupPath, "Cdlist.xml");
            myDoc.Load(fileName);

            XmlNodeList tracks = myDoc.GetElementsByTagName("Track");
            //Trackと同じ位置のノードも拾う
            foreach(XmlNode currentNode in tracks)
            {
                Track mytrack = new Track();
                
                //名前空間http:~CDListの要素
                //名前空間http:~にあるTitle要素
                mytrack.Title = currentNode["Title", "http://www.kkasahara.com/cd"].InnerText;
                mytrack.Artist = currentNode["Artist", "http://www.kkasahara.com/cd"].InnerText;
                mytrack.Music = currentNode["Music"].InnerText;
                mytrack.Lyrics = currentNode["Lyrics"].InnerText;
                mytrack.Arranged = currentNode["Arrenged"].InnerText;

                //属性を取得する
                mytrack.No = int.Parse(currentNode.Attributes["No"].Value);
                mytrack.Playtime = TimeSpan.Parse(currentNode["Playtime"].InnerText);
                listBox1.Items.Add(mytrack);

            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Track selected = (Track)listBox1.SelectedItem;
            albumLabel.Text = selected.AlubumName;
                                                
        }
    }



    public class Track
    {
        private string title, artist, music, lyrics, arrenged, albumname;
        private int no;
        private TimeSpan playtime;

        public string Title
        {
            get { return title; }
            set { this.title = value; }
        }

        public string Artist
        {
            get { return artist; }
            set { this.artist = value; }
        }

        public string Music
        {
            get { return music; }
            set { this.music = value; }
        }

        public string AlubumName
        {
            get { return AlubumName; }
            set { this.albumname = value; }
        }

        public string Lyrics
        {
            get { return lyrics; }
            set { this.lyrics = value; }
        }

        public string Arranged
        {
            get { return arrenged; }
            set { this.arrenged = value; }
        }

        public int No
        {
            get { return no; }
            set { this.no = value; }
        }

        public TimeSpan Playtime
        {
            get { return playtime; }
            set { this.playtime = value; }

        }
        public override string ToString()
        {
            return Title;
        }
    }
}
