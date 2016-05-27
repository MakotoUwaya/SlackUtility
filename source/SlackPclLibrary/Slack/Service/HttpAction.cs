using System;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Slack
{
    /// <summary>
    /// HTTP送受信クラス
    /// </summary>
    public static class HttpAction
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        static HttpAction()
        {
            // プロキシ設定
            using (var handler = new HttpClientHandler())
            {
                handler.Proxy = WebRequest.DefaultWebProxy;
                handler.Proxy.Credentials = CredentialCache.DefaultNetworkCredentials;
            }
        }

        /// <summary>
        /// HTTP POST
        /// </summary>
        /// <param name="hooksUrl">POST先URL</param>
        /// <param name="post">ポストするデータ</param>
        /// <returns>HTTPステータスコード</returns>
        public async static Task<HttpStatusCode> PostJson(Uri hooksUrl, object post)
        {
            try
            {
               using (var wc = new HttpClient())
               {
                   // リクエストヘッダ指定
                   wc.DefaultRequestHeaders.Add("Accept", "application/json, */*");
                   wc.DefaultRequestHeaders.Add("Accept-Charset", "UTF-8");

                   // リクエストボディ指定
                   StringContent content = new StringContent(JsonConvert.SerializeObject(post), Encoding.UTF8, "application/json");

                   // POST送信と結果取得
                   HttpResponseMessage responce = await wc.PostAsync(hooksUrl, content);
                   return responce.StatusCode;
               }
            }
            catch
            {
                return HttpStatusCode.InternalServerError;
            }
        }
    }
}
