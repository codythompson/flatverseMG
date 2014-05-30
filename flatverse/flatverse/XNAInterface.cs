using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace flatverse
{
    public interface XNAInterface
    {
        void initialize(Game1 xnaGame);
        void loadContent(ContentManager contentManager);
        //void unloadContent();
        void update(GameTime gameTime);
        void draw(GameTime gameTime);
    }
}