using System;
using PerpetualEngine.Storage;
using StudentManagment.Words.Areas.api.Models.Sheet;
using Newtonsoft.Json;

namespace Wordzilla
{
	public static class Storage
	{
		public static string Get (string key)
		{
			var storage = SimpleStorage.EditGroup ("app");
			var value = storage.Get(key);
			return value;
		}

		public static void Put (string key,string jsonObj)
		{
			var storage = SimpleStorage.EditGroup ("app");
			storage.Put(key,jsonObj);
		}

		public static void SaveSheets (TableModel tm)
		{
			var storage = SimpleStorage.EditGroup ("app/Sheets");

			storage.Put<TableModel> ("ListSheets", tm);
		}
	}
}

