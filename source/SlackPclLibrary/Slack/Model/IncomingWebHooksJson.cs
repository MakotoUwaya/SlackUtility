using System;
using Newtonsoft.Json;

namespace Slack
{
    /// <summary>
    /// POSTデータ アイコン指定無し
    /// </summary>
    public class IncomingWebHooksJson
    {
        /// <summary>
        /// チャンネル
        /// </summary>
        [JsonProperty("channel")]
        public string channel { get; set; }

        /// <summary>
        /// ユーザ名
        /// </summary>
        [JsonProperty("username")]
        public string username { get; set; }

        /// <summary>
        /// 本文
        /// </summary>
        [JsonProperty("text")]
        public string text { get; set; }    
    }

    /// <summary>
    /// POSTデータ アイコン絵文字指定
    /// </summary>
    public class IncomingWebHooksJsonWithIconEmoji : IncomingWebHooksJson
    {
        /// <summary>
        /// アイコン指定文字列
        /// </summary>
        [JsonProperty("icon_emoji")]
        public string icon_emoji { get; set; }   
    }

    /// <summary>
    /// POSTデータ アイコンURL指定
    /// </summary>
    public class IncomingWebHooksJsonWithIconUrl : IncomingWebHooksJson
    {
        /// <summary>
        /// アイコン指定URL
        /// </summary>
        [JsonProperty("icon_url")]
        public Uri icon_url { get; set; }
    }
}
