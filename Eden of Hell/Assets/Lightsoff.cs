using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightsoff : MonoBehaviour {

    public float mExpirationTime;
    float mTimer;

    void Update()
    {
        mTimer += Time.deltaTime;
        if (mTimer >= mExpirationTime)
        {
            Destroy(gameObject);
        }
    }
}
