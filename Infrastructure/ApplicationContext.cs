using Domain.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Infrastructure
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            MapEntities(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        void MapEntities(ModelBuilder builder)
        {
            Assembly assembly = typeof(Entity).Assembly;
            var exportedTypes = assembly.ExportedTypes;

            foreach (Type type in exportedTypes)
            {
                if (IsEntity(type, typeof(Entity)))
                    builder.Entity(type);
            }
        }

        bool IsEntity(Type classe, Type tipo)
        {
            if (classe.BaseType == null) return false;
            if (classe.BaseType.GetInterfaces().Contains(tipo) || classe.BaseType == tipo)
                return true;
            else
                return IsEntity(classe.BaseType, tipo);
        }

    }
}
