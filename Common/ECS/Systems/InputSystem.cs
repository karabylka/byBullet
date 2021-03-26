using System.Linq;
using DefaultEcs;
using DefaultEcs.System;
using DefaultEcs.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Common.ECS.Components;
using Common.Helpers.System;
using MonoGame.Extended.Input;

namespace Common.ECS.Systems
{
    [With(typeof(Controller))]
    [With(typeof(Bindings))]
    public partial class InputSystem : AEntitySetSystem<GameTime>
    {
        private IParallelRunner runner;
        private World world;
        
        public InputSystem(World _world, IParallelRunner _runner) : base(_world, CreateEntityContainer, null, 0){
            world = _world;
            runner = _runner;
        }

        [Update]
        private void Update(ref Controller _controller, ref Bindings _bindings){
            ControlButtonPressing(ref _controller, ref _bindings);
        }

        void ControlButtonPressing(ref Controller _controller, ref Bindings _bindings){
            foreach (var item in _controller.Flags.ToList())
            {
                if(WaldemInput.IsButtonDown((WaldemButtons)_bindings.Pairs[item.Key])){
                    if(!item.Value) _controller.SetFlag(item.Key, true);
                }
                
                if(WaldemInput.IsButtonUp((WaldemButtons)_bindings.Pairs[item.Key])){
                    if(item.Value) _controller.SetFlag(item.Key, false);
                }
            }
        }
    }
}