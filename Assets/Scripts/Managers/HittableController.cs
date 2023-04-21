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
        [SerializeField] private Vector2Int _minMaxMoles = new Vector2Int(2, 4);
        [SerializeField] private int _molesToSpawn => UnityEngine.Random.Range(_minMaxMoles.x, _minMaxMoles.y);

        #endregion

        #region Private Fields
        // Active hittables with a float to keep the time on when to move the object.
        private List<IHittable> _activeHittables = new();


        #endregion

        #region Setup

        // Start is called before the first frame update
        void Start()
        {
            GameManager.instance.OnStartGame += StartGame;
            GameManager.instance.OnEndGame += EndGame;
        }

        private void OnDestroy()
        {
            GameManager.instance.OnStartGame -= StartGame;
            GameManager.instance.OnEndGame -= EndGame;
        }

        #endregion

        #region Update

        // Update is called once per frame
        private void Update()
        {
            if (_activeHittables.Count > 0)
            {
                foreach (IHittable hittable in _activeHittables)
                {
                    if (Time.time >= hittable.timeToPopUp && hittable.isHidden)
                    {
                        MoveActiveHittable(hittable);
                    }
                    if (Time.time >= hittable.timeToHide && !hittable.isHidden)
                    {
                        HideActiveHittable(hittable);
                    }
                }
            }
        }

        #endregion

        #region Private

        /// <summary>
        /// Starts the game by spawning some moles.
        /// </summary>
        private void StartGame()
        {
            for (int index = 0; index < _molesToSpawn; index++)
            {
                AddActiveHittable(_hittableSpawner.SpawnHittable());
            }
        }

        /// <summary>
        /// When the game is over, remove all the previous hittables.
        /// </summary>
        private void EndGame()
        {
            foreach(IHittable hittable in _activeHittables.ToArray())
            {
                RemoveActiveHittable(hittable);
            }
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
            var index = _activeHittables.IndexOf(hittable);
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
            _activeHittables[index].PopUp(_holeGenerator.GetRandomHolePosition(currentPosition));
        }

        /// <summary>
        /// Hides the active hittable.
        /// </summary>
        /// <param name="hittable"></param>
        public void HideActiveHittable(IHittable hittable)
        {
            int index = _activeHittables.IndexOf(hittable);
            _activeHittables[index].Hide();
        }

        /// <summary>
        /// Triggers the death function and removes the hittable.
        /// </summary>
        /// <param name="hittable"></param>
        public void OnHittableDeath(IHittable hittable)
        {
            RemoveActiveHittable(hittable);
            AddActiveHittable(_hittableSpawner.SpawnHittable());
        }

        #endregion
    }
}