using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ImagesWithStudents.Pages
{
    public class DetailsModel : PageModel
    {
        //holds the selected image path
        public string? ImagePath { get; set; }

        //a list of all images in the wwwroot/images folder
        public List<string> ImagepathList = new List<string>();


        //run before loading the page to generate the elements in the page. First time the page is loaded, it will run the OnGet method
        public void OnGet()
        {
            ImagepathList = _loadImages();
        }

        //ctor runs when the class is accessed

        //run after the page is loaded or when the form is submitted
        public void OnPost()
        {
            ImagepathList = _loadImages();
        }

        private List<string> _loadImages()
        {

            List<string> _lmagepathList = new List<string>();


            // Get the path to the wwwroot folder
            string _wwwrootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images");

            // Get all files in the wwwroot folder
            string[] allFiles = Directory.GetFiles(_wwwrootPath, "*.*", SearchOption.AllDirectories);

            foreach (var item in allFiles)
            {
                // string _fileName = Path.GetFileName(item);

                string fileName = Path.GetRelativePath("wwwroot\\images", item); //this works as well.
                _lmagepathList.Add(fileName);

            }
            return _lmagepathList;

        }
    }
}