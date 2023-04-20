using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WhackAMole.Managers;

namespace WhackAMole.Hittables
{
    public class Mole : MonoBehaviour, IHittable, IMovable
    {
        public Transform movableTransform { get => transform; }
        public Vector3 currentPosition { get => transform.position;}
        public IMovable moveAble { get; set; }

        private HittableController _controller;

        void Start()
        {
            _controller = FindObjectOfType<HittableController>();
        }

        #region Public

        public void HitTarget()
        {
            _controller.MoveActiveHittable(this);
        }

        public void Move(Vector3 newPosition)
        {
            movableTransform.transform.position = newPosition;
        }

        #endregion
    }
}