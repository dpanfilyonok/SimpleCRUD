namespace SimpleCRUD.TagHelpers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Models;

public class PageLinkTagHelper : TagHelper
{
    private readonly IUrlHelperFactory _urlHelperFactory;
    
    public PageLinkTagHelper(IUrlHelperFactory helperFactory)
    {
        _urlHelperFactory = helperFactory;
    }
    
    public PageViewModel? PageModel { get; set; }
    
    public string PageAction { get; set; } = "";
    
    [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
    public Dictionary<string, object> PageUrlValues { get; set; } = new();
    
    [ViewContext]
    [HtmlAttributeNotBound]
    public ViewContext ViewContext { get; set; } = null!;

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        if (PageModel == null) throw new Exception("PageModel is not set");
        
        var urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);
        var tag = new TagBuilder("ul");
        tag.AddCssClass("pagination");

        if (PageModel.HasPreviousPage)
        {
            var prevItem = CreateTag(urlHelper, PageModel.PageNumber - 1);
            tag.InnerHtml.AppendHtml(prevItem);
        }

        var currentItem = CreateTag(urlHelper, PageModel.PageNumber);
        tag.InnerHtml.AppendHtml(currentItem);
        
        if (PageModel.HasNextPage)
        {
            var nextItem = CreateTag(urlHelper, PageModel.PageNumber + 1);
            tag.InnerHtml.AppendHtml(nextItem);
        }
        
        output.TagName = "div";
        output.Content.AppendHtml(tag);
    }

    private TagBuilder CreateTag(IUrlHelper urlHelper, int pageNumber = 1)
    {
        var item = new TagBuilder("li");
        var link = new TagBuilder("a");
        
        if (pageNumber == PageModel?.PageNumber)
        {
            item.AddCssClass("active");
        }
        else
        {
            PageUrlValues["page"] = pageNumber;
            link.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);
        }
        
        item.AddCssClass("page-item");
        link.AddCssClass("page-link");
        link.InnerHtml.Append(pageNumber.ToString());
        item.InnerHtml.AppendHtml(link);
        
        return item;
    }
}