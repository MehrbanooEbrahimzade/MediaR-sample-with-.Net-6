using MediatR;

namespace Application.Feature.Commands
{
    public class ProjectSliderPictureCommand : IRequest<Guid>
    {
        public Guid Attachment { get; set; }
    }
}