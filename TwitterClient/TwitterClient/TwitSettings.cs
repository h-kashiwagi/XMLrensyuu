using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TwitterClient
{
    public class TwitSettings
    {
        #region メンバ変数
        private string _userID;
        private string _screenName;

        private string _requestToken;
        private string _requestSecretToken;

        private string _accessToken;
        private string _accessSecretToken;
        #endregion

        #region プロパティ
        public string UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        public string ScreenName
        {
            get { return _screenName; }
            set { _screenName = value; }
        }

        // リクエストトークンはXMLに書き込まない
        [System.Xml.Serialization.XmlIgnoreAttribute]
        public string RequestToken
        {
            get { return _requestToken; }
            set { _requestToken = value; }
        }

        // リクエストシークレットはXMLに書き込まない
        [System.Xml.Serialization.XmlIgnoreAttribute]
        public string RequestSecretToken
        {
            get { return _requestSecretToken; }
            set { _requestSecretToken = value; }
        }

        public string AccessToken
        {
            get { return _accessToken; }
            set { _accessToken = value; }
        }

        public string AccessSecretToken
        {
            get { return _accessSecretToken; }
            set { _accessSecretToken = value; }
        }
        #endregion
    }


}
