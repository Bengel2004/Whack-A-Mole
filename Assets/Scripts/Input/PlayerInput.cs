using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WhackAMole.Hittables;

namespace WhackAMole.PlayerInput
{
    public class PlayerInput : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField] private float _damage = 50f;

        #endregion

        #region Private Fields

        private RaycastHit2D hit = default;

        #endregion

        #region Setup
        // Start is called before the first frame update
        void Start()
        {

        }

        #endregion

        #region Private
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                CheckIfHit();
            }
        }

        #endregion

        #region Public

        /// <summary>
        /// Checks if the player has hit a hittable target.
        /// </summary>
        public void CheckIfHit()
        {
            IHittable tempHit = hit.transform?.GetComponent<IHittable>();
            if (tempHit != null)
            {
                tempHit.HitHittable(_damage);
            }
        }

        #endregion
    }
}