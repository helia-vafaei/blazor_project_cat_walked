using System;
using System.Drawing;
using System.Threading.Tasks;
using Blazor.Extensions.Canvas.Canvas2D;

namespace P5.Core.Components
{
    public class SpriteRenderComponent : BaseComponent,IRenderable
    {
        private readonly Transform _transform;

        public SpriteRenderComponent(Sprite sprite, GameObject owner) : base(owner)
        {
            Sprite = sprite ;

            _transform = owner.Components.Get<Transform>() ??
                        throw new AccessViolationException("Transform component is required");
        }

        public async ValueTask Render(Canvas2DContext context)
        {

            await context.DrawImageAsync(Sprite.SpriteSheet, _transform.Position.X, _transform.Position.Y,
                Sprite.Size.Width, Sprite.Size.Height);
              
            


        }

        public Sprite Sprite { get; }
        //var spriteRenderer = Owner.Components.Get<SpriteRenderComponent>();



    }
}