using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;


namespace BLL.Services
{
    public class EvaluatedService : Service, IService<Evaluated, EvaluatedModel>
    {
        public EvaluatedService(Db db) : base(db)
        {

        }

        public Service Create(Evaluated record)
        {
            _db.Evaluateds.Add(record);
            _db.SaveChanges();
            return Success("The evaluated was created successfully");
        }

        public Service Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<EvaluatedModel> Query()
        {
            return  _db.Evaluateds
                .Select(e => new EvaluatedModel() { Record = e });
        }

        public Service Update(Evaluated record)
        {
            throw new NotImplementedException();
        }
    }
}
