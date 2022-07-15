using System;
using System.Numerics;
using System.Threading.Tasks;
using P5.Core;
using P5.Core.Components;

namespace P5.Game
{
    public class CatBrain : BaseComponent
    {
        private const float DefaultSpeed = 0.25f;
        private float _speed = DefaultSpeed;


        public CatBrain(GameObject owner) : base(owner)
        {

        }

        public override async ValueTask Update(GameContext game)
        {
            UpdatePosition(game);
        }

        public void UpdatePosition(GameContext game)
        {
            var transform = this.Owner.Components.Get<Transform>();
            var spriteRenderer = this.Owner.Components.Get<SpriteRenderComponent>();

            var dx = transform.Direction.X;
            
            if (transform.Position.X + spriteRenderer.Sprite.Size.Width >= game.Display.Size.Width || transform.Position.X < 0)
            {    
                dx = -transform.Direction.X;

                
            }    

            var dy = transform.Direction.Y;

            transform.Direction = new Vector2(dx, dy);

            transform.Position += transform.Direction * _speed * game.GameTime.ElapsedTime;
        }
        // public void StateHasChanged()
        // {
    
        // }
    }
}