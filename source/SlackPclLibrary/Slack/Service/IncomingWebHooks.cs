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
    public static class IncomingWebHooks
    {
        /// <summary>
        /// メッセージ書込
        /// </summary>
        /// <param name="hooksUrl">POST先URL</param>
        /// <param name="post">ポストデータ</param>
        /// <returns>HTTPステータスコード</returns>
        public static HttpStatusCode Send(string hooksUrl, IncomingWebHooksJson post)
        {
            try
            {
                // プロキシ設定
                var handler = new HttpClientHandler();
                handler.Proxy = WebRequest.DefaultWebProxy;
                handler.Proxy.Credentials = CredentialCache.DefaultNetworkCredentials;

                // リクエストヘッダ指定
                var wc = new HttpClient();
                wc.DefaultRequestHeaders.Add("Accept", "application/json, */*");
                wc.DefaultRequestHeaders.Add("Accept-Charset", "UTF-8");

                // リクエストボディ指定
                StringContent content = new StringContent(JsonConvert.SerializeObject(post), Encoding.UTF8, "application/json"); 

                // POST送信と結果取得
                HttpResponseMessage responce = wc.PostAsync(new Uri(hooksUrl), content).Result;
                return responce.StatusCode;
            }
            catch
            {
                return HttpStatusCode.InternalServerError;
            }
        }
    }
}
