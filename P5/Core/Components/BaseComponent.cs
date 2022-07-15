using System;
using System.Threading.Tasks;

namespace P5.Core.Components
{
    public abstract class BaseComponent : IComponent
    {
        protected BaseComponent(GameObject owner)
        {
            this.Owner = owner ;
            this.Owner.Components?.Add(this);
        }

        public virtual async ValueTask Update(GameContext game)
        {}

        public GameObject Owner { get;}
    }
}