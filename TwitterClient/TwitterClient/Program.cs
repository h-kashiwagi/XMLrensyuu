using System;
using System.IO;
using System.Xml.Serialization;

namespace TwitterClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // いろいろ格納
            TwitSettings settings = new TwitSettings();
            settings.UserID = "userId";
            settings.ScreenName = "screenName";
            settings.RequestToken = "requestToken";
            settings.RequestSecretToken = "requestSecret";
            settings.AccessToken = "accessToken";
            settings.AccessSecretToken = "accessSecret";


            //---------------------------
            // 1.XMLファイルに保存
            //---------------------------

            // XmlSerializerを使ってファイルに保存（TwitSettingオブジェクトの内容を書き込む）
            XmlSerializer serializer = new XmlSerializer(typeof(TwitSettings));

            // カレントディレクトリに"settings.xml"というファイルで書き出す
            FileStream fs = new FileStream(Directory.GetCurrentDirectory() + "\\" + "settings.xml", FileMode.Create);

            // オブジェクトをシリアル化してXMLファイルに書き込む
            serializer.Serialize(fs, settings);
            fs.Close();
            //---------------------------
            // 2.XMLファイルを読み込む
            //---------------------------

            // XMLをTwitSettingsオブジェクトに読み込む
            //TwitSettings settings = new TwitSettings();
            fs = new FileStream(Directory.GetCurrentDirectory() + "\\" + "settings.xml", FileMode.Open);

            // XMLファイルを読み込み、逆シリアル化（復元）する
            settings = (TwitSettings)serializer.Deserialize(fs);
            fs.Close();


            //---------------------------
            // 3.読み込んだデータを出力
            //---------------------------

            Console.WriteLine("### XMLファイルから読み込み ###");
            Console.WriteLine("UserId           :  " + settings.UserID);
            Console.WriteLine("ScreenName       :  " + settings.ScreenName);
            Console.WriteLine("AccessToken      :  " + settings.AccessToken);
            Console.WriteLine("AccessSecretToken:  " + settings.AccessSecretToken);
        }
    }
}
