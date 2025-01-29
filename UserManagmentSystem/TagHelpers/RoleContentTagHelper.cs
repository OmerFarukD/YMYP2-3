using Microsoft.AspNetCore.Razor.TagHelpers;
using UserManagmentSystem.Models.Entities;

namespace UserManagmentSystem.TagHelpers;

public class RoleContentTagHelper : TagHelper
{
    public List<string> Roles { get; set; }

    public string FilterRole { get; set; }


    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        if (!Roles.Contains(FilterRole))
        {
            output.SuppressOutput();
        }
    }
}