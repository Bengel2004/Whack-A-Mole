using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using WhackAMole.Hittables;

namespace WhackAMole.Managers
{
    public class HittableController : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField] private HittableSpawner _hittableSpawner;
        [SerializeField] private HoleGenerator _holeGenerator;

        #endregion

        #region Private Fields

        private List<IHittable> _activeHittables = new();

        #endregion

        #region Setup

        // Start is called before the first frame update
        void Start()
        {
            AddActiveHittable(_hittableSpawner.SpawnHittable());
        }

        #endregion

        #region Private

        // Update is called once per frame
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                _activeHittables.Add(_hittableSpawner.SpawnHittable());
            }

            if (Input.GetKeyDown(KeyCode.M))
            {
            }

            Debug.Log(_activeHittables.Count);
        }

        /// <summary>
        /// Adds an active hittable.
        /// </summary>
        /// <param name="hittable"></param>
        private void AddActiveHittable(IHittable hittable)
        {
            _activeHittables.Add(hittable);
        }

        /// <summary>
        /// Removes an active hittable that was hit.
        /// </summary>
        /// <param name="hittable"></param>
        private void RemoveActiveHittable(IHittable hittable)
        {
            _activeHittables.Remove(hittable);
        }

        #endregion

        #region Public

        /// <summary>
        /// Moves the active hittable to a new position.
        /// </summary>
        /// <param name="hittable"></param>
        public void MoveActiveHittable(IHittable hittable)
        {
            int index = _activeHittables.IndexOf(hittable);
            Vector3 currentPosition = _activeHittables[index].currentPosition;
            _activeHittables[index].Move(_holeGenerator.GetRandomHolePosition(currentPosition));
        }

        public void OnHittableDeath(IHittable hittable)
        {
            RemoveActiveHittable(hittable);
            AddActiveHittable(_hittableSpawner.SpawnHittable());
        }

        #endregion
    }
}