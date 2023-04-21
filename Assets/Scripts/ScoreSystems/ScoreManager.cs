using UnityEngine;
using WhackAMole.Managers;
using WhackAMole.Interface;

namespace WhackAMole.ScoreSystems
{
    public class ScoreManager : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField] private TextDisplayer _textDisplayer = default;

        #endregion

        #region Private Fields

        private float _score = 0;

        #endregion

        #region Properties

        public float GetScore => _score;
        public static ScoreManager instance;

        #endregion

        #region Setup

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            ResetScore();
        }

        private void Start()
        {
            GameManager.instance.OnStartGame += ResetScore;
        }

        private void OnDestroy()
        {
            GameManager.instance.OnStartGame -= ResetScore;
        }

        #endregion

        #region Public

        /// <summary>
        /// Resets the games score.
        /// </summary>
        public void ResetScore()
        {
            _score = 0;
            _textDisplayer.DisplayText(_score);
        }

        /// <summary>
        /// Updates the games score.
        /// </summary>
        /// <param name="score"></param>
        public void UpdateScore(float score)
        {
            _score += score;
            _textDisplayer.DisplayText(_score);
        }

        #endregion
    }
}