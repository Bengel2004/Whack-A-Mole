using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using WhackAMole.Hittables;

namespace WhackAMole.Managers
{
    public class HittableController : MonoBehaviour
    {
        [SerializeField] private HittableSpawner _hittableSpawner;
        [SerializeField] private HoleGenerator _holeGenerator;

        private List<IHittable> _activeHittables = new();

        // Start is called before the first frame update
        void Start()
        {
            AddActiveHittable(_hittableSpawner.SpawnHittable());
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                _activeHittables.Add(_hittableSpawner.SpawnHittable());
            }

            if (Input.GetKeyDown(KeyCode.M))
            {
            }
        }

        public void MoveActiveHittable(IHittable hittable)
        {
            int index = _activeHittables.IndexOf(hittable);
            Vector3 currentPosition = _activeHittables[index].moveAble.currentPosition;
            _activeHittables[index].moveAble.Move(_holeGenerator.GetRandomHolePosition(currentPosition));
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
    }
}