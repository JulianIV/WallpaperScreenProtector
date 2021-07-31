using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WallPaperScreenProtector.Scenes
{
    // FullScreen slide-in left
    public class Scene1 : IScene
    {
        private Texture2D _image;
        private Rectangle _rect;
        private int _timeSinceLastFrame = 0;
        private float _lerpDuration = Consts.QuarterTimePerScene;
        private float _startValue = 0;
        private float _valueToLerp;
        private float _timeElapsed = 0;
        private int _endValue;

        public Scene1(ContentManager content, Rectangle windowSize)
        {
            _image = content.Load<Texture2D>(Consts.GetRandomWallpaper());
            _rect = new Rectangle(-windowSize.Width, 0, windowSize.Width, windowSize.Height);
            _endValue = _rect.Width;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_image, _rect, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            if (_timeElapsed < _lerpDuration)
            {
                _valueToLerp = MathHelper.SmoothStep(_startValue, _endValue, _timeElapsed / _lerpDuration);
                _timeElapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }
            else
            {
                _valueToLerp = _endValue;

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

            _rect.X = -_rect.Width + (int)_valueToLerp;
        }
    }
}
