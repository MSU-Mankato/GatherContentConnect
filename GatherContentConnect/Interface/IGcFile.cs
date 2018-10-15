namespace GatherContentConnect.Interface
{
	public interface IGcFile
	{
		//Species the Id of a File. 
		int Id { get; set; }
		//Species the UserId of a File.
		int UserId { get; set; }
		//Species the Item Id.
		int ItemId { get; set; }
		//Species the Filed.
		string Field { get; set; }
		//Species the Type of the File.
		string Type { get; set; }
		//Species the URL of a File.
		string Url { get; set; }
		//Species the FileName of a File.
		string FileName { get; set; }
		//Species the size of a File.
		int Size { get; set; }
		//Species the date and time when it was created at.
		string CreatedAt { get; set; }
		//Species the date and time when it was updated at.
		string UpdateAt { get; set; }
	}

}
