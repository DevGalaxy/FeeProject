﻿using Core.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FEEWebApp.Models
{
    
    public class AuthResult
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }
}
