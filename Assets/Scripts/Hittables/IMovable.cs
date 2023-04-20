using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WhackAMole.Hittables
{
    public interface IMovable
    {
        Transform movableTransform { get; }
        Vector3 currentPosition { get; }
        void Move(Vector3 newPosition);
    }
}