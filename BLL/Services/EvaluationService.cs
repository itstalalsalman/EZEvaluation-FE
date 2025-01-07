using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class EvaluationService : Service, IService<Evaluation, EvaluationModel>
    {
        public EvaluationService(Db db) : base(db)
        {

        }

        public Service Create(Evaluation record)
        {
            _db.Evaluations.Add(record);
            foreach (var evaluatedEvaluation in record.EvaluatedEvaluations)
            {
                // Ensure that the Id property is not set explicitly
                _db.Entry(evaluatedEvaluation).Property(e => e.Id).IsModified = false;
            }
            _db.SaveChanges();
            return Success("The evaluation was created successfully");
        }

        public Service Delete(int id)
        {
            var entity = _db.Evaluations.FirstOrDefault(e => e.Id == id);
            if(entity is null) {
                return Error("Evaluation not found");
            }
            _db.Evaluations.Remove(entity);
            _db.SaveChanges();
            return Success("The evaluation was deleted successfully");
        }

        public IQueryable<EvaluationModel> Query()
        {
            return _db.Evaluations
                .Include(e => e.User)
                .Include(e => e.EvaluatedEvaluations)
                .ThenInclude(ee => ee.Evaluated)
                .Select(e => new EvaluationModel() { Record = e });
        }

        public Service Update(Evaluation record)
        {
            var entity = _db.Evaluations.FirstOrDefault(e => e.Id == record.Id);
            if(entity is null)
            {
                return Error("Evaluation not found");
            }

            entity.Title = record.Title?.Trim();
            entity.Score = record.Score;
            entity.Date = record.Date;
            entity.Description = record.Description?.Trim();    
            entity.UserId = record.UserId;

            _db.Evaluations.Update(entity);
            _db.SaveChanges();
            return Success("The evaluation was updated successfully");

        }
    }
}
