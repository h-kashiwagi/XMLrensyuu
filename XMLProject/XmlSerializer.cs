using System;

public class Class1
{
    ///<summary>社員情報</summary>
    [XmlRoot("社員情報リスト")]
    public class EmployeeInfoList
    {
        [XmlElement("社員情報")]
        public List<EmployeeInfo> list = new List<EmployeeInfo>();
    }

    ///<summary>社員情報</summary>
    publicstruct EmployeeInfo
    {
        [XmlElement("社員番号")]
        publicint no;
        [XmlElement("部署")]
        public String part;
        [XmlElement("氏名")]
        public NameInfo name;
        [XmlElement("連絡先")]
        public ContactInfo contact;
    }
    ///<summary>氏名情報</summary>
    publicstruct NameInfo
    {
        [XmlElement("苗字")]
        public String family;
        [XmlElement("名前")]
        public String name;
    }

    ///<summary>連絡先情報</summary>
    publicstruct ContactInfo
    {
        [XmlElement("住所")]
        public String addr;
        [XmlElement("電話番号")]
        public String phone;
        [XmlElement("携帯番号")]
        public String portable;
    }
    ///<summary>
    /// ボタン１押下イベント
    /// XMLファイル読み込み処理を行う
    ///</summary>
    privatevoid button1_Click(object sender, EventArgs e)
    {
        // ファイルパス(カレントディレトリ直下のText.xml固定)
        String filepath = String.Format("{0}\\Test.xml", Application.StartupPath);

        StreamReader sr = null;
        XmlSerializer xs = null;
        EmployeeInfoList target = null;
        String err = "";

        // XMLファイル読み込み(XmlSerializerによるデシリアライズ)
        try
        {
            //ファイル読み込みインスタンス作成
            sr = new StreamReader(filepath, Encoding.UTF8);
            //XMLシリアライザクラスインスタンス作成
            xs = new XmlSerializer(typeof(EmployeeInfoList));

            //XMLファイルデシリアライズ
            target = (EmployeeInfoList)xs.Deserialize(sr);
        }
        catch (Exception exp)
        {//例外発生
            err = exp.Message;
        }
        finally
        {//インスタンス破棄
            if (sr != null)
            {
                sr.Close();
                sr.Dispose();
            }
        }
    }

}
