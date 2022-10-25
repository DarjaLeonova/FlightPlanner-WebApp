using System.Collections.Generic;
using System.Linq;
using FlightPlanner.Core.Models;

namespace FlightPlanner.Core.Services
{
    public interface IDbService
    {
        public ServiceResult Create<T>(T entity) where T : Entity;

        public ServiceResult Delete<T>(T entity) where T : Entity;

        public ServiceResult Update<T>(T entity) where T : Entity;

        public List<T> GetAll<T>() where T : Entity;

        public T GetById<T>(int id) where T : Entity;

        public IQueryable<T> Query<T>() where T : Entity;

        public void DeleteAll<T>() where T : Entity;
    }
}
