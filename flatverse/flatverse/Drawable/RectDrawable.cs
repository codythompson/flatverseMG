using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace flatverse
{
    public class RectDrawable : Drawable
    {
        public FVImage texture;
        private Vector2 dims;

        public RectDrawable(FVImage texture, Vector2 dims, float depth)
            : base(depth)
        {
            this.texture = texture;
            this.dims = dims;
        }

        public RectDrawable(FVImage texture, float width, float height, float depth)
            : this(texture, new Vector2(width, height), depth)
        {}

        public override void update()
        {}

        public override void draw(SpriteBatch spriteBatch, Vector2 pos, Vector2 scale, Color color, float lerpVal)
        {
            pos = getOffsetPos(pos);
            scale = getMultipliedScale(scale);
            color = getLerpedColor(color, lerpVal);

            scale *= dims;

            spriteBatch.Draw(texture.texture, pos, texture.sourceRect, color, 0, Vector2.Zero, scale, SpriteEffects.None, depth);
        }

        public override Drawable clone()
        {
            RectDrawable newInst = new RectDrawable(texture, dims, depth);
            newInst.scale = scale;
            newInst.color = color;
            return newInst;
        }
    }
}