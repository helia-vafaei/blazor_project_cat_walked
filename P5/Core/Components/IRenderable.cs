using System.Threading.Tasks;
using Blazor.Extensions.Canvas.Canvas2D;

namespace P5.Core.Components
{
    public interface IRenderable
    {
        ValueTask Render(Canvas2DContext context);
    }
}