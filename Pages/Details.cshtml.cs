using ImagesWithStudents.Model;
using ImagesWithStudents.Operations;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ImagesWithStudents.Pages
{

    public class DetailsModel : PageModel
    {

        //all the staff in a list
        //[BindProperty]
        public SelectList Staff { get; set; }

        //selected stamm member with all details

        [BindProperty]
        public PersonDetails? SelectedStaff { get; set; }

        [BindProperty]
        public int SelectedStaffId { get; set; }



        //run before loading the page to generate the elements in the page. First time the page is loaded, it will run the OnGet method
        public void OnGet()
        {

            SelectedStaff = new PersonDetails();

            _loadImages();
        }

        //ctor runs when the class is accessed

        //run after the page is loaded or when the form is submitted
        public void OnPost()
        {
            foreach (var item in StaticPersonDetails.StaticAllStaff)
            {
                if (item.Id == SelectedStaffId)
                {
                    SelectedStaff.Id = item.Id;
                    SelectedStaff.Name = item.Name;
                    SelectedStaff.Age = item.Age;
                    SelectedStaff.ImagePath = item.ImagePath;
                    SelectedStaff.Occupation = item.Occupation;
                    SelectedStaff.MobileNumber = item.MobileNumber;
                }
            }
            _loadImages();
        }

        //this is why we use a select list.
        private void _loadImages()
        {
            Staff = new SelectList(StaticPersonDetails.StaticAllStaff, nameof(PersonDetails.Id), nameof(PersonDetails.Name), null);


        }
    }
}