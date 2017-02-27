using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScherp_Game
{
    public abstract class View
    {

        public abstract void Update(Model m, long dt);

    }
}
