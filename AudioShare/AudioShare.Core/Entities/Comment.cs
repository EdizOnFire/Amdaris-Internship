using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioShare.Core.Entities
{
    public class Comment : BaseEntity
    {
        public string Owner { get; set; } = null!;
        public string Content { get; set; } = null!;
        public int AudioFileId { get; set; }
    }
}
