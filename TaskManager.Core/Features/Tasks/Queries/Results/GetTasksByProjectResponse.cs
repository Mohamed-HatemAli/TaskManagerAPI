namespace TaskManager.Core.Features.Tasks.Queries.Results
{
    public class GetTasksByProjectResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}
