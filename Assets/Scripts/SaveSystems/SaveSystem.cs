using System.IO;
using UnityEngine;

namespace WhackAMole.SaveSystems
{
    public class SaveSystem : MonoBehaviour
    {
        #region Private Fields

        private string _filename = "savedata.json";
        private string _savePath => Application.persistentDataPath + "/" + _filename;

        #endregion

        #region Public Fields

        public PlayerListData playerData = new PlayerListData();

        #endregion

        #region Setup

        // Start is called before the first frame update
        void Awake()
        {
            playerData = LoadSave();
        }

        private void OnDisable()
        {
            SaveFile(playerData);
        }

        #endregion

        #region Private

        /// <summary>
        /// Saves the data in a json file which is stored in the persistent data path.
        /// </summary>
        /// <param name="playerData"></param>
        private void SaveFile(PlayerListData playerData)
        {
            string json = JsonUtility.ToJson(playerData);
            FileStream fileStream = new FileStream(_savePath, FileMode.Create);

            using (StreamWriter writer = new StreamWriter(fileStream))
            {
                writer.Write(json);
            }
        }

        /// <summary>
        /// Tries to find the save file and if so, loads in the data. If no data is found then it creates a new file with new data.
        /// </summary>
        /// <returns></returns>
        private PlayerListData LoadSave()
        {
            if (File.Exists(_savePath))
            {
                using (StreamReader reader = new StreamReader(_savePath))
                {
                    string json = reader.ReadToEnd();
                    return JsonUtility.FromJson<PlayerListData>(json);
                }
            }
            else
            {
                PlayerListData newList = new PlayerListData();
                SaveFile(newList);
                return newList;
            }
        }

        #endregion

        #region Public

        /// <summary>
        /// Adds the data to the list.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="score"></param>
        public void SaveNewData(string name, float score)
        {
            playerData.playerDatas.Add(new PlayerData(name, score));
            SaveFile(playerData);
        }

        #endregion

    }
}