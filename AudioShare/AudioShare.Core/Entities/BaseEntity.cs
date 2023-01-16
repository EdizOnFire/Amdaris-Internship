using System.ComponentModel.DataAnnotations;

namespace AudioShare.Core.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
