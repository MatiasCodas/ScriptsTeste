using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FloatingPlatform : MonoBehaviour
{
    [SerializeField] private Vector3 _moveDistance;
    [SerializeField] private float _moveDuration;
    [SerializeField] private Ease _easeType = Ease.Linear;

    private void Start()
    {
        MovePlatform();
    }
    private void MovePlatform()
    {
        transform.DOLocalMove(transform.position + _moveDistance, _moveDuration).SetEase(_easeType).OnComplete(() =>
        {
            _moveDistance *= -1;
            MovePlatform();
        });
    }
}
