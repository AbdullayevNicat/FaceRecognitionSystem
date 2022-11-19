﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolFaceRecognition.Core.Entities;
using SchoolFaceRecognition.Core.Entities.Base;
using SchoolFaceRecognition.DAL.Configurations;
using System.Reflection;

namespace SchoolFaceRecognition.DAL.AppDbContext
{
    public class SchoolDbContext : IdentityDbContext<AppUser,IdentityRole,string>
    {
        public SchoolDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

      
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
