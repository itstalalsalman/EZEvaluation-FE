using System.ComponentModel.DataAnnotations;



namespace BLL.DAL
{
    public class Evaluation
    {
       public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; }

        public decimal Score { get; set; }

        public DateTime Date { get; set; }

        [StringLength(500)]
        public string Description { get; set; } 

        public int UserId { get; set; }

        public User User { get; set; }

        public List<EvaluatedEvaluation> EvaluatedEvaluations { get; set; } = new List<EvaluatedEvaluation>();

    }
}
