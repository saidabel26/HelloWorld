using HelloWorld.Core.Application.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorld.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly INamesRepository _repository;
        public IndexModel(INamesRepository repository) => _repository = repository;

        [BindProperty]
        public string? NewName { get; set; }

        public IEnumerable<string> Names { get; set; } = Enumerable.Empty<string>();

        public async Task OnGetAsync() => Names = await _repository.GetNamesAsync();

        public async Task<IActionResult> OnPostAsync()
        {
            if (!string.IsNullOrWhiteSpace(NewName))
            {
                await _repository.AddNameAsync(NewName.Trim());
            }
            return RedirectToPage();
        }
    }
}