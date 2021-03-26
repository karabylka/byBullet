using Microsoft.Xna.Framework.Graphics;

namespace Common.ECS.Components
{
    public struct ModelRenderer
    {
        public Model Model { get; private set; }

        public ModelRenderer(Model _model){
            Model = _model;
        }
    }
}