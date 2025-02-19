namespace Casemanagement.Migrations
{
    using Casemanagement.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Casemanagement.Models.CaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Casemanagement.Models.CaseContext context)
        {
            context.Adalot.AddRange(new List<Adalot> {
                new Adalot { Name="High Court",Description="asdfasdfasdfas"}
            }               
            );
            context.SaveChanges();
           
        }
    }
}
