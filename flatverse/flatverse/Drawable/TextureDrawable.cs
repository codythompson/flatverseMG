using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace flatverse
{
    public class TextureDrawable : Drawable
    {
        public FVImage image;

        public TextureDrawable(FVImage image, float depth)
            : base(depth)
        {
            this.image = image;
        }

        public override void update()
        {}

        public override void draw(SpriteBatch spriteBatch, Vector2 pos, Vector2 scale, Color color, float lerpVal)
        {
            pos = getOffsetPos(pos);
            scale = getMultipliedScale(scale);
            color = getLerpedColor(color, lerpVal);

            spriteBatch.Draw(image.texture, pos, image.sourceRect, color, 0, Vector2.Zero, scale, SpriteEffects.None, depth);
        }

        public override Drawable clone()
        {
            TextureDrawable newInst = new TextureDrawable(image, depth);
            newInst.scale = scale;
            newInst.color = color;
            return newInst;
        }
    }
}