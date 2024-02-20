using EY.BankApp.Web.Data.Context;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace EY.BankApp.Web.TagHelpers
{
    public class GetAccountCountTagHelper:TagHelper
    {
        public int AppUserId { get; set; }
        private readonly BankContext _context;
        
        public GetAccountCountTagHelper(BankContext context)
        {
            _context = context;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var accountCount = _context.Accounts.Count(x=>x.ApplicationUserId==AppUserId);
            var html = $"<span class='badge bg-danger'>{accountCount}</span>";
            output.Content.SetHtmlContent(html);
        }
    }
}
