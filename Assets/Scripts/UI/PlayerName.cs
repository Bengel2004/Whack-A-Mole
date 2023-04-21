using UnityEngine;
using TMPro;

namespace WhackAMole.Interface
{
    public class PlayerName : MonoBehaviour
    {
        #region Private Fields

        private TMP_InputField _input;

        #endregion

        #region Properties
        public string GetPlayerName => _input.text;

        #endregion

        #region Setup

        private void Start()
        {
            _input = GetComponent<TMP_InputField>();
        }

        #endregion
    }
}