using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScherp_Game
{
    public abstract class Model
    {

        public List<View> views { get; set; }

        public Model()
        {
            views = new List<View>();
        }

        public abstract void Update();

        public void AddView(View v)
        {
            views.Add(v);
        }

        public void UpdateViews(long dt)
        {
            foreach(View v in views)
            {
                v.Update(this, dt);
            }
        }

        public void RemoveView(View v)
        {
            views.Remove(v);
        }

    }
}
