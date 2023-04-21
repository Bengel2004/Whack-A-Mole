using UnityEngine;
using TMPro;

namespace WhackAMole.ScoreSystems
{
    public class HighScoreElement : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _score;

        #endregion

        #region Public

        /// <summary>
        /// Initializes the High Score Element and displays the name and score. 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="score"></param>
        public void Initialize(string name, float score)
        {
            _name.text = name;
            _score.text = score.ToString();
        }

        #endregion
    }
}
