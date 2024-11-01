using System;
using Newtonsoft.Json.Linq;

namespace TFL.Utilities
{
	public class JsonReader
	{
		public JsonReader()
		{

		}
		public string extractData(String Token)
		{
			var MyJsonString = File.ReadAllText("Utilities/TestData.json");

			var jsonObject = JToken.Parse(MyJsonString);
			return jsonObject.SelectToken(Token).Value<string>();
		}
	}
}

