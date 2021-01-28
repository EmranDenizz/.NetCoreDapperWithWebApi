using System.ComponentModel.DataAnnotations;

namespace Dapper.Business.Models
{
    public class Player
    { 
        public int id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
