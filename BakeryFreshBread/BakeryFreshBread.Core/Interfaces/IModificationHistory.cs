using System;
using System.Collections.Generic;
using System.Text;

namespace BakeryFreshBread.Core.Interfaces
{
    public interface IModificationHistory
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
