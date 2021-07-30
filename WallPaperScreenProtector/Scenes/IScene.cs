using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WallPaperScreenProtector.Scenes
{
    public interface IScene
    {
        void Update(GameTime gameTime);
        void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}
