using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WallPaperScreenProtector.Scenes
{
    // 3 Scene divide 3/5 width
    public class Scene4 : IScene
    {
        private IScene _scene1;
        private IScene _scene2;
        private IScene _scene3;


        public Scene4(ContentManager content, Rectangle windowSize)
        {
            var width = (windowSize.Width / 5) * 3;
            var smallWidth = windowSize.Width - width;
            var smallHeight = windowSize.Height / 2;

            _scene1 = new Scene3(content, new Rectangle(0, 0, width, windowSize.Height));
            _scene2 = new Scene3(content, new Rectangle(width, 0, smallWidth, smallHeight));
            _scene3 = new Scene3(content, new Rectangle(width, smallHeight, smallWidth, smallHeight));
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _scene1.Draw(gameTime, spriteBatch);
            _scene2.Draw(gameTime, spriteBatch);
            _scene3.Draw(gameTime, spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            _scene1.Update(gameTime);
            _scene2.Update(gameTime);
            _scene3.Update(gameTime);
        }
    }
}
