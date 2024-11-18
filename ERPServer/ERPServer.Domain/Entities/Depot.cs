using ERPServer.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPServer.Domain.Entities
{
    public sealed class Depot :Entity
    {
        public string Name { get; set; }=string.Empty;
        public string City { get; set; }=string.Empty ;
        public string Town { get; set; } = string.Empty;
        public string Address { get; set; }= string.Empty ;
    }
}
