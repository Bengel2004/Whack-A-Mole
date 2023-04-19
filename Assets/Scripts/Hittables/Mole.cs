using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WhackAMole.Hittables
{
    public class Mole : MonoBehaviour, IHittable
    {
        #region Public

        public void HitTarget()
        {
            Debug.Log("HIT!");
        }

        #endregion
    }
}