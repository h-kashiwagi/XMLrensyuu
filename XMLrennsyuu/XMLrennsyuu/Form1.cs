using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace XMLrennsyuu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            XmlDocument myDoc = new XmlDocument();
            myDoc.Load(@"C:\Users\h-kashiwagi\Desktop\サテライトオフィス\XMLrennsyuu\XMLrennsyuu\XML\Cdlist.xml");
            XmlNode rootElement = myDoc.DocumentElement;
            
            //ChildNodesプロパティによってXmlNodeListオブジェクトを取得
            foreach(XmlNode currentNode in rootElement.ChildNodes)
            {
                //currentNodeの種類が要素でかつ、currentNodeの名前がCDの場合==CD要素のNodeの場合
                if(currentNode.NodeType == XmlNodeType.Element && currentNode.Name == "CD")
                {
                    //リストビューに表示するための準備
                    ListViewItem lvItem = new ListViewItem();
                    lvItem.SubItems.AddRange(new string[] { "", "" });

                    //CD要素の子ノードのリストから値を取り出す
                    foreach (XmlNode subNode in currentNode.ChildNodes)
                    {
                        //子ノードの中のノードの種類が要素の場合
                        if (subNode.NodeType == XmlNodeType.Element)
                        
                            switch (subNode.Name)
                            {
                                case "Title":
                                    lvItem.SubItems[0].Text = subNode.InnerText; //内容を変数にセット
                                    break;
                                case "Artist":
                                    lvItem.SubItems[1].Text = subNode.InnerText;
                                    break;
                                case "ReleaseData":
                                    lvItem.SubItems[2].Text = subNode.InnerText;
                                    break;
                            }
                        
                    }
                    listView1.Items.Add(lvItem);
                }

            }
        }

        
    }
}
