using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Display(Name = "PROJECT(공사명)")]
        [Required, StringLength(30)]
        public string ProjectName { get; set; }
        [Display(Name = "CLIENT(발주처)")]
        public string ProjectClient { get; set; }
        [Display(Name = "CLASS(선급)")]
        public string ProjectClass { get; set; }

        [Display(Name = "제작 착수일")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime StartDate { get; set; }
        [Display(Name = "제작 마감일")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime EndDate { get; set; }
        [Display(Name = "이벤트")]
        public string ProjectEvent { get; set; }

        [InverseProperty("Project")]
        public List<Block> Blocks { get; set; }
    }
}
