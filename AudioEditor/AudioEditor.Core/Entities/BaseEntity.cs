using System.ComponentModel.DataAnnotations;

namespace AudioEditor.Core.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime LastModified { get; set; }
    }
}
