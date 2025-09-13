using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.AppMetaData
{
    public static class Router
    {
        public const string root = "Api";
        public const string version = "V1";
        public const string Rule =root+"/"+version+"/";

        public static class StudentRouting
        {
            public const string Prefix = Rule+"Student";
            public const string List = Prefix+"/List";
            public const string create = Prefix+ "/create";
            public const string Delete = Prefix+ "/Delete";
            public const string Update = Prefix+ "/Update";
            public const string UpdateName = Prefix+ "/UpdateName";
            public const string GetById = Prefix+"/{Id}";
            public const string GetByName = Prefix+"/Name"+"/{Name}";
        }
        public static class DepartmentRouting
        {
            public const string Prefix = Rule +"Department";
            public const string List = Prefix +"/List";
            public const string GetById = Prefix +"/{Id}";

        }
        public static class  ApplicationUserRouting
        {
            public const string Prefix = Rule + "User";
            public const string Create = Prefix + "/Create";
            public const string GetAll = Prefix + "/GetAll";
            public const string GetById = Prefix + "/{id}";
            public const string Update = Prefix + "/Update";
            public const string Delete = Prefix + "/Delete";
            public const string ChangePassword = Prefix + "/ChangePassword";


        }

        public static class AuthorizationRouting
        {
            public const string Prefix = Rule + "Authorization";
            public const string Create = Prefix + "/Role/Create";
        }

    }
}
