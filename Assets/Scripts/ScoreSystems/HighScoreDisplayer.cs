using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using WhackAMole.Managers;
using WhackAMole.SaveSystems;


namespace WhackAMole.ScoreSystems
{
    public class HighScoreDisplayer : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField] private GameObject _scoreObject;
        [SerializeField] private GameObject _parentObject;

        #endregion

        #region Private Fields

        private List<GameObject> _allChildObjects = new();

        #endregion

        #region Setup

        private void OnEnable()
        {
            DisplayHighscore();
        }
        private void OnDisable()
        {
            foreach (GameObject elementObject in _allChildObjects.ToArray())
            {
                Destroy(elementObject);
            }
            _allChildObjects.Clear();
        }

        #endregion

        #region Public

        /// <summary>
        /// Displays the highscore.
        /// </summary>
        public void DisplayHighscore()
        {
            List<PlayerData> SortedList = GameManager.instance.GetPlayerData.playerDatas.OrderByDescending(o => o.score).ToList();
            if (SortedList.Count > 0)
            {
                foreach (PlayerData data in SortedList)
                {
                    AddElement(data.name, data.score);
                }
            }
        }

        /// <summary>
        /// Adds individual score element.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="score"></param>
        public void AddElement(string name, float score)
        {
            GameObject temp = Instantiate(_scoreObject, _parentObject.transform.position, Quaternion.identity);
            temp.transform.SetParent(_parentObject.transform);
            temp.transform.localScale = new Vector3(1f, 1f, 1f);

            _allChildObjects.Add(temp);

            HighScoreElement element = temp.GetComponent<HighScoreElement>();
            element.Initialize(name, score);
        }

        #endregion
    }
}