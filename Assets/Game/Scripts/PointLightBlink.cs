using System.Collections;
using UnityEngine;

public class PointLightBlink : MonoBehaviour
{
    [SerializeField] private float _timeToWait;

    void Start()
    {
        StartCoroutine(BlinkRoutine());
    }

    IEnumerator BlinkRoutine()
    {
        while (true)
        {
            Light light = this.gameObject.GetComponent<Light>();
            yield return new WaitForSeconds(_timeToWait);
            light.intensity = 0f;
            yield return new WaitForSeconds(_timeToWait);
            light.intensity = 1.75f;
        }
    }
}