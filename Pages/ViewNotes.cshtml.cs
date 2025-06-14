using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;

namespace AgenciaTurismo.Pages
{
    public class ViewNotesModel : PageModel
    {
        private readonly IWebHostEnvironment _environment;
        private readonly string _notesDirectory;

        [BindProperty]
        public string NoteTitle { get; set; }

        [BindProperty]
        public string NoteContent { get; set; }

        public List<string> NoteFiles { get; set; } = new List<string>();
        public string SelectedNoteContent { get; set; }

        public ViewNotesModel(IWebHostEnvironment environment)
        {
            _environment = environment;
            _notesDirectory = Path.Combine(_environment.WebRootPath, "files");
            Directory.CreateDirectory(_notesDirectory);
        }

        public void OnGet(string fileName = null)
        {
            LoadNoteFiles();

            if (!string.IsNullOrEmpty(fileName))
            {
                var filePath = Path.Combine(_notesDirectory, fileName);
                if (System.IO.File.Exists(filePath))
                {
                    SelectedNoteContent = System.IO.File.ReadAllText(filePath);
                }
            }
        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrWhiteSpace(NoteTitle) || string.IsNullOrWhiteSpace(NoteContent))
            {
                ModelState.AddModelError("", "Título e conteúdo da nota são obrigatórios.");
                LoadNoteFiles();
                return Page();
            }

            var fileName = $"{Path.GetInvalidFileNameChars().Aggregate(NoteTitle, (current, c) => current.Replace(c, '_'))}.txt";
            var filePath = Path.Combine(_notesDirectory, fileName);

            System.IO.File.WriteAllText(filePath, NoteContent);

            return RedirectToPage();
        }

        private void LoadNoteFiles()
        {
            NoteFiles = Directory.GetFiles(_notesDirectory)
                                 .Select(Path.GetFileName)
                                 .ToList();
        }
    }
}