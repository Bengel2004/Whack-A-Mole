using UnityEngine;
namespace WhackAMole.Interface
{
    public class UIDisplayer : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField] private GameObject _displayedUI = default;

        #endregion

        #region Public

        /// <summary>
        /// Enables and Disables the UI
        /// </summary>
        public void ToggleUI()
        {
            _displayedUI.SetActive(!_displayedUI.activeSelf);
        }

        /// <summary>
        /// Disables the UI element.
        /// </summary>
        public void DisableUI()
        {
            _displayedUI.SetActive(false);
        }

        #endregion
    }
}
