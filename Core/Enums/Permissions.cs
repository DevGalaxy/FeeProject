using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Enums
{
    public static class Permissions
    {
        public static List<string> GeneratePermissions(string module)
        {
            return new List<string>()
            {
                $"Permissions.{module}.Get",
                $"Permissions.{module}.Post",
                $"Permissions.{module}.Put",
                $"Permissions.{module}.Delete"
            };
        }
        public static List<string> GenerateAllPermissions()
        {
            var allPermissions = new List<string>();
            var modules = Enum.GetValues(typeof(Modules));
            foreach (var item in modules)
            {
                allPermissions.AddRange(GeneratePermissions(item.ToString()));
            }
            return allPermissions;
        }
    }
}
