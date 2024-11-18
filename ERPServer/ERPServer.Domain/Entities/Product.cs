﻿using ERPServer.Domain.Abstractions;
using ERPServer.Domain.Enums;

namespace ERPServer.Domain.Entities
{
    public sealed class Product :Entity
    {
        public string Name { get; set; } = string.Empty;
        public ProductTypeEnum type { get; set; } = ProductTypeEnum.product;
    }
}
