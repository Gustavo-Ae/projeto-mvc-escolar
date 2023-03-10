
using EM.Domain.Interface;

namespace EM.Repository
{
    public abstract class RepositorioAbstrato<T> where T : IEntidade
    {

        public abstract void Add(T aluno);

        public abstract void Remove(T aluno);

        public abstract void Update(T aluno);

        public abstract IEnumerable<T> GetAll();

        //public Get(Express)
        //{

        //}
    }
}
