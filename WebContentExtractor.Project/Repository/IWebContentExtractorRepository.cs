using WebContentExtractor.Project.Models;

namespace WebContentExtractor.Project.Mediator
{
    public interface IWebContentExtractorMediator
    {
        WebContentModel GetWebPageModel(string targetUrl);
    }
}
