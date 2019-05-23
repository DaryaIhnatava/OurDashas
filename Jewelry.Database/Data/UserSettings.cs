using System;
using NHibernate.Mapping.Attributes;

namespace Jewelry.Database.Data
{
    public enum Theme
    {
       black=1, 
       white=2
    }

    [Class(Table = "UserPreferences")]
    public class UserSettings
    {
        [Id(0, Name = "Id")]
        [Generator(1, Class = "identity")]
        [System.ComponentModel.DataAnnotations.Key]
        public virtual  int Id { get; set; }
        [Property]
        public virtual  string TimeZone { get; set; }
        [Property]
        public virtual  Theme Theme { get; set; }
        [Property]
        public virtual int UserId { get; set; }
        [Property]
        public virtual string Language{ get; set; }
    }
}
