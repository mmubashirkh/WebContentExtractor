using System;
using WebContentExtractor.Common;
using System.Web.Configuration;
using NLog;
using WebContentExtractor.Project.Models;

namespace WebContentExtractor.Project.Mediator
{
    public class WebContentExtractorMediator : IWebContentExtractorMediator
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public WebContentModel GetWebPageModel(string targetUrl)
        {
            WebContentModel model = new WebContentModel();
            try
            {
                    var html = Helper.GetDocument(targetUrl);
                    
                    model.ImageUrls = Helper.GetImageUrls(html.ParsedText);
                    
                    var stringOfWords = Helper.DataWithoutHtmlTags(html.ParsedText);

                    model.TotalWordCount = Helper.CountWords(stringOfWords);

                    var topWordCount = WebConfigurationManager.AppSettings["TopCount"];
                    model.NumberOfWordsOccurence = Helper.GetTopWords(stringOfWords, Convert.ToInt32(topWordCount));
                    
                    return model;

            }
            catch (Exception ex)
            {
                logger.Error(ex.InnerException);
                return new WebContentModel { ErrorMessage = ex.Message };
            }

        }
    }
}