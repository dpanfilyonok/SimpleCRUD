namespace SimpleCRUD.TagHelpers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Models;

public class SortHeaderTagHelper : TagHelper
{
    private readonly IUrlHelperFactory _urlHelperFactory;
    
    public SortHeaderTagHelper(IUrlHelperFactory helperFactory)
    {
        _urlHelperFactory = helperFactory;
    }
    
    public SortState Property { get; set; } // значение текущего свойства, для которого создается тег
    public SortState Current { get; set; }  // значение активного свойства, выбранного для сортировки
    public string? Action { get; set; }  // действие контроллера, на которое создается ссылка
    public bool Up { get; set; }    // сортировка по возрастанию или убыванию
 
    [ViewContext]
    [HtmlAttributeNotBound]
    public ViewContext ViewContext { get; set; } = null!;

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);
        var url = urlHelper.Action(Action, new {sortOrder = Property});
        output.TagName = "a";
        output.Attributes.SetAttribute("href", url);
        
        if (Current != Property) return;
        var tag = new TagBuilder("i");
        tag.AddCssClass("glyphicon");
        tag.AddCssClass(Up ? "glyphicon-chevron-up" : "glyphicon-chevron-down");

        output.PreContent.AppendHtml(tag);
    }
}