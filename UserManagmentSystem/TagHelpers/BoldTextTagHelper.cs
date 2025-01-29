using Microsoft.AspNetCore.Razor.TagHelpers;

namespace UserManagmentSystem.TagHelpers;

public class BoldTextTagHelper : TagHelper
{
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "strong";
        output.TagMode = TagMode.StartTagAndEndTag;
    }
}