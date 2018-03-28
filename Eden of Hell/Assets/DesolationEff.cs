using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesolationEff : MonoBehaviour {

    public static bool invisable = false;
    float InvincibleTimer;
    float InvincibilityDuration = 2.0f;

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {


        GetComponent<Renderer>().enabled = invisable;

        if (invisable)
        {
            InvincibleTimer += Time.deltaTime;
            if (InvincibleTimer >= InvincibilityDuration)
            {
                invisable = false;
                InvincibleTimer = 0.0f;
            }
        }
    }
}
