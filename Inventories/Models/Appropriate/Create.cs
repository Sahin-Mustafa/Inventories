using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Inventories.Models.Appropriate
{
    public class Create
    {
        [Required]
        public int SelectedMaterial { get; set; }

        [Required]
        public int SelectedEmployee { get; set; }
        public SelectList? Materials { get; set; }
        public SelectList? Employees { get; set; }
    }
}
