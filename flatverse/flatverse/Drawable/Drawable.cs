using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace flatverse
{
    public abstract class Drawable
    {
        public Vector2 scale;
        public Color color;
        public float depth;
        public Vector2 offset;
        public bool visible;

        public Drawable(float depth)
        {
            this.depth = depth;
            scale = Vector2.One;
            color = Color.White;
            offset = Vector2.Zero;
            visible = true;
        }

        public abstract void update();
        public abstract void draw(SpriteBatch spriteBatch, Vector2 pos, Vector2 scale, Color color, float lerpVal);
        public virtual void simpleDraw(SpriteBatch spriteBatch, Vector2 pos)
        {
            if (!visible)
            {
                return;
            }
            draw(spriteBatch, pos, Vector2.One, Color.White, 0);
        }
        public abstract Drawable clone();

        public virtual Vector2 getMultipliedScale(Vector2 scale)
        {
            if (scale.X != 1 || scale.Y != 1)
            {
                return this.scale * scale;
            }
            return this.scale;
        }

        public virtual Color getLerpedColor(Color color, float lerpVal)
        {
            if (lerpVal != 0)
            {
                return Color.Lerp(this.color, color, lerpVal);    
            }
            return this.color;
        }

        public virtual Vector2 getOffsetPos(Vector2 pos)
        {
            return pos + offset;
        }
    }
}