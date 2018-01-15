using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using LyftSDK.Net.Helpers;
using LyftSDK.Net.WebHook.Extensions;
using Newtonsoft.Json;

namespace LyftSDK.Net.WebHook.Controllers
{
	public class HookController : ApiController
	{
		[HttpPost]
		public async Task<HttpResponseMessage> Lyft()
		{
			try
			{
				string json = await Request.Content.ReadAsStringAsync();

				#region Webhook verification

				string signature = Request.GetHeaderValue("X-Lyft-Signature");
				if (string.IsNullOrEmpty(signature))
					return Request.CreateResponse(HttpStatusCode.Forbidden);

				if (signature.StartsWith("sha256="))
					signature = signature.Substring(7);

				string webhookToken = ConfigurationManager.AppSettings["LyftWebhookVerificationToken"];

				if (!LyftSignature.IsSendedByLyft(webhookToken, json, signature))
					return Request.CreateResponse(HttpStatusCode.Forbidden);

				#endregion Webhook verification

				var webHookData = await JsonDeserialize<Models.WebHook>(json);

				// do stuff

				return Request.CreateResponse(HttpStatusCode.OK);

			}
			catch (Exception e)
			{
				// log exception

				return Request.CreateResponse(HttpStatusCode.InternalServerError);
			}
			finally
			{
				// log info
			}
		}

		[HttpGet]
		public string Test()
		{
			return $"Test. {DateTime.Now}. MachineName: {Environment.MachineName}. {Environment.CurrentDirectory}";
		}

		#region Helper method

		private Task<T> JsonDeserialize<T>(string jsonString)
		{
			Task<T> ser = Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(jsonString));
			return ser;
		}

		#endregion Helper method
	}
}