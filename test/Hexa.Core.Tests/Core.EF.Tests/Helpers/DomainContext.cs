﻿//----------------------------------------------------------------------------------------------
// <copyright file="DomainContext.cs" company="HexaSystems Inc">
// Copyright (c) HexaSystems Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------
namespace Hexa.Core.Orm.Tests.EF
{
    using System.Reflection;
    using Hexa.Core.Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.EntityFrameworkCore.Infrastructure;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class DomainContext : AuditableContext
    {
        public DomainContext(DbContextOptions<DomainContext> options, Assembly[] assemblies)
            : base(options, assemblies)
        {
        }
    }

    public class DomainContextFactory : IDesignTimeDbContextFactory<DomainContext>
    {
        public DomainContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DomainContext>();
            optionsBuilder.UseInMemoryDatabase("hexa.core");

            var context = new DomainContext(optionsBuilder.Options, new Assembly[] { typeof(DomainContext).GetTypeInfo().Assembly });
            context.Database.EnsureCreated();

            return context;
        }
    }
}