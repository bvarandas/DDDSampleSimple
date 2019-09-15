﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDDSample.Domain.Interfaces;
using DDDSample.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DDDSample.Infra.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DDDSampleContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(DDDSampleContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual TEntity GetById(int id)
        {
            return DbSet.Find(id);
        }

        public virtual TEntity GetByIdInt(int id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Remove(int id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
                
        }


    }

}
