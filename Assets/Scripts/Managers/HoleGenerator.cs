using System.Collections.Generic;
using UnityEngine;

namespace WhackAMole.Managers
{
    public class HoleGenerator : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField] private float _holeAmount = 5f;
        [SerializeField] private float _gridHeight = 3f;

        #endregion

        #region Private Fields

        private Vector2 _offset = new Vector2(2.5f, -2.5f);

        #endregion
        
        #region Public Fields

        public List<Vector2> _holePositions = new();
        // you can make it a dictionary too with a Vector2 Key and a boolean to check if the place is already taken or not.

        #endregion

        #region Setup

        // Start is called before the first frame update
        void Start()
        {
            GenerateGrid();
        }

        #endregion

        #region Private

        /// <summary>
        /// Generates the grid for the mole to move into based on a height. 6 holes on a height of 2 would generate 2 rows of 3.
        /// </summary>
        private void GenerateGrid()
        {
            float _holesPerRow = Mathf.Round(_holeAmount / _gridHeight);
            float _holesRemaining = _holeAmount - (_holesPerRow * _gridHeight);

            _holePositions.Clear();

            for (int row = 1; row <= _gridHeight;)
            {
                for (int hole = 1; hole <= _holesPerRow; hole++)
                {
                    _holePositions.Add(new Vector2(hole * _offset.x, row * _offset.y));
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
    }
}