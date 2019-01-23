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

        public PhysicsField()
        {
            this.rects = new List<Rectangle>();
            this.physBodies = new List<PhysicsBody>();
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
            for (int i=0; i<physBodies.Count; i++)
            {
                PhysicsBody body = physBodies[i];
                body.rect.X += (int)body.velo.X;
                body.rect.Y += (int)body.velo.Y;

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
            pos.X += velo.X;
            pos.Y += velo.Y;

            rect.X = (int)pos.X;
            rect.Y = (int)pos.Y;
        }

        public abstract void collidedWith(PhysicsBody other);
    }
}
