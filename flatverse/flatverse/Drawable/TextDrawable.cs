using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace flatverse
{
    public class TextDrawable : Drawable
    {
        public SpriteFont spriteFont;
        public string text;

        public TextDrawable(SpriteFont spriteFont, string text, float depth)
            : base(depth)
        {
            this.spriteFont = spriteFont;
            this.text = text;
        }

        public override void update()
        {
            //base
        }

        public override void draw(SpriteBatch spriteBatch, Vector2 pos, Vector2 scale, Color color, float lerpVal)
        {
            pos = getOffsetPos(pos);
            scale = getMultipliedScale(scale);
            color = getLerpedColor(color, lerpVal);

            spriteBatch.DrawString(spriteFont, text, pos, color, 0, Vector2.Zero, scale, SpriteEffects.None, depth);
        }

        public override Drawable clone()
        {
            return new TextDrawable(spriteFont, text, depth);
        }
    }
}