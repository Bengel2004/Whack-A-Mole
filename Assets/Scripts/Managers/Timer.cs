using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WhackAMole.Interface;

namespace WhackAMole.Managers
{
    public class Timer : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField] TextDisplayer _textDisplayer = default;
        [SerializeField] private float _gameDurationTime;

        #endregion

        #region Private Fields

        private bool _canUpdateTime = false;

        private float _startTime;
        private float _endTime;
        private float GetGameTime => Mathf.Round((_startTime + _gameDurationTime) - Time.time);
        private TimeSpan GetConvertedGameTime => TimeSpan.FromSeconds(GetGameTime);
        private string GetTimeText => string.Format("{0:D2}:{1:D2}", (int)GetConvertedGameTime.TotalMinutes, GetConvertedGameTime.Seconds);

        #endregion

        #region Setup

        // Start is called before the first frame update
        private void Start()
        {
            GameManager.instance.OnStartGame += ResetTime;
            GameManager.instance.OnEndGame += EndTime;
        }

        private void OnDestroy()
        {
            GameManager.instance.OnStartGame -= ResetTime;
            GameManager.instance.OnEndGame -= EndTime;
        }

        #endregion

        #region Update

        // Update is called once per frame
        private void Update()
        {
            if (_canUpdateTime)
                _textDisplayer.DisplayText(GetTimeText);

            if (GetGameTime <= 0 && _canUpdateTime)
            {
                GameManager.instance.OnEndGame.Invoke();
            }
        }

        #endregion

        #region Public

        private void ResetTime()
        {
            _startTime = Time.time;
            _canUpdateTime = true;
        }

        private void EndTime()
        {
            _canUpdateTime = false;
            _endTime = GetGameTime;
            Debug.Log("End of  game");
        }

        #endregion
    }
}