using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

    void OnTriggerStay2D(Collider2D col)
    {
        // TODO: Check if it's Mega Man (ignore everything else)
        //       If it is Mega Man, make him take some damage (e.g. 3 points)
        //       Use the TakeDamage() function from the MegaMan class!
        //       Check DeathZone.cs for an example of what to do !~

        if (col.gameObject.layer == LayerMask.NameToLayer("player"))
        {
            col.GetComponent<Player>().Takedamage(0.01 * Time.deltaTime);
        }
    }
}
