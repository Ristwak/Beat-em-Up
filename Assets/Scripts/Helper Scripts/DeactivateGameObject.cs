using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateGameObject : MonoBehaviour
{
    // This code is used to deactivate the HitEffect
    public float timer = 2f;

    void Start()
    {
        Invoke("DeactivateAfterTime",timer);
    }

    void DeactivateAfterTime()
    {
        gameObject.SetActive(false);
    }
}
