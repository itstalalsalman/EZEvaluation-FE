using BLL.DAL;
using System.ComponentModel;


namespace BLL.Models
{
    public class EvaluationModel
    {
        public Evaluation Record { get; set; }

        public string Title => Record.Title;

        public string Score => Record.Score.ToString();

        public string Date => Record.Date.ToString("dd/MM/yyyy");

        public string Description => Record.Description;

        public string User => Record.User?.UserName;

        public string Evaluateds => Record.User?.UserName;

        public int EvaluatedsCount => Record.EvaluatedEvaluations.Count;

        [DisplayName("Evaluateds")]
        public List<int> EvaluatedIds
        {
            get => Record.EvaluatedEvaluations?.Select(po => po.EvaluatedId).ToList();
            set => Record.EvaluatedEvaluations = value.Select(v => new EvaluatedEvaluation() { EvaluatedId = v }).ToList();
        }

    }
}
