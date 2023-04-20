using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WhackAMole.Hittables
{
    public interface IHittable
    {
        IMovable moveAble { get; set; }
        void HitTarget();
    }
}