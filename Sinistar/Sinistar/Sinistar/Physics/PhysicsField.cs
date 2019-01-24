using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sinistar
{
    class PhysicsField
    {
        public List<Rectangle> rects;
        public List<PhysicsBody> physBodies;
        private int count;

        public PhysicsField()
        {
            this.rects = new List<Rectangle>();
            this.physBodies = new List<PhysicsBody>();
            count = 0;
        }

        public void addObject(Rectangle rect)
        {
            rects.Add(rect);
        }
        public void delObject(Rectangle rect)
        {
            rects.Remove(rect);
        }

        public void addPhysicsBody(PhysicsBody body)
        {
            physBodies.Add(body);
        }
        public void disableMovingObect(PhysicsBody body) {
            body.disabled = true;
        }

        public void updateBodies()
        {
            count++;

            for (int i=0; i<physBodies.Count; i++)
            {
                PhysicsBody body = physBodies[i];
                body.updatePhysics();
                body.updateCount(count);

                if (body.disabled == true)
                {
                    body.rect.X = int.MaxValue;
                }

                //Bad collision detector
                for (int b=0; b<physBodies.Count; b++)
                {
                    PhysicsBody body2 = physBodies[b];
                    if(body2 != body) {
                        if (body2.rect.Intersects(body.rect)) {
                            body.collidedWith(body2);
                            body2.collidedWith(body);
                        }
                    }
                }
            }
        }

    }

    public abstract class PhysicsBody
    {
        public Rectangle rect;
        public Vector2 velo;
        public Vector2 pos;
        public bool disabled;

        public PhysicsBody(Rectangle rect, Vector2 velo)
        {
            this.rect = rect;
            this.velo = velo;
        }

        public void updatePhysics()
        {
            updateGraphics();

            pos.X += velo.X;
            pos.Y += velo.Y;

            rect.X = (int)pos.X;
            rect.Y = (int)pos.Y;
        }



        public abstract void updateCount(int count);
        public abstract void updateGraphics();
        public abstract void collidedWith(PhysicsBody other);
    }
}
