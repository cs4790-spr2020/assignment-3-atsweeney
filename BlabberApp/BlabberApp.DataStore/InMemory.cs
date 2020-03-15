﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using BlabberApp.Domain.Entities;
using BlabberApp.Domain.Interfaces;

namespace BlabberApp.DataStore
{
    public class InMemory<T> : iRepository<T> where T : Blab
    {
        //Attributes
        private ApplicationContext Context;
        private DbSet<T> _entities;


        //Constructor
        public InMemory(ApplicationContext context)
        {
            this.Context = context;
            this._entities = context.Set<T>();
        }


        //Methods
        public void Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity is null");
            }

            this._entities.Add(entity);
            this.Context.SaveChanges();
        }

        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity is null");
            }

            this._entities.Remove(entity);
            this.Context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity is null");
            }

            this.Context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return this._entities.AsEnumerable();
        }

        public T GetBySysId(string sysId)
        {
            if (sysId.Equals(""))
            {
                throw new ArgumentNullException("sysId is null");
            }

            return this._entities.SingleOrDefault(s => s.getSysId() == sysId);
        }

        public T GetByUserId(string userId)
        {
            if (userId.Equals(""))
            {
                throw new ArgumentNullException("userId is null");
            }

            return this._entities.SingleOrDefault(s => s.UserID == userId);
        }
    }
}