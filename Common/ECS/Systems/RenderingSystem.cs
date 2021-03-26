using DefaultEcs;
using DefaultEcs.System;
using DefaultEcs.Threading;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Common.ECS.Components;

namespace Common.ECS.Systems
{
    public class RenderingSystem : AComponentSystem<GameTime, Camera>
    {
        private IParallelRunner Runner;
        
        public RenderingSystem(World _world, IParallelRunner _runner) : base(_world){
            Runner = _runner;
        }

        protected override void PreUpdate(GameTime state)
        {
            base.PreUpdate(state);
        }

        protected override void Update(GameTime _gameTime, ref Camera _camera)
        {
            var entitiesWithEffect = World.GetEntities().With<Transform>().With<ModelRenderer>().With<RenderingEffect>().AsEnumerable();

            foreach (var entFX in entitiesWithEffect)
            {
                var model = entFX.Get<ModelRenderer>().Model;
                var effect = entFX.Get<RenderingEffect>().Effect;
                var worldMatrix = entFX.Get<Transform>().WorldMatrix;
                
                foreach (ModelMesh mesh in model.Meshes)
                {
                    foreach (ModelMeshPart part in mesh.MeshParts)
                    {
                        part.Effect = effect;
                        effect.Parameters["WorldMatrix"].SetValue(worldMatrix);
                        effect.Parameters["ViewMatrix"].SetValue(_camera.ViewMatrix);
                        effect.Parameters["ProjectionMatrix"].SetValue(_camera.ProjectionMatrix);
                        effect.Parameters["DiffuseLightDirection"].SetValue(new Vector3(1, 0, 1));
                        Matrix worldInverseTransposeMatrix = Matrix.Transpose(Matrix.Invert(worldMatrix));
                        effect.Parameters["WorldInverseTransposeMatrix"].SetValue(worldInverseTransposeMatrix);
                    }
                    mesh.Draw();
                }
            }
            
            
            var entitiesWithoutEffect = World.GetEntities().With<Transform>().With<ModelRenderer>().Without<RenderingEffect>().AsEnumerable();

            foreach (var ent in entitiesWithoutEffect)
            {
                var model = ent.Get<ModelRenderer>().Model;
                var worldMatrix = ent.Get<Transform>().WorldMatrix;
                
                foreach (var mesh in model.Meshes)
                {
                    foreach (BasicEffect effect in mesh.Effects)
                    {
                        effect.EnableDefaultLighting();
                        effect.View = _camera.ViewMatrix;
                        effect.Projection = _camera.ProjectionMatrix;
                        effect.World = worldMatrix;
                    }
                    mesh.Draw();
                }
            }
        }

        protected override void PostUpdate(GameTime state)
        {
            base.PostUpdate(state);
        }
    }
}