using Microsoft.Xna.Framework.Graphics;

namespace Common.ECS.Components
{
    public struct RenderingEffect
    {
        public Effect Effect { get; private set; }

        public RenderingEffect(Effect _effect){
            Effect = _effect;
        }
    }
}