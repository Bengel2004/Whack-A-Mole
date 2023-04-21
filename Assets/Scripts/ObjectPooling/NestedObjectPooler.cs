using System.Collections.Generic;
using UnityEngine;

namespace WhackAMole.ObjectPooling
{
    public class NestedObjectPooler : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField] private List<NestedPool> pool;
        [SerializeField] private GameObject[] prefabs;
        [SerializeField] private int size;

        #endregion

        #region Private Fields

        private List<int> currentIndex = new();
        private int spawnIndex;

        #endregion

        #region Setup

        private void Awake()
        {
            pool = new List<NestedPool>(4);
            foreach (GameObject prefab in prefabs)
            {
                NestedPool _temp = new NestedPool();
                pool.Add(_temp);
            }

            ObjectPool(size);
        }

        #endregion

        #region Private

        /// <summary>
        /// Creates the object pool
        /// </summary>
        /// <param name="size"></param>
        private void ObjectPool(int size)
        {
            foreach (GameObject prefab in prefabs)
            {

                pool[spawnIndex].nesting = new List<GameObject>(size);
                currentIndex.Add(0); // Adds a new int to start from
                for (int i = 0; i < size; ++i)
                {
                    Spawn();
                }

                spawnIndex += 1;
            }
        }

        /// <summary>
        /// Spawns the gameobjects for in the pool.
        /// </summary>
        private void Spawn()
        {
            GameObject obj = Object.Instantiate(prefabs[spawnIndex]);
            obj.SetActive(false);
            obj.transform.SetParent(transform);
            pool[spawnIndex].nesting.Add(obj);
        }

        #endregion

        #region Public

        /// <summary>
        /// Grabs the next item from the pool index.
        /// </summary>
        /// <param name="_value"></param>
        /// <param name="_position"></param>
        /// <param name="_rotation"></param>
        /// <returns></returns>
        public GameObject GetNext(int _value, Vector3 _position, Quaternion _rotation)
        {
            GameObject obj = pool[_value].nesting[currentIndex[_value]];
            currentIndex[_value] = ++currentIndex[_value] % pool[_value].nesting.Count;
            if (obj != null)
            {
                obj.SetActive(true);
                // rotates obj items according to the pool
                obj.transform.position = _position;
                obj.transform.rotation = _rotation;
            }
            return obj;
        }

        #endregion
    }
}