using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace flatverse
{
    public class FVImage
    {
        public Texture2D texture;
        public Rectangle? sourceRect;

        public FVImage(Texture2D texture, Rectangle? sourceRect)
        {
            this.texture = texture;
            this.sourceRect = sourceRect;
        }

        public FVImage(Texture2D texture, int srcX, int srcY, int srcWidth, int srcHeight)
            : this(texture, new Rectangle(srcX, srcY, srcWidth, srcHeight))
        {}
    }
}