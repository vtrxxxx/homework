
using DZ_13_Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DZ_13_Data.Entities
{
    [Table("Sessions")]
    public class Session
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string RoomName { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public TimeSpan StartTime { get; set; }
        [Required]
        public TimeSpan EndTime { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
