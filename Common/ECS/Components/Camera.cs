using Microsoft.Xna.Framework;

namespace Common.ECS.Components
{
    public struct Camera
    {
        public Matrix ViewMatrix { get; private set; }
        public Matrix ProjectionMatrix { get; private set; }

        public Camera(Matrix _viewMatrix, Matrix _projectionMatrix){
            ViewMatrix = _viewMatrix;
            ProjectionMatrix = _projectionMatrix;
        }
    }
}