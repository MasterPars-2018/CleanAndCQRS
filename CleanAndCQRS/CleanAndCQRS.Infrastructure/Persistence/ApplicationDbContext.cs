﻿using CleanAndCQRS.Domain.Domains.Todos;
using Microsoft.EntityFrameworkCore;

namespace CleanAndCQRS.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
 
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    public DbSet<ToDoList> ToDoLists { get; set; }



}
