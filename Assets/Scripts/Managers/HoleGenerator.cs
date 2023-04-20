using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WhackAMole.Managers
{
    public class HoleGenerator : MonoBehaviour
    {
        #region Public Fields

        public List<Vector2> _holePositions = new();
        // you can make it a dictionary too with a Vector2 Key and a boolean to check if the place is already taken or not.

        #endregion

        #region Serialized Fields

        [SerializeField] private float _holeAmount = 5f;
        [SerializeField] private float _gridHeight = 3f;

        #endregion

        #region Private Fields

        private Vector2 _offset = new Vector2(2.5f, -2.5f);

        #endregion

        #region Private

        /// <summary>
        /// Generates the grid for the mole to move into.
        /// </summary>
        private void GenerateGrid()
        {
            float _holesPerRow = Mathf.Round(_holeAmount / _gridHeight);
            float _holesRemaining = _holeAmount - (_holesPerRow * _gridHeight);

            _holePositions.Clear();

            for (int row = 1; row <= _gridHeight;)
            {
                if (row != _gridHeight)
                {
                    for (int hole = 1; hole <= _holesPerRow; hole++)
                    {
                        _holePositions.Add(new Vector2(hole * _offset.x, row * _offset.y));
                    }
                }
                else
                {
                    for (int hole = 1; hole <= _holesPerRow + _holesRemaining; hole++)
                    {
                        _holePositions.Add(new Vector2(hole * (_offset.x * 1.25f), row * _offset.y));
                    }
                }
                row++;
            }

        }

        #endregion

        #region Public

        /// <summary>
        /// Grabs a random hole that is not the same as the previous one.
        /// </summary>
        /// <param name="currentPosition">This value is optional, for the first instance it will be default vector2 (0, 0) but for the next position it may be different.</param>
        /// <returns></returns>
        public Vector2 GetRandomHolePosition(Vector2 currentPosition = default(Vector2))
        {
            var randomIndex = 0;
            Vector2 randomPosition = Vector2.zero;
            do
            {
                randomIndex = Random.Range(0, _holePositions.Count - 1);
                randomPosition = _holePositions[randomIndex];
            }
            while (randomPosition == currentPosition);

            return randomPosition;
        }

        #endregion

        // Start is called before the first frame update
        void Start()
        {
            GenerateGrid();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                GenerateGrid();
            }
        }

        private void OnDrawGizmos()
        {
            foreach (Vector2 hole in _holePositions)
            {
                Gizmos.DrawSphere(hole, 1f);
            }
        }
    }
}