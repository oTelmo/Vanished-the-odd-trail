using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
	public IEnumerator Shake (float duration, float xMagnitude, float yMagnitude)
    {
        Vector3 initialPosition = transform.localPosition;

        float elapsed = 0f;

        while(elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * xMagnitude;
            float y = Random.Range(-1f, 1f) * yMagnitude;

            transform.localPosition = new Vector3(x, y, initialPosition.z);

            elapsed += Time.fixedDeltaTime;
            
            yield return null;
        }

        transform.localPosition = initialPosition;
    }
}
