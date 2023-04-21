using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using WhackAMole.Managers;

namespace WhackAMole.Interface
{
    public class InterfaceManager : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField] private UIDisplayer StartUI;
        [SerializeField] private UIDisplayer GameHUD;
        [SerializeField] private UIDisplayer EndUI;
        [SerializeField] private Button returnUIButton;

        #endregion

        #region Setup

        private void Start()
        {
            GameHUD.DisableUI();

            GameManager.instance.OnStartGame += StartGameUI;
            GameManager.instance.OnEndGame += RestartGameUI;
        }

        private void OnEnable()
        {
            returnUIButton.interactable = false;
            StartCoroutine(EnableClick());
        }

        private void OnDestroy()
        {
            GameManager.instance.OnStartGame -= StartGameUI;
            GameManager.instance.OnEndGame -= RestartGameUI;

        }

        #endregion

        #region Public

        public void StartGameUI()
        {
            StartUI.ToggleUI();
            GameHUD.ToggleUI();
        }
        public void RestartGameUI()
        {
            EndUI.ToggleUI();
            GameHUD.ToggleUI();
        }
        public void ToggleMenuUI()
        {
            EndUI.ToggleUI();
            StartUI.ToggleUI();
        }

        #endregion

        #region Private

        IEnumerator EnableClick()
        {
            yield return new WaitForSeconds(3f);
            returnUIButton.interactable = true;
        }

        #endregion
    }
}