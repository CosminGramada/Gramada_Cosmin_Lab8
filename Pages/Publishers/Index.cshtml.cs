using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Gramada_Cosmin_Lab8.Data;
using Gramada_Cosmin_Lab8.Models;

namespace Gramada_Cosmin_Lab8.Pages.Publishers
{
    public class IndexModel : PageModel
    {
        private readonly Gramada_Cosmin_Lab8Context _context;

        public IndexModel(Gramada_Cosmin_Lab8Context context)
        {
            _context = context;
        }

        public IList<Publisher> Publisher { get;set; }

        public async Task OnGetAsync()
        {
            Publisher = await _context.Publisher.ToListAsync();
        }
    }
}
