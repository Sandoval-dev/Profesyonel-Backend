using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Entities.Concrete
{
    public class UserRole:IEntity
    {
        public int Id { get; set; }
        public string RoleId { get; set; }
        public string UserId { get; set; }
    }
}
