using UnityEngine;

namespace WhackAMole.Hittables
{
    [CreateAssetMenu(fileName = "Hittable Target", menuName = "WhackAMole/Hittable Target", order = 1)]
    public class HittableTarget : ScriptableObject
    {
        public float startHealth = 100f;
        public float scoreValue = 10f;
        public float timeToMoveToNextPoint = 2f;
    }
}