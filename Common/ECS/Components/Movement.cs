using Microsoft.Xna.Framework.Graphics;

namespace Common.ECS.Components
{
    public struct Movement
    {
        public float Speed { get; private set; }

        public Movement(float _speed){
            Speed = _speed;
        }

        public void SetSpeed(float _speed){
            Speed = _speed;
        }
    }
}