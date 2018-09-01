namespace Nop.Data.Migrations
{
    using Nop.Domain.Users;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Nop.Data.NopObjectContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Nop.Data.NopObjectContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var userRoleSet = context.Set<UserRole>();

            if (!userRoleSet.Any())
            {
                userRoleSet.Add(new UserRole {
                    Active = true,
                    IsSystemRole = true,
                    Name = SystemUserRoleNames.Administrators,
                    SystemName = SystemUserRoleNames.Administrators,
                    EnablePasswordLifetime = true
                });

                userRoleSet.Add(new UserRole
                {
                    Active = true,
                    IsSystemRole = true,
                    Name = SystemUserRoleNames.ForumModerators,
                    SystemName = SystemUserRoleNames.ForumModerators,
                    EnablePasswordLifetime = true
                });

                userRoleSet.Add(new UserRole
                {
                    Active = true,
                    IsSystemRole = true,
                    Name = SystemUserRoleNames.Registered,
                    SystemName = SystemUserRoleNames.Registered,
                    EnablePasswordLifetime = true
                });

                userRoleSet.Add(new UserRole
                {
                    Active = true,
                    IsSystemRole = true,
                    Name = SystemUserRoleNames.Vendors,
                    SystemName = SystemUserRoleNames.Vendors,
                    EnablePasswordLifetime = true
                });

                userRoleSet.Add(new UserRole
                {
                    Active = true,
                    IsSystemRole = true,
                    Name = SystemUserRoleNames.Guests,
                    SystemName = SystemUserRoleNames.Guests,
                    EnablePasswordLifetime = false
                });
            }

        }
    }
}
