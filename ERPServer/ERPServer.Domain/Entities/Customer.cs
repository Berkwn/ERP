using ERPServer.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPServer.Domain.Entities
{
    public sealed class Customer :Entity
    {
        public string Name { get; set; } = default!;
        public string taxDepartment { get; set; } = default!;
        public string taxNumber { get; set; } = default!;
        public string city { get; set; } = default!;
        public string district { get; set; } = default!;
        public string Address { get; set; } = default!;
    }
}
