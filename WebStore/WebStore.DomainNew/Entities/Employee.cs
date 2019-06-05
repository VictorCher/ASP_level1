using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebStore.DomainNew.Entities.Base.Interfaces;
using WebStore.DomainNew.Entities.Base;

namespace WebStore.DomainNew.Entities
{
    /// <summary>
    /// Сущность сотрудник
    /// </summary>
    [Table("Employees")]
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        
        public string SurName { get; set; }

        public string Patronymic { get; set; }
        
        public int Age { get; set; }
        
        public string Position { get; set; }
    }
}
