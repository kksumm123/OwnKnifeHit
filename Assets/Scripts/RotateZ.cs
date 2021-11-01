using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateZ : MonoBehaviour
{
    [SerializeField] float minZ = 800f;
    [SerializeField] float maxZ = 1300f;
    [SerializeField] float duration = 5f;
    bool isEnd = false;
    [SerializeField] Ease ease = Ease.InOutCubic;
    IEnumerator Start()
    {
        transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 360));
        while (true)
        {
            isEnd = false;
            var rotateZ = transform.eulerAngles.z;
            var endZ = Random.Range(minZ, maxZ);
            DOTween.To(() => rotateZ, z => transform.eulerAngles = new Vector3(0, 0, z), endZ, duration)
                   .OnComplete(() => isEnd = true)
                   .SetLink(gameObject)
                   .SetEase(ease);

            while (isEnd == false)
                yield return null;
        }
    }
}
