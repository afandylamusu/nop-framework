using Nop.Domain.Users;
using System.Data.Entity;
using System.Linq;

namespace Nop.Data.Initializers
{
    public class DataMaster
    {
        public static void Initial(DbContext context)
        {
            var userRoleSet = context.Set<UserRole>();

            if (!userRoleSet.Any())
            {
                userRoleSet.Add(new UserRole
                {
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
