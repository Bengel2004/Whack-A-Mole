using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WhackAMole.Managers
{
    public class HoleGenerator : MonoBehaviour
    {
        public List<Vector3> _holePositions = new();
        [SerializeField] private float _holeAmount = 5f;
        [SerializeField] private float _gridHeight = 3f;
        private Vector2 _offset = new Vector2(2.5f, -2.5f);

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
            foreach (Vector3 hole in _holePositions)
            {
                Gizmos.DrawSphere(hole, 1f);
            }
        }
    }
}