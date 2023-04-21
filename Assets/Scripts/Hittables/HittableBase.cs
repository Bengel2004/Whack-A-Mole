using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WhackAMole.Managers;

namespace WhackAMole.Hittables
{
    public abstract class HittableBase : MonoBehaviour, IHittable
    {
        #region Public

        private HittableController _controller;
        public Transform movableTransform { get => transform; }
        public Vector3 currentPosition { get => transform.position; }

        public Action<IHittable> OnThisHittableDeath;

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

        #endregion

        #region Public

        /// <summary>
        /// Moves the hittable to a new position.
        /// </summary>
        /// <param name="newPosition"></param>
        public virtual void Move(Vector3 newPosition)
        {
            movableTransform.transform.position = newPosition;
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
            health = _thisTarget.startHealth;
            gameObject.SetActive(false);
        }

        #endregion
    }
}