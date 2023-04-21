using System;
using UnityEngine;
using WhackAMole.Managers;
using WhackAMole.ScoreSystems;

namespace WhackAMole.Hittables
{
    public abstract class HittableBase : MonoBehaviour, IHittable
    {
        #region Public

        private HittableController _controller;
        public Transform movableTransform { get => transform; }
        public Vector3 currentPosition { get => transform.position; }

        public Action<IHittable> OnThisHittableDeath;

        public float timeToHide { get; set; }
        public float timeToPopUp { get; set; }
        public bool isHidden { get; set; }

        #endregion

        #region Serialized Fields

        [SerializeField] private HittableTarget _thisTarget;

        #endregion

        #region Private

        private float health = 0f;
        private bool _isAlive => health > 0f;

        #endregion

        #region Setup

        protected virtual void Awake()
        {
            _controller = FindObjectOfType<HittableController>();
        }

        protected void Start()
        {
            GameManager.instance.OnEndGame += OnEndGame;
        }

        protected virtual void OnEnable()
        {
            OnThisHittableDeath += _controller.OnHittableDeath;
            OnThisHittableDeath += OnDeath;
        }

        protected virtual void OnDisable()
        {
            OnThisHittableDeath -= _controller.OnHittableDeath;
            OnThisHittableDeath -= OnDeath;
        }

        protected void OnDestroy()
        {
            GameManager.instance.OnEndGame -= OnEndGame;
        }

        #endregion

        #region Public

        /// <summary>
        /// Moves the hittable to a new position.
        /// </summary>
        /// <param name="newPosition"></param>
        public virtual void PopUp(Vector3 newPosition)
        {
            gameObject.SetActive(true);
            isHidden = false;
            timeToHide = Time.time + _thisTarget.timeToMoveToNextPoint;
            movableTransform.transform.position = newPosition;
        }

        /// <summary>
        /// Hides the hittable from being hit.
        /// </summary>
        public void Hide()
        {
            isHidden = true;
            timeToPopUp = Time.time + UnityEngine.Random.Range(1f, 5f);
            gameObject.SetActive(false);
        }

        /// <summary>
        /// Hittable takes damage.
        /// </summary>
        /// <param name="damage"></param>
        public virtual void HitHittable(float damage)
        {
            health -= damage;
            if (_isAlive)
                _controller.MoveActiveHittable(this);
            else
                OnThisHittableDeath.Invoke(this);
        }

        /// <summary>
        /// When the hittable Dies.
        /// </summary>
        public virtual void OnDeath(IHittable thisHittable)
        {
            ScoreManager.instance.UpdateScore(_thisTarget.scoreValue);
            health = _thisTarget.startHealth;
            gameObject.SetActive(false);
        }

        /// <summary>
        /// On the end of the game.
        /// </summary>
        public void OnEndGame()
        {
            health = _thisTarget.startHealth;
            gameObject.SetActive(false);
        }

        #endregion
    }
}