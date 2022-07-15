using System.Drawing;
using Microsoft.AspNetCore.Components;

namespace P5.Core
{
    public class Sprite {
        public Size Size { get; set; }    
        public string ImageName { get; set; } 
        public ElementReference SpriteSheet { get; set; }
    }
}