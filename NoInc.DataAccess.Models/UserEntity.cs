using System;
using System.Collections.Generic;

#nullable disable

namespace NoInc.DataAccess.Models
{
    public partial class UserEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
