﻿using FPSGERewrite.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FPSGERewrite.Application.Dtos.Request
{
    public class CreateKeyboardRequest
    {
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public string ProductDescription { get; set; }
        public string ProductCondition { get; set; }
        public string RGB { get; set; }
        public string CableLength { get; set; }
        public string SwitchType { get; set; } //mechanical, membrane, .. etc.
        [AllowNull]
        public IFormFile FormFile { get; set; }

    }
}
