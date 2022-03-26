using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
        public List<Incident> Incidents { get; set; }
    }
}
