using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WhackAMole.Hittables;

namespace WhackAMole.PlayerInput
{
    public class PlayerInput : MonoBehaviour
    {
        private RaycastHit2D hit = default;
        // Start is called before the first frame update
        void Start()
        {

        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                CheckIfHit();
            }
        }

        /// <summary>
        /// Checks if the player has hit a hittable target.
        /// </summary>
        public void CheckIfHit()
        {
            IHittable tempHit = hit.transform.GetComponent<IHittable>();
            if (tempHit != null)
            {
                tempHit.HitTarget();
            }
        }
    }
}