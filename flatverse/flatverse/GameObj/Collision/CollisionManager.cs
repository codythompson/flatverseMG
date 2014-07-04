using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace flatverse
{
    public class CollisionManager
    {
        /*
         * The collision plane idea still doesn't satisfy a lot of conditions
         * such as enemys that can interact with the player but not with the
         * 'walls' around them, multiplayer, etc.
         * TODO implement some sort of collision layer approach
         * 
         * Collision plane
         * 
         * 3 groups make up the collision plane
         *
         * * - The 'action' group can collide with all of the groups.
         *     When collisions between two objects of this group occur,
         *     the object with the heavier weightClass "pushes" the the
         *     other object out of its way
         *     
         *     Objects in the 'action' group can have any range of weightClass
         *     EXCEPT FOR the minimum possible weightClass (0) and the
         *     maximum possible weightClass (given to the CollisionManage
         *     constructor).
         *     
         *     The player and any "normal behaving" "physics objects" should probably 
         *     always belong to the 'action' group.
         *     
         * The 'superHeavy' and 'superLight' groups can only collide with the 'action' group.
         * 
         * - The 'superHeavy' group will only collide with objects from the 'action' group and 
         *     will always have a heavier weightClass than than any member of the 'action'
         *     group and therefore any member of the 'superHeavy' group will always
         *     push a colliding member of the 'action' group out of its way.
         *     
         *     Objects in the 'superHeavy' group can ONLY have the maximum possible collisionWeight
         *     
         *     platforms, walls, and moving platforms that can "travel through walls" should be part
         *     of this group.
         *     
         * - The 'superLight' group will only collide with the 'action' group and will always have
         *     a lighter weightClass than any member of the 'action' group and therefore any member of
         *     the 'action' group will always push a member of the 'superLight' group out of it's way.
         *     
         *     Objects in the 'superLight' group can ONLY have the minimum possible collisionWeight
         *     
         *     This group is reserved for the rare case where the player can move the object but the
         *     object can pass through members of the 'superHeavy' group like walls and the such.
         */

        private List<Collider> heavyColliders;
        private List<Collider> actionColliders;
        private List<Collider> lightColliders;
 
        public CollisionManager()
        {
            heavyColliders = new List<Collider>();
            actionColliders = new List<Collider>();
            lightColliders = new List<Collider>();
        }

        public void registerCollider(Collider collider)
        {
            if (collider.weightClass == 1)
            {
                heavyColliders.Add(collider);
            }
            else if (collider.weightClass == 0)
            {
                lightColliders.Add(collider);
            }
            else
            {
                actionColliders.Add(collider);
            }
        }

        public void registerColliders(GameObj obj)
        {
            foreach (Collider collider in obj.getColliders())
            {
                registerCollider(collider);
            }
        }

        /// <summary>
        /// TODO
        /// Currently this only supports heavy vs action collisions
        /// </summary>
        public void collide()
        {
            foreach (Collider heavy in heavyColliders)
            {
                foreach (Collider collider in actionColliders)
                {
                    collider.collideAwayFrom(heavy);
                }
            }
            foreach (Collider heavy in heavyColliders)
            {
                heavy.postCollision();
            }
            foreach (Collider action in actionColliders)
            {
                action.postCollision();
            }
        }
    }
}
