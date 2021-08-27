using System;
using System.Xml;


namespace ConsoleApp1
{
    /// <summary>
    /// XMLを書き込むサンプル
    /// </summary>
    class Program
    {
        /// <summary>
        /// メイン
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

           

            // 出力する場所を指定
            XmlWriter writer = XmlWriter.Create(@"C:\Users\h-kashiwagi\Desktop\サテライトオフィス\XMLプロジェクト\ConsoleApp1\xmlDocument.xml");

            // 要素sampleXmlを指定
            writer.WriteStartElement("sampleXml");

            // 要素valueに値を指定
            writer.WriteElementString("value", "AAAA");

            // 要素testを指定（属性あり）
            writer.WriteStartElement("test");
            writer.WriteAttributeString("testID", "123");

            // 要素priceに値を指定
            writer.WriteElementString("price", "47821");

            // 要素testの閉じタグ指定
            writer.WriteEndElement();

            // 要素sampleXmlの閉じタグを指定
            writer.WriteEndElement();

            // xmlに書き込む
            writer.Close();

            Console.WriteLine("xmlに書き込みが完了しました。");
        }
    }
}