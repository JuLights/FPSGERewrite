﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPSGERewrite.Application.Dtos.Request
{
    public class CreateMouseRequest
    {
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public string ProductDescription { get; set; }
        public string ProductCondition { get; set; }
        public string AdditionalKeys { get; set; }
        public string SensorType { get; set; }
        public bool RGB { get; set; }
        [AllowNull]
        public IFormFile FormFile { get; set; }
    }
}
