using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mofesto : MonoBehaviour {

    [SerializeField]
    Transform mTarget;
    [SerializeField]
    float mFollowSpeed;

    float mFollowRange = 3;
    float monsterAttack = 7;
    //[SerializeField]
    //float UtyRange;

   
    float UtyRange = 20f;

    float mArriveThreshold = 0.05f;
    public float Elife = 5;

   

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


            
            if (distance < mFollowRange && Input.GetButtonDown("Attack"))
            {
                NormalAttack.Play();

                enemylife(0.2f);

            }

            if (distance < monsterAttack)
            {
                Vector3 directionTOGO = mTarget.position - transform.position;
                directionTOGO.Normalize();
                transform.position += directionTOGO * Time.deltaTime * mFollowSpeed;


            }





        }


    }





    public void enemylife(float life)
    {
       

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
        SceneManager.LoadScene("END");

    }

    void OnTriggerStay2D(Collider2D col)
    {
        // TODO: Check if it's Mega Man (ignore everything else)
        //       If it is Mega Man, make him take some damage (e.g. 3 points)
        //       Use the TakeDamage() function from the MegaMan class!
        //       Check DeathZone.cs for an example of what to do !~

        if (col.gameObject.layer == LayerMask.NameToLayer("player"))
        {
            col.GetComponent<Player>().Takedamage(0.21 * Time.deltaTime);
        }
    }

    public void SetTarget(Transform target)
    {
        mTarget = target;
    }
}
