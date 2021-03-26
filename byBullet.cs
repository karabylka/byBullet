using System;
using Microsoft.Xna.Framework;
using DefaultEcs;
using DefaultEcs.Threading;
using Common.Settings;
using Common.SceneManagement;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Screens.Transitions;

namespace Common
{
    public class byBullet : Game
    {
        private GraphicsDeviceManager Graphics;
        private ScreenManager ScreenManager;

        public byBullet()
        {
            SetBasicConfiguration();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            InitializeScreenManager();
            InitizalizeGameSettings();
            StartGame();
        }

        void SetBasicConfiguration(){
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        void InitializeScreenManager(){
            ScreenManager = new ScreenManager();
            Components.Add(ScreenManager);
        }

        void InitizalizeGameSettings(){
            //Graphics settings
            Graphics.PreferredBackBufferWidth = 1920;
            Graphics.PreferredBackBufferHeight = 1080;
            Graphics.ApplyChanges();
            
            //initialize GameSetting class
            var settings = GameSettings.Instance;
            
            settings.GraphicsDevice = GraphicsDevice;
            settings.Graphics = Graphics;
            settings.ContentManager = Content;
            settings.Game = this;
            settings.World = new World();
            settings.MainRunner = new DefaultParallelRunner(Environment.ProcessorCount);
            settings.ScreenManager = ScreenManager;
        }

        void StartGame(){
            ScreenManager.LoadScreen(new MenuScreen(this), new FadeTransition(GraphicsDevice, Color.Black));
        }
    }
}
