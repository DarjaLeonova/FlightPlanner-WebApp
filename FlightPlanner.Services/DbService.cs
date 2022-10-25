﻿using FlightPlanner.Core.Models;
using FlightPlanner.Core.Services;
using FlightPlanner_WebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace FlightPlanner.Services
{
    public class DbService : IDbService
    {
        protected FlightPlannerDbContext _context;

        public DbService(FlightPlannerDbContext context)
        {
            _context = context;
        }

        public ServiceResult Create<T>(T entity) where T : Entity
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();

            return new ServiceResult(true).SetEntity(entity);
        }

        public ServiceResult Delete<T>(T entity) where T : Entity
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();

            return new ServiceResult(true);
        }

        public ServiceResult Update<T>(T entity) where T : Entity
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();

            return new ServiceResult(true).SetEntity(entity);
        }

        public List<T> GetAll<T>() where T : Entity
        {
            return _context.Set<T>().ToList();
        }

        public T GetById<T>(int id) where T : Entity
        {
            return _context.Set<T>().SingleOrDefault(e => e.Id == id);
        }

        public IQueryable<T> Query<T>() where T : Entity
        {
            return _context.Set<T>().AsQueryable();
        }

        public void DeleteAll<T>() where T : Entity
        {
            _context.Set<T>().RemoveRange();
        }
    }
}