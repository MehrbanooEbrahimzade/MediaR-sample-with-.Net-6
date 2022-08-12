namespace Domain.Entities
{
    public class Project
    {
        public Project() { }

        public Project(string title, string about)
        {
            Id = Guid.NewGuid();
            Title = title;
            About = about;
        }
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string About { get; private set; }


        public void UpdateProject(string title, string about)
        {
            Title = title;
            About = about;
        }
    }
}
