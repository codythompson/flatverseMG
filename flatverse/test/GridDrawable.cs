using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace flatverse
{
    public class GridDrawable : Drawable
    {
        public LineDrawable hor, ver;
        public int horCnt, verCnt;
        public Vector2 between;

        public GridDrawable(FVImage lineImage, int verCnt, int horCnt, float width, float height, float depth, float betweenVer, float betweenHor)
            : base(depth)
        {
            hor = new LineDrawable(lineImage, new Vector2(width, 0), depth);
            ver = new LineDrawable(lineImage, new Vector2(0, height), depth);
            this.verCnt = verCnt;
            this.horCnt = horCnt;
            between = new Vector2(betweenVer, betweenHor);
        }

        public override void update()
        {}

        public override void draw(SpriteBatch spriteBatch, Vector2 pos, Vector2 scale, Color color, float lerpVal)
        {
            scale = getMultipliedScale(scale);
            color = getLerpedColor(color, lerpVal);
            pos = getOffsetPos(pos);

            Vector2 linePos = pos;
            for (int i = 0; i < verCnt; i++)
            {
                Vector2 curPos = new Vector2(linePos.X + (i* between.X), linePos.Y);
                ver.draw(spriteBatch, curPos, scale, color, 1);
            }

            for (int i = 0; i < horCnt; i++)
            {
                Vector2 curPos = new Vector2(linePos.X, linePos.Y + (i * between.Y));
                hor.draw(spriteBatch, curPos, scale, color, 1);
            }
        }

        public override Drawable clone()
        {
            return new GridDrawable(hor.texture, verCnt, horCnt, hor.getLength(), ver.getLength(), depth, between.X, between.Y);
        }
    }
}