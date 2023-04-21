using UnityEngine;

namespace WhackAMole.Hittables
{
    public interface IHittable
    {
        float timeToHide { get; set; }
        float timeToPopUp { get; set; }
        bool isHidden { get; set; }
        Transform movableTransform { get; }
        Vector3 currentPosition { get; }
        void PopUp(Vector3 newPosition);
        void Hide();
        void HitHittable(float damage);
    }
}