using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using WhackAMole.ScoreSystems;
using WhackAMole.SaveSystems;
using WhackAMole.Interface;

namespace WhackAMole.Managers
{
    public class GameManager : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField] private SaveSystem saveSystem = default;
        [SerializeField] private ScoreManager scoreManager = default;
        [SerializeField] private PlayerName playerName = default;

        #endregion

        #region Properties
        public PlayerListData GetPlayerData => saveSystem.playerData;
        public string GetPlayerName => playerName.GetPlayerName;
        public float GetScore => scoreManager.GetScore;

        #endregion

        #region Public Fields
        public static GameManager instance = null;

        public Action OnStartGame;
        public Action OnEndGame;

        #endregion

        #region Setup
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }
        // Start is called before the first frame update
        void Start()
        {
            OnEndGame += RestartGame;
        }

        private void OnDestroy()
        {
            OnEndGame -= RestartGame;
        }

        #endregion

        #region Private

        /// <summary>
        /// Slight delay so all properties are filled with values.
        /// </summary>
        /// <returns></returns>
        private IEnumerator StartGameOnEndOfFrame()
        {
            yield return new WaitForEndOfFrame();
            OnStartGame.Invoke();
        }

        #endregion

        #region Public

        /// <summary>
        /// Saves the player data.
        /// </summary>
        public void RestartGame()
        {
            saveSystem.SaveNewData(playerName.GetPlayerName, scoreManager.GetScore);
        }


        /// <summary>
        /// Starts the game.
        /// </summary>
        public void StartGame()
        {
            StartCoroutine(StartGameOnEndOfFrame());
        }

        #endregion
    }
}