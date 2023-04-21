using UnityEngine;
using WhackAMole.Hittables;
using WhackAMole.ObjectPooling;

namespace WhackAMole.Managers
{
    public class HittableSpawner : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField] private NestedObjectPooler _objectPool;
        [SerializeField] private HoleGenerator _holeGenerator;

        #endregion

        #region Internal

        /// <summary>
        /// Spawns a hittable object.
        /// </summary>
        /// <returns></returns>
        internal IHittable SpawnHittable()
        {
            GameObject tempObject = _objectPool.GetNext(0, _holeGenerator.GetRandomHolePosition(), Quaternion.identity);
            IHittable tempHittable = tempObject.GetComponent<IHittable>();
            return tempHittable;
        }

        #endregion
    }
}