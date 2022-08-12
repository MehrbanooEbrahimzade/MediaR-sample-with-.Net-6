namespace Application.Feature.Dtos
{
    public class ShowProjectDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string About { get; set; }
        public List<ProjectSliderPictureDto> ProjectSliderPictures { get; set; }
    }
}
