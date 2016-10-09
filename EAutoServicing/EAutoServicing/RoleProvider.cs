using EAutoServicing.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace EAutoServicing
{
    public class EAutoServicingRoleProvider : RoleProvider
    {
        public override bool IsUserInRole(string username, string roleName)
        {
            using (EAutoServicingContext db = new EAutoServicingContext())
            {
                var user = db.AppUsers.FirstOrDefault(x => x.UserName == username);
                if (user == null)
                    return false;

                return user.UserRole.Name == roleName;
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        private string _applicationName;
        public override string ApplicationName
        {
            get
            {
                return "EAutoServicing";
            }
            set
            {
                _applicationName = "EAutoServicing";
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            using (EAutoServicingContext db = new EAutoServicingContext())
            {
                return db.UserRoles.Select(x => x.Name).ToArray();
            }
        }

        public override string[] GetRolesForUser(string username)
        {
            List<string> roles = new List<string>();
            using (EAutoServicingContext context = new EAutoServicingContext())
            {
                var user = context.AppUsers.FirstOrDefault(x => x.UserName == username);
                roles.Add(user.UserRole.Name);
            }

            return roles.ToArray();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            List<string> users = new List<string>();
            using (EAutoServicingContext context = new EAutoServicingContext())
            {
                var Users = context.AppUsers.Where(x => x.UserRole.Name == roleName);
                users = (from c in Users select c.UserName).ToList();
            }

            return users.ToArray();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            bool isExists = false;
            using (EAutoServicingContext context = new EAutoServicingContext())
            {
                isExists = context.UserRoles.Any(x => x.Name == roleName);
            }

            return isExists;
        }
    }
}