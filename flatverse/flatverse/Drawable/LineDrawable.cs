using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace flatverse
{
    public class LineDrawable : Drawable
    {
        public FVImage texture;
        private float length, angle;

        public LineDrawable(FVImage texture,float length, float angle, float depth)
            : base(depth)
        {
            this.texture = texture;
            this.length = length;
            this.angle = angle;
        }

        public LineDrawable(FVImage texture, Vector2 delta, float depth)
            : this(texture, delta.Length(), Utils.vectorToAngle(delta), depth)
        {}

        public override void update()
        {}

        public override void draw(SpriteBatch spriteBatch, Vector2 pos, Vector2 scale, Color color, float lerpVal)
        {
            pos = getOffsetPos(pos);
            scale = getMultipliedScale(scale);
            color = getLerpedColor(color, lerpVal);

            scale.X *= length;

            spriteBatch.Draw(texture.texture, pos, texture.sourceRect, color, angle, Vector2.Zero, scale, SpriteEffects.None, depth);
        }

        public override Drawable clone()
        {
            LineDrawable newInst = new LineDrawable(texture, length, angle, depth);
            newInst.scale = scale;
            newInst.color = color;
            return newInst;
        }

        public virtual float getLength()
        {
            return length;
        }

        public virtual float getAngle()
        {
            return angle;
        }

        public virtual Vector2 getLineDelta()
        {
            return new Vector2((float)(length * Math.Cos(angle)), (float)(length * Math.Sin(angle)));
        }
    }
}