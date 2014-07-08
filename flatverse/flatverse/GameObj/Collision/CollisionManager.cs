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
                        lightColl.collideAwayFrom(heavyColl);
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
