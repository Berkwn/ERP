using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPServer.Domain.Abstractions
{
    public class Entity
    {
        public Entity()
        {
               Id = Guid.NewGuid();
               CreatedDate= DateTime.Now;
        }
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
