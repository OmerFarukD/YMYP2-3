using Microsoft.AspNetCore.Razor.TagHelpers;

namespace UserManagmentSystem.TagHelpers;

[HtmlTargetElement("user-name")]
public class UsernameTagHelper : TagHelper
{

    public string Name { get; set; }
    
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "p";
        output.Content.SetContent($"Hoş Geldiniz : {Name}");
    }
}