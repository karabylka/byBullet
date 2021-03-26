using DefaultEcs;
using DefaultEcs.System;
using DefaultEcs.Threading;
using Microsoft.Xna.Framework;
using Common.ECS.Components;

namespace Common.ECS.Systems
{
    [With(typeof(Transform))]
    [With(typeof(Controller))]
    [With(typeof(Movement))]
    public partial class MovementSystem : AEntitySetSystem<GameTime>
    {
        private IParallelRunner runner;
        private World world;
        
        public MovementSystem(World _world, IParallelRunner _runner) : base(_world, CreateEntityContainer, null, 0){
            world = _world;
            runner = _runner;
        }

        [Update]
        private void Update(ref Transform _transform, ref Controller _controller){
            if(_controller.Flags["MoveLeft"]){
                _transform.Position -= Vector3.UnitX/10;
            }
            if(_controller.Flags["MoveRight"]){
                _transform.Position += Vector3.UnitX/10;
            }
        }
    }
}