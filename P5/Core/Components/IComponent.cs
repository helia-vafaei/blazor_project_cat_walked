using System.Threading.Tasks;

namespace P5.Core.Components
{
    public interface IComponent
    {
        ValueTask Update(GameContext game);

        public GameObject Owner { get; }
    }
}