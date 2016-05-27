using System;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace Slack
{
    /// <summary>
    /// Slack投稿
    /// incoming-webhook連携
    /// </summary>
    public class IncomingWebHooks
    {
        Uri hooksUrl; 

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="url">送信先URL</param>
        public IncomingWebHooks(Uri url)
        {
            hooksUrl = url;
        }

        /// <summary>
        /// メッセージ書込
        /// </summary>
        /// <param name="post">ポストデータ</param>
        /// <returns>HTTPステータスコード</returns>
        public HttpStatusCode Send(IncomingWebHooksJson post)
        {
            return HttpAction.PostJson(hooksUrl, post).Result;
        }
    }
}
