using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using WallPaperScreenProtector.Scenes;

namespace WallPaperScreenProtector
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Rectangle _windowSize;
        private IScene _currentScene;
        private IScene _nextScene;
        private int _timeSinceLastFrame = 0;

        private Random _random = new Random();
        private List<Type> _scenes = new List<Type>
        {
            typeof(Scene1),
            typeof(Scene2),
        };
        
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.ToggleFullScreen();
            _windowSize = Window.ClientBounds;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // Add initialization logic here
            _currentScene = new Scene1(Content, _windowSize);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            _currentScene.Update(gameTime);

            if (_nextScene == null)
                _nextScene = GetNextScene(Content, _windowSize);

            if (_timeSinceLastFrame > Consts.TimePerScene)
                _nextScene.Update(gameTime);

            _timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (_timeSinceLastFrame > Consts.TimePerScene + Consts.QuarterTimePerScene)
            {
                _currentScene = _nextScene;
                _nextScene = null;
                _timeSinceLastFrame = 0;
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _currentScene.Draw(gameTime, _spriteBatch);

            if (_timeSinceLastFrame > Consts.TimePerScene)
                _nextScene.Draw(gameTime, _spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        private IScene GetNextScene(ContentManager content, Rectangle windowSize)
        {
            var sceneToMake = _scenes.Skip(_random.Next(0, _scenes.Count)).First();

            var scene = Activator.CreateInstance(sceneToMake, new object[] { content, windowSize });

            return scene as IScene;
        }
    }
}
