﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public IEnumerator Shake (float duration, float magnitude)
    {
        Vector3 original_pos = transform.localPosition;
        float elapsed_time = 0.0f;
        while (elapsed_time < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, original_pos.z);

            elapsed_time += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = original_pos;
    }

}
