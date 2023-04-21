using UnityEngine;
using TMPro;
using WhackAMole.Managers;

namespace WhackAMole.ScoreSystems
{
    public class DisplayFinalScore : MonoBehaviour
    {
        #region Serialized Fields
        
        [SerializeField] private TextMeshProUGUI _nameText = default;
        [SerializeField] private TextMeshProUGUI _scoreText = default;
        
        #endregion

        #region Setup

        private void OnEnable()
        {
            _nameText.text = GameManager.instance.GetPlayerName;
            _scoreText.text = GameManager.instance.GetScore.ToString();
        }

        #endregion
    }
}
