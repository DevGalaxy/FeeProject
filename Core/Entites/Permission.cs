using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entites
{
    public class Permission
    {
        public int Id { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string DispalyName { get; set; }
    }
}
