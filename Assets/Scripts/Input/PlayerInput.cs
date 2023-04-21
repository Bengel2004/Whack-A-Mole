using UnityEngine;
using WhackAMole.Hittables;
using WhackAMole.Managers;

namespace WhackAMole.PlayerInput
{
    public class PlayerInput : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField] private float _damage = 50f;

        #endregion

        #region Private Fields

        private RaycastHit2D hit = default;
        private bool _canHitMoles = false;

        #endregion

        #region Setup
        // Start is called before the first frame update
        void Start()
        {
            GameManager.instance.OnStartGame += EnableHitting;
            GameManager.instance.OnEndGame += DisableHitting;
        }

        private void OnDisable()
        {
            GameManager.instance.OnStartGame -= EnableHitting;
            GameManager.instance.OnEndGame -= DisableHitting;
        }

        #endregion

        #region Update

        private void Update()
        {
            if (Input.GetMouseButtonUp(0) && _canHitMoles)
            {
                hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                CheckIfHit();
            }
        }

        #endregion

        #region Public

        /// <summary>
        /// Enables ability for player to hit the moles.
        /// </summary>
        private void EnableHitting()
        {
            _canHitMoles = true;
        }

        /// <summary>
        /// Disables ability for player to hit the moles.
        /// </summary>
        private void DisableHitting()
        {
            _canHitMoles = false;
        }

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