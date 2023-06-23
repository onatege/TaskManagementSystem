namespace TaskManagerProject.Contracts
{
	public interface IProjectUpdateContract
	{
		string ProjectContent { get; set; }
		string ProjectDescription { get; set; }
		bool ProjectStatus { get; set; }
		
	}
}
