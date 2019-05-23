using System;
using NHibernate.Mapping.Attributes;

namespace Jewelry.Business.LoginService.Models
{
    [Serializable]
    [Class(Table = "Users") ]
    public class User
    {
        [Id(0, Name = "Id")]
        [Generator(1, Class = "identity")]
        [System.ComponentModel.DataAnnotations.Key]
        public virtual int Id { get; set; }
        [Property]
        public virtual string Name { get; set; }
        [Property]

        public virtual string Email { get; set; }
        [Property]
        public virtual string Password { get; set; }

    }
}
