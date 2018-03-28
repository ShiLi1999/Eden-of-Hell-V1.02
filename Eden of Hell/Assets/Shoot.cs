using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    int Speed = 20;
    public Rigidbody2D Fireball;
    public Transform FPoint;
    AudioSource Firesound;
    private float starTime;

    [SerializeField]
    Transform mTarget;
    [SerializeField]
    float mFollowRange;

    // Use this for initialization
    void Start()
    {

        Firesound = GetComponent<AudioSource>();
        starTime = Time.time;


    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - starTime;
        float seconds = (t % 60);
        int sec = (int)seconds;

        if (mTarget != null)
        {
           
            //       only if the target is close enough (distance smaller than "mFollowRange")
            float distance = Vector2.Distance(transform.position, mTarget.position);

            if (distance < mFollowRange)
            {
                if (sec % 4 == 0)//shoot
                {
                    Rigidbody2D clone;
                    clone = (Rigidbody2D)Instantiate(Fireball, FPoint.position, FPoint.rotation);
                    clone.velocity = transform.TransformDirection(Vector3.left * 10);
                    Firesound.Play();

                }
            }

       


        }

        

    }
}
