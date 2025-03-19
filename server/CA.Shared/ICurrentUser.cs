using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Shared
{
    public interface ICurrentUser
    {
        public Guid? Id { get; }
    }
}
