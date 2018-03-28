using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour {


    [SerializeField]
    Transform mTarget;
    [SerializeField]
    float mFollowSpeed;

    float mFollowRange = 3;
    //[SerializeField]
    //float UtyRange;

    public static bool skill3 = false;
    public static bool skill4 = false;

    float UtyRange = 20f;

    float mArriveThreshold = 0.05f;
    public float Elife = 0.6f;

    float InvincibleTimer;
    float InvincibilityDuration = 2.0f;

    AudioSource NormalAttack;
    AudioSource Takedamage;

    void Start()
    {


        AudioSource[] audioSources = GetComponents<AudioSource>();

        NormalAttack = audioSources[0];
        Takedamage = audioSources[1];

    }


    void Update()
    {
        if (mTarget != null)
        {
            // TODO: Make the enemy follow the target "mTarget"
            //       only if the target is close enough (distance smaller than "mFollowRange")
            float distance = Vector2.Distance(transform.position, mTarget.position);


            if (distance >= mFollowRange)
            {
                skill3 = false;
            }
            else if (distance < mFollowRange && Input.GetButtonDown("Attack"))
            {
                NormalAttack.Play();

                enemylife(0.2f);

            }

            else if (distance < mFollowRange && skill3)
            {
                enemylife(1.5f);

            }

            if (distance >= UtyRange)
            {
                skill4 = false;
            }

            else if (distance < UtyRange && skill4)
            {


                InvincibleTimer += Time.deltaTime;
                if (InvincibleTimer >= InvincibilityDuration)
                {
                    //skill4 = false;
                    InvincibleTimer = 0.0f;
                    enemylife(5.0f);
                }

            }



        }


    }





    public void enemylife(float life)
    {
        //skill3 = false;

        Takedamage.Play();
        Elife = Elife - life;

        if (Elife <= 0)
        {
            Edie();
        }
    }

    public void Edie()
    {
        Destroy(gameObject);
    }

    void OnTriggerStay2D(Collider2D col)
    {
        // TODO: Check if it's Mega Man (ignore everything else)
        //       If it is Mega Man, make him take some damage (e.g. 3 points)
        //       Use the TakeDamage() function from the MegaMan class!
        //       Check DeathZone.cs for an example of what to do !~

        if (col.gameObject.layer == LayerMask.NameToLayer("player"))
        {
            col.GetComponent<Player>().Takedamage(0.16 * Time.deltaTime);
        }
    }

    public void SetTarget(Transform target)
    {
        mTarget = target;
    }
}
