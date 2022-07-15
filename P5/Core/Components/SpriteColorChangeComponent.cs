using System;
using System.Drawing;
using System.Threading.Tasks;
using Blazor.Extensions.Canvas.Canvas2D;

namespace P5.Core.Components
{
    public class SpriteColorChangeComponent : BaseComponent, IRenderable
    {
        private readonly Transform _transform;

        public SpriteColorChangeComponent(Sprite sprite, GameObject owner) : base(owner)
        {
            Sprite = sprite;

            _transform = owner.Components.Get<Transform>() ??
                        throw new AccessViolationException("Transform component is required");
        }

        // Change the color using SetGlobalCompositeOperationAsync
        public async ValueTask Render(Canvas2DContext context)
        {
            await context.SetFillStyleAsync(Color.Blue.Name);
            await context.FillRectAsync(_transform.Position.X, _transform.Position.Y, Sprite.Size.Width, Sprite.Size.Height);
            await context.SetGlobalCompositeOperationAsync("destination-in");   //destination-in   //destination-atop
            await context.DrawImageAsync(Sprite.SpriteSheet, _transform.Position.X, _transform.Position.Y, Sprite.Size.Width, Sprite.Size.Height);
            
        }

        public Color Color { get; set; }
        public Sprite Sprite { get; set; }


    }
}