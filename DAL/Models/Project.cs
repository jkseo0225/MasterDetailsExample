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

        [Required, StringLength(30)]
        public string ProjectName { get; set; }
        public string ProjectClient { get; set; }
        public string ProjectClass { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ProjectEvent { get; set; }

        [InverseProperty("Project")]
        public List<Block> Blocks { get; set; }
    }
}
