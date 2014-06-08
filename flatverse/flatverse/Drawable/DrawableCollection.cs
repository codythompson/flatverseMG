using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace flatverse
{
    public class DrawableCollection : Drawable
    {
        public Drawable[] dbls;

        public DrawableCollection(Drawable[] dbls, float depth)
            : base(depth)
        {
            foreach (Drawable dbl in dbls)
            {
                dbl.depth = depth;
            }
            this.dbls = dbls;
        }

        public override void update()
        {
            foreach (Drawable dbl in dbls)
            {
                dbl.update();
            }
        }

        public override void draw(SpriteBatch spriteBatch, Vector2 pos, Vector2 scale, Color color, float lerpVal)
        {
            pos = getOffsetPos(pos);
            scale = getMultipliedScale(scale);
            color = getLerpedColor(color, lerpVal);

            foreach (Drawable dbl in dbls)
            {
                dbl.draw(spriteBatch, pos, scale, color, 1);
            }
        }

        public override Drawable clone()
        {
            Drawable[] newDbls = new Drawable[this.dbls.Length];
            for(int i = 0; i < this.dbls.Length; i++)
            {
                newDbls[i] = this.dbls[i].clone();
            }
            return new DrawableCollection(newDbls, depth);
        }
    }
}