using System.Drawing;
using System.Numerics;
using System.Threading.Tasks;
using P5.Core;
using P5.Core.Components;
using Microsoft.AspNetCore.Components;
using Blazor.Extensions.Canvas.Canvas2D;
using Blazor.Extensions;

namespace P5.Game
{
    public class CatWalkGame : GameContext
    {
        private Canvas2DContext _context;
        private GameObject _cat;

        private const int _catWidth = 200;
        private const int _catHeight = 200;

        private CatWalkGame(){}

        public static async ValueTask<CatWalkGame> Create(BECanvasComponent canvas, ElementReference spritesheet)
        {
            var cat = new GameObject();
            cat.Components.Add(new Transform(cat)
            {
                Position = Vector2.Zero,
                Direction = new Vector2(1,0),
                Size = new Size(_catWidth, _catHeight),
            });

            var sprite = new Sprite()
            {
                Size = new Size(_catWidth, _catHeight),
                SpriteSheet = spritesheet
            };
            cat.Components.Add(new SpriteRenderComponent(sprite, cat));
            cat.Components.Add(new CatBrain(cat));
            cat.Components.Add(new SpriteColorChangeComponent(sprite, cat));

            var game = new CatWalkGame { _context = await canvas.CreateCanvas2DAsync(), _cat = cat };


            return game;
        }

        protected override async ValueTask Update()
        {
            await _cat.Update(this);
        }

        // you might have to reset sth back here
        protected override async ValueTask Render()
        {
            await _context.ClearRectAsync(0, 0, this.Display.Size.Width, this.Display.Size.Height);

            foreach (var component in _cat.Components)
                if (component is IRenderable renderable)
                {
                    await renderable.Render(_context);
                }
            await _context.SetGlobalCompositeOperationAsync("source-over");

        }
    }
}