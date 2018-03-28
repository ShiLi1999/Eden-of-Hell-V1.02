using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanaticismEffect : MonoBehaviour {

    public GameObject Shield;
    // public GameObject Explosion;
    public Transform FPoint;

    float mTimer;
    float lifeTime = 5.0f;
    public static bool active = false;

  

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector2.Distance(transform.position, FPoint.position);

        if (active)//Active
        {
            Color.invisable = true;
           // GameObject clone;
           // clone = Instantiate(Shield, FPoint.position, FPoint.rotation);
        
          //  StartCoroutine(WaitThenDie(clone));


            active = false;
           // Color.invisable = false;

        }

    }

    IEnumerator WaitThenDie(GameObject CLONE)
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(CLONE);
    }
}
