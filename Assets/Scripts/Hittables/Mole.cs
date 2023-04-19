using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WhackAMole.Hittables
{
    public class Mole : MonoBehaviour, IHittable
    {
        void Start()
        {

        }

        public void HitTarget()
        {
            Debug.Log("HIT!");
        }
    }
}