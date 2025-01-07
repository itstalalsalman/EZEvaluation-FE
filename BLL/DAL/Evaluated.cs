using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class Evaluated
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        public List<EvaluatedEvaluation> EvaluatedEvaluations { get; set; } = new List<EvaluatedEvaluation>();


    }
}
