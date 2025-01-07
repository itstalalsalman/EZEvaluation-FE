using BLL.DAL;


namespace BLL.Models
{
    public class EvaluatedModel
    {
        public Evaluated Record { get; set; }

        public string Name => Record.Name;

        public string Surname => Record.Surname;

        public string FullName => $"{Name} {Surname}";

    }
}
