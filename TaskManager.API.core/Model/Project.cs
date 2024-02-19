using System.ComponentModel.DataAnnotations;

namespace TaskManager.API.Core.Model
{
    public class Project
    {

        [Key]
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        [DisplayFormat(DataFormatString = "d/M/yyyy")]
        public DateTime DateOfStart { get; set; }
        public int TeamSize { get; set; }
    }
}
