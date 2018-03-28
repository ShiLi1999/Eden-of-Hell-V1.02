using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedemptionEffect : MonoBehaviour {

    
    public GameObject HolyLight;
   // public GameObject Explosion;
    public Transform FPoint;
    
    float mTimer;
    float lifeTime = 0.75f;
    public static bool active = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (active)//Active
        {
           
            GameObject clone;
            clone = Instantiate(HolyLight, FPoint.position, FPoint.rotation);
            // clone.velocity = transform.TransformDirection(Vector3.right * 10);


            StartCoroutine(WaitThenDie(clone));

            active = false;

        }

    }

    IEnumerator WaitThenDie(GameObject CLONE)
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(CLONE);
    }

 
}
