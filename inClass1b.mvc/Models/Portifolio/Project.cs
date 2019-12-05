using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace inClass1b.mvc.Models.Portifolio
{
    public class Project
    {
        //Key notation to assign Primary Key
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        //Navigation Properties
        //Child Tables
        public virtual ICollection<ProjectTechnology> ProjectTechnologies { get; set; }

    }
}
