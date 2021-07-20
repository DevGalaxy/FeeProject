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
                $"Permissions.{module}.Read",
                $"Permissions.{module}.Create",
                $"Permissions.{module}.Update",
                $"Permissions.{module}.Delete"
            };
        }
    }
}
