using GatherContentConnect.Interface;
using Newtonsoft.Json;

namespace GatherContentConnect.Objects
{
	public class GcFile : IGcFile
	{
		//Species the Id of a File. 
        [JsonProperty("id")]
		public int Id { get; set; }
		//Species the UserId of a File.
		[JsonProperty("user_id")]
		public int UserId { get; set; }
		//Species the Item Id.
		[JsonProperty("item_id")]
		public int ItemId { get; set; }
        //Species the Field.
	    [JsonProperty("field")]
        public string Field { get; set; }
        //Species the Type of the File.
	    [JsonProperty("type")]
        public string Type { get; set; }
        //Species the URL of a File.
	    [JsonProperty("url")]
        public string Url { get; set; }
        //Species the FileName of a File.
	    [JsonProperty("filename")]
        public string FileName { get; set; }
        //Species the size of a File.
	    [JsonProperty("size")]
        public int Size { get; set; }
		//Species the date and time when it was created at.
		[JsonProperty("created_at")]
		public string CreatedAt { get; set; }
		//Species the date and time when it was updated at.
		[JsonProperty("updated_at")]
		public string UpdateAt { get; set; }
	}
}
