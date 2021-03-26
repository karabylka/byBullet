using MonoGame.Extended.Screens;
using MonoGame.Extended.Screens.Transitions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Common.Settings;
using Common.ECS.Components;
using Common.ECS.Systems;
using DefaultEcs.System;

namespace Common.SceneManagement
{
    public class GameScreen1 : ECSScreen
    {
        private new byBullet Game => (byBullet) base.Game;

        public GameScreen1(byBullet game) : base(game) { }

        public override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            base.Update(gameTime);
        }

        public override void SetEntities()
        {
            base.SetEntities();

            var world = GameSettings.Instance.World;
            var graphics = GameSettings.Instance.Graphics;

            var player = world.CreateEntity();
            player.Set(new Transform(Matrix.CreateWorld(Vector3.Zero, Vector3.Forward, Vector3.UnitX)));
            player.Set(new ModelRenderer(Content.Load<Model>("Models/Head")));
            player.Set(new RenderingEffect(Content.Load<Effect>("Effects/TestShader")));
            player.Set(new Controller(true));
            player.Set(new Bindings(true));
            player.Set(new Movement(2));

            var camera = world.CreateEntity();
            camera.Set(new Camera(
                                    Matrix.CreateLookAt(new Vector3(0, 0, 20), Vector3.Zero, Vector3.Up),
                                    Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, graphics.PreferredBackBufferWidth / graphics.PreferredBackBufferWidth, 1, 100)
                                 )
                      );
        }

        public override void SetSystems()
        {
            base.SetSystems();

            var world = GameSettings.Instance.World;
            var mainRunner = GameSettings.Instance.MainRunner;

            UpdateSystems = new SequentialSystem<GameTime>(
                new RenderingSystem(world, mainRunner),
                new MovementSystem(world, mainRunner),
                new InputSystem(world, mainRunner)
            );
        }
    }
}