using System;

namespace AudioShare.Core.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; set; } = null!;
    }
}
