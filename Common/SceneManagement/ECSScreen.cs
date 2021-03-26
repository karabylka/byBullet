using MonoGame.Extended.Screens;
using Microsoft.Xna.Framework;
using DefaultEcs.System;

namespace Common.SceneManagement
{
    public class ECSScreen : GameScreen, ISystemable
    {
        private new byBullet Game => (byBullet) base.Game;
        public ISystem<GameTime> UpdateSystems { get; set; }
        public ISystem<GameTime> DrawSystems { get; set; }

        public ECSScreen(byBullet game) : base(game) { }

        public override void LoadContent()
        {
            base.LoadContent();
            SetEntities();
            SetSystems();
        }

        public override void Update(GameTime gameTime) {
            UpdateSystems.Update(gameTime);
        }

        public override void Draw(GameTime gameTime) {
            DrawSystems.Update(gameTime);
        }

        public virtual void SetEntities() {}

        public virtual void SetSystems() {}
    }
}