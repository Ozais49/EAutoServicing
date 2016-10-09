using EAutoServicing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EAutoServicing.Utilities
{



    public static class Utility
    {
        public static EAutoServicing.Models.AppUser Currentuser
        {
            get
            {
                if(HttpContext.Current.Session["EAutoServicingUser"]==null)
                {
                    using (EAutoServicingContext db=new EAutoServicingContext())
                    {
                        var curUser = db.AppUsers.Where(x => x.UserName == HttpContext.Current.User.Identity.Name).FirstOrDefault();
                        HttpContext.Current.Session["EAutoServicingUser"] = curUser;

                    }
                }
             
                return (AppUser)HttpContext.Current.Session["EAutoServicingUser"];
            }
        }
    }
   
    public enum DataStatus
    {
        Active = 1,
        Deleted = 2
    }
}