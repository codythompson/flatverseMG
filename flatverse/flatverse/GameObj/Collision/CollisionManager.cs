using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace flatverse
{
    public class CollisionManager
    {
        private List<Collider>[] heavy, light;
 
        public CollisionManager(int collisionLayerCount)
        {
            heavy = new List<Collider>[collisionLayerCount];
            light = new List<Collider>[collisionLayerCount];

            for (int i = 0; i < collisionLayerCount; i++)
            {
                heavy[i] = new List<Collider>();
                light[i] = new List<Collider>();
            }
        }

        public void registerCollider(Collider collider, int layer, bool isHeavy)
        {
            checkRange(layer);

            if (isHeavy)
            {
                heavy[layer].Add(collider);
            }
            else
            {
                light[layer].Add(collider);
            }
        }

        public void registerColliders(GameObj obj, int layer, bool isHeavy)
        {
            foreach (Collider collider in obj.getColliders())
            {
                registerCollider(collider, layer, isHeavy);
            }
        }

        public void collide()
        {
            for (int i = 0; i < heavy.Length; i++)
            {
                foreach (Collider heavyColl in heavy[i])
                {
                    foreach (Collider lightColl in light[i])
                    {
                        heavyColl.collideAwayFrom(lightColl, true);
                    }
                }
            }
            for (int i = heavy.Length - 1; i >= 0; i--)
            {
                for (int j = heavy[i].Count - 1; j >= 0; j--)
                {
                    for (int k = light[i].Count - 1; k >= 0; k--)
                    {
                        light[i][k].collideAwayFrom(heavy[i][j], false);
                    }
                }
            }
        }

        private void checkRange(int layer)
        {
            if (layer < 0 || layer >= heavy.Length)
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}
