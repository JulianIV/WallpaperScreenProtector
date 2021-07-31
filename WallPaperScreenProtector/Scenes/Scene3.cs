using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace WallPaperScreenProtector.Scenes
{
    // Fullscreen fade-in
    class Scene3 : IScene
    {
        private Texture2D _image;
        private Rectangle _rect;
        private int _timeSinceLastFrame = 0;
        private float _lerpDuration = Consts.QuarterTimePerScene;
        private float _startValue = 0;
        private float _valueToLerp;
        private float _timeElapsed = 0;
        private float _endValue = 1f;

        public Scene3(ContentManager content, Rectangle windowSize)
        {
            _image = content.Load<Texture2D>(Consts.GetRandomWallpaper());
            _rect = new Rectangle(windowSize.X, windowSize.Y, windowSize.Width, windowSize.Height);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_image, _rect, new Color(255, 255, 255, _valueToLerp));
        }

        public void Update(GameTime gameTime)
        {
            if (_timeElapsed < _lerpDuration)
            {
                _valueToLerp = MathHelper.Lerp(_startValue, _endValue, _timeElapsed / _lerpDuration);
                Debug.WriteLine(_valueToLerp);
                _timeElapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }
            else
            {
                _timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
                if (_timeSinceLastFrame > Consts.MillisecondsPerFrame)
                {
                    _timeSinceLastFrame -= Consts.MillisecondsPerFrame;
                    _rect.X -= 1;
                    _rect.Y -= 1;
                    _rect.Width += 2;
                    _rect.Height += 2;
                    return;
                }
                return;
            }
        }
    }
}
