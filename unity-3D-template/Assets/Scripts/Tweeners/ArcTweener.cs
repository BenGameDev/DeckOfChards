using DG.Tweening;
using UnityEngine;

public class ArcTweener : MonoBehaviour, IObjectTweener
{
    [SerializeField] private float speed;
    [SerializeField] private float height;

    void IObjectTweener.MoveTo(Transform transform, Vector3 targetPosition)
    {
        float distance = Vector3.Distance(targetPosition, transform.position);
        transform.DOJump(targetPosition, height, 1, distance / speed);
    }
}
