using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using brickwell2.Models.ViewModels;

namespace brickwell2.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")]

    public class UserPaginationTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;

        public UserPaginationTagHelper(IUrlHelperFactory temp)
        {
            urlHelperFactory = temp;
        }

        [ViewContext] 
        [HtmlAttributeNotBound] 
        public ViewContext? ViewContext { get; set; }
        public string? PageAction { get; set; }
        public UserPagination PageModel { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (ViewContext != null && PageModel != null)
            {
                IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
                TagBuilder result = new TagBuilder("div");
                for (int i = 1; i <= PageModel.TotalNumPages; i++)
                {
                    TagBuilder tag = new TagBuilder("a");
                    tag.Attributes["href"] = urlHelper.Action(PageAction, new { pageNum = i });
                    tag.InnerHtml.Append(i.ToString());

                    result.InnerHtml.AppendHtml(tag);
                }

                output.Content.AppendHtml(result.InnerHtml);
            }
        }
    }
}