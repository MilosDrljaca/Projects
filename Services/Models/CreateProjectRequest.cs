using DomainModel;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Services.Models
{
    public class CreateProjectRequest
    {
        [Required(ErrorMessage = "Project name is required!")]
        [DisplayName("Name")]
        public string ProjectName { get; set; }

        [DisplayName("Id")]
        public int ProjectId { get; set; }
        [DisplayName("Start Date")]

        [Required(ErrorMessage = "Start date is required!")]
        public DateTime StartDate { get; set; }

        [DisplayName("End Date")]
        public DateTime? EndDate { get; set; }
        [DisplayName("Manager")]
        public int ID_Manager { get; set; }

        public List<Manager> Managers { get; set; }
    }
}