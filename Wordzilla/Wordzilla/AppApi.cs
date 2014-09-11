using System;
using RestSharp;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Wordzilla
{
	public static class AppApi
	{
		static string serverApi = "http://wordzilla.ru/api/";
		static string forvoApi = "http://apifree.forvo.com/key/0efc821f5a359fac706c93ef49af689f/format/json/callback/pronounce/action/standard-pronunciation/word/";
		static RestClient webClient;

		static int EnteredGroup;
		static int CurrentUser;

		public static bool GroupSet{ get { return EnteredGroup != 0; } }

		public static bool CheckForInternetConnection()
		{
			try
			{
				using (var client = new WebClient())
				using (var stream = client.OpenRead("http://www.google.com"))
				{
					return true;
				}
			}
			catch
			{
				return false;
			}
		}

		static IRestResponse Request (string pathRequest, DataFormat df, Method method, Parameter[] parameters = null, string customServer = null, object body = null)
		{
			// save to storage
			string storageKey = string.Empty;
			if (parameters != null)
				foreach (var p in parameters)
				storageKey = pathRequest.Replace ("{" + p.Name + "}", p.Value.ToString ());
			else
				storageKey = pathRequest;

			if (!CheckForInternetConnection ()) {
				RestResponse pseudoResp = new RestResponse (); 
				pseudoResp.Content = Storage.Get (storageKey);
				return pseudoResp;
			}

			RestRequest request;
			if (customServer != null) {
				webClient = new RestClient (customServer);
				request = new RestRequest (method);
			} else {
				webClient = new RestClient (serverApi);
				request = new RestRequest (pathRequest, method);
			}

			request.RequestFormat = df; // json и пр

			if (parameters != null)
				foreach (var param in parameters)
					request.AddParameter (param.Name, param.Value, param.Type);

			if (body != null)
				request.AddBody (body);

			// добавляем если есть авторизационный токен
			//if (!EmptyAccToken())
			//	request.AddParameter("Authorization", GetAccessToken(), ParameterType.HttpHeader);

			// запускаем и получаем ответ
			var response = webClient.Execute (request);

			if(pathRequest!=null)
			Storage.Put (storageKey,response.Content);	

			return response;
		}

		public static bool Login ()
		{
			CurrentUser = 380429;//370306;
			return true;
		}

		public static bool SetGroup (int code)
		{
			Parameter[] parameters = { 
				new Parameter { Name = "code", Value = code, Type = ParameterType.UrlSegment },
				new Parameter { Name = "dbUserId", Value = CurrentUser, Type = ParameterType.UrlSegment },
			};
			var status = Request (@"Group/_Set?code={code}&dbUserId={dbUserId}", DataFormat.Json, Method.GET, parameters).Content != "Err";

			if (status)
				EnteredGroup = code;

			return status;
		}

		public static bool SetLearnWordExternal (long sheetId, int wordId, string type)
		{
			Parameter[] parameters = { 
				new Parameter { Name = "sheetId", Value = sheetId, Type = ParameterType.UrlSegment },
				new Parameter { Name = "wordid", Value = wordId, Type = ParameterType.UrlSegment },
				new Parameter { Name = "type", Value = type, Type = ParameterType.UrlSegment },
				new Parameter { Name = "dbuserid", Value = CurrentUser, Type = ParameterType.UrlSegment },
			};
			return Request (@"Flashcard/_SetLearnWordExternal?sheetId={sheetId}&wordid={wordid}&type={type}&dbuserid={dbuserid}", DataFormat.Json, Method.GET, parameters).Content != "Err";
		}

		public static Dictionary<string,object> UpdateField (int pk, string name, string value, int sheetWordId)
		{
			Parameter[] parameters = { 
				new Parameter { Name = "pk", Value = pk, Type = ParameterType.UrlSegment },
				new Parameter { Name = "name", Value = name, Type = ParameterType.UrlSegment },
				new Parameter { Name = "value", Value = value, Type = ParameterType.UrlSegment },
				new Parameter { Name = "sheetWordId", Value = sheetWordId, Type = ParameterType.UrlSegment },
			};
			var returnedData = Request (@"Words/UpdateField?pk={pk}&name={name}&value={value}&sheetWordId={sheetWordId}", DataFormat.Json, Method.GET, parameters).Content;

			return JsonConvert.DeserializeObject<Dictionary<string,object>> (returnedData);

		}

		public static Dictionary<string,object> GetListFlash (int sheetId)
		{
			Parameter[] parameters = { 
				new Parameter { Name = "dbUserId", Value = CurrentUser, Type = ParameterType.UrlSegment },
				new Parameter { Name = "sheetId", Value = sheetId, Type = ParameterType.UrlSegment }

			};
			return JsonConvert.DeserializeObject<Dictionary<string,object>> (Request (@"Flashcard/GetList?dbUserId={dbUserId}&sheetId={sheetId}", DataFormat.Json, Method.GET, parameters).Content);
		}

		public static Dictionary<string,object> GetMiniModelWord (int sheetId,int wordid)
		{
			Parameter[] parameters = { 
				new Parameter { Name = "dbUserId", Value = CurrentUser, Type = ParameterType.UrlSegment },
				new Parameter { Name = "sheetId", Value = sheetId, Type = ParameterType.UrlSegment }

			};
			var content = Request (@"Flashcard/GetList?dbUserId={dbUserId}&sheetId={sheetId}", DataFormat.Json, Method.GET, parameters).Content.Replace("{\"Data\":[","[").Replace("}]}","}]");
			var finded = JsonConvert.DeserializeObject<IEnumerable<Dictionary<string,object>>> (content);

			return finded.Where(x=>int.Parse(x["WordId"].ToString())== wordid).First();
		}

		public static StudentManagment.Words.Areas.api.Models.Sheet.TableModel GetSheets ()
		{
			Parameter[] parameters = { 
				new Parameter { Name = "dbUserId", Value = CurrentUser, Type = ParameterType.UrlSegment }
			};

			return JsonConvert.DeserializeObject<StudentManagment.Words.Areas.api.Models.Sheet.TableModel> (Request (@"Sheet/GetSheets?dbUserId={dbUserId}", DataFormat.Json, Method.GET, parameters).Content);
		}


		public static StudentManagment.Words.Areas.api.Models.Sheet.EditModel GetEdit (int id, long groupId, int typeId)
		{
			Parameter[] parameters = { 
				new Parameter { Name = "id", Value = id, Type = ParameterType.UrlSegment },
				new Parameter { Name = "groupId", Value = groupId, Type = ParameterType.UrlSegment },
				new Parameter { Name = "typeId", Value = typeId, Type = ParameterType.UrlSegment }
			};

			var respData = Request (@"Sheet/_GetEdit?id={id}&groupId={groupId}&typeId={typeId}", DataFormat.Json, Method.GET, parameters).Content;
			return JsonConvert.DeserializeObject<StudentManagment.Words.Areas.api.Models.Sheet.EditModel> (respData);
		}

		public static bool DeleteSheet (int id)
		{
			Parameter[] parameters = { 
				new Parameter { Name = "id", Value = id, Type = ParameterType.UrlSegment }
			};
			return Request (@"Sheet/_Delete?id={id}", DataFormat.Json, Method.GET, parameters).Content != "Err";
		}

		public static StudentManagment.Words.Areas.api.Models.Words.TableModel Copy (int id)
		{
			Parameter[] parameters = { 
				new Parameter { Name = "id", Value = id, Type = ParameterType.UrlSegment }
			};
			return JsonConvert.DeserializeObject<StudentManagment.Words.Areas.api.Models.Words.TableModel> (Request (@"Words/GetDataTable?id={id}", DataFormat.Json, Method.GET, parameters).Content);
		}

		public static StudentManagment.Words.Areas.api.Models.Flashcard.SequenceModel GetSequenceExternal (long id)
		{
			Parameter[] parameters = { 
				new Parameter { Name = "sheetId", Value = id, Type = ParameterType.UrlSegment },
				new Parameter { Name = "dbUserId", Value = CurrentUser, Type = ParameterType.UrlSegment }
			};
			return JsonConvert.DeserializeObject<StudentManagment.Words.Areas.api.Models.Flashcard.SequenceModel> (Request (@"Flashcard/GetSequenceExternal?sheetId={sheetId}&dbUserId={dbUserId}", DataFormat.Json, Method.GET, parameters).Content);
		}

		public static StudentManagment.Words.Areas.api.Models.Words.TableModel GetDataTable (long id)
		{
			Parameter[] parameters = { 
				new Parameter { Name = "id", Value = id, Type = ParameterType.UrlSegment }
			};
			return JsonConvert.DeserializeObject<StudentManagment.Words.Areas.api.Models.Words.TableModel> (Request (@"Words/GetDataTable?id={id}", DataFormat.Json, Method.GET, parameters).Content);
		}

		public static bool DeleteWord (int id)
		{
			Parameter[] parameters = { 
				new Parameter { Name = "id", Value = id, Type = ParameterType.UrlSegment }
			};
			return Request (@"Words/_Delete?id={id}", DataFormat.Json, Method.GET, parameters).Content != "Err";
		}

		//forvo
		public static string Mp3Url (string word, string lang = "en")
		{
			try {
				string Url = forvoApi + word + "/language/" + lang;
				var content = Request (null, DataFormat.Json, Method.GET, null, Url).Content.Replace ("]})", "").Replace ("pronounce({\"items\":[", "");

				var obj = JsonConvert.DeserializeObject<Dictionary<string,object>> (content);
				return obj ["pathmp3"].ToString ();
			} catch {
				return string.Empty;
			}
		}
	}
}

