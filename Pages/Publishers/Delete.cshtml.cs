﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Gramada_Cosmin_Lab8.Data;
using Gramada_Cosmin_Lab8.Models;

namespace Gramada_Cosmin_Lab8.Pages.Publishers
{
    public class DeleteModel : PageModel
    {
        private readonly Gramada_Cosmin_Lab8Context _context;

        public DeleteModel(Gramada_Cosmin_Lab8Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Publisher Publisher { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Publisher = await _context.Publisher.FirstOrDefaultAsync(m => m.ID == id);

            if (Publisher == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var books = await _context
                .Book
                .Where(b => b.PublisherID == id)
                .ToListAsync();

            if (books.Count != 0)
            {
                ErrorMessage = "Unable to delete Publisher as it is used in one or more books";
                return Page();
            }

            Publisher = await _context.Publisher.FindAsync(id);

            if (Publisher != null)
            {
                _context.Publisher.Remove(Publisher);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
