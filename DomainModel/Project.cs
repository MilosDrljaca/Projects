using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace DomainModel
{
    public class Project
    {
        [Key]
        [DisplayName("Id")]
        public int ID_Project { get; set; }

        [Required(ErrorMessage = "Project name is required!")]
        [DisplayName("Name")]
        public string ProjectName { get; set; }

        [Required(ErrorMessage = "Start date is required!")]
        [DisplayName("Start Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime StartDate { get; set; }

        [DisplayName("End Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? EndDate { get; set; }


        [ForeignKey("Manager")]
        [DisplayName("Manager")]
        public int ID_Manager { get; set; }
        public Manager Manager { get; set; }
    }
}