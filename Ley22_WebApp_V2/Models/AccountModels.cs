using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AccountModels
/// </summary>
namespace Ley22_WebApp_V2.Models
{
    public class UserViewModel
    {
        public string Email { get; set; }
        public string Role { get; set; }
    }

    public class UserProgramModel
    {
        public string Email { get; set; }
        public string Program { get; set; }
    }
}