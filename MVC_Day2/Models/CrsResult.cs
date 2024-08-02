using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Day2.Models
{
    public class CrsResult
    {
        public int Id { get; set; }
        public int Degree { get; set; }

        [ForeignKey("Trainee")]
        public int TraineeId { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }


        public virtual Trainee? Trainee { get; set; }
        public virtual Course? Course { get; set; }
    }
}
