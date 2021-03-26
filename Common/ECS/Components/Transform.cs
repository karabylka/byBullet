using Microsoft.Xna.Framework;

namespace Common.ECS.Components
{
    public struct Transform
    {
        public Vector3 Position { get { return WorldMatrix.Translation; } set { WorldMatrix = Matrix.CreateTranslation(value); } }
        public Matrix WorldMatrix { get; private set; }

        public Transform(Matrix _worldMatrix){
            WorldMatrix = _worldMatrix;
        }
    }
}