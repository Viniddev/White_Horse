using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace White_Horse_Inc_Core.Models.Base
{
    public class BaseEntity
    {
        public long Id { get; init; }
        public DateTime CreationDate { get; init; } = DateTime.Now;
        public DateTime? UpdateDate { get; private set; }
        public bool IsActive { get; private set; } = true;

        public void UpdateValues()
        {
            UpdateDate = DateTime.Now;
        }

        public void DisableEntity()
        {
            UpdateDate = DateTime.Now;
            IsActive = false;
        }
    }
}
