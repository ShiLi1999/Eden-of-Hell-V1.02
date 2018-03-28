using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour {

    // Variables set in the inspector
    public float WalkSpeed = 3;
    public float RunSpeed = 5;
    public float JumpForce = 300;
    public Image healthIMG;
    public Image EnduranceIMG;
    public Image ManaIMG;
    public Image QIMG;
    public Image WIMG;
    public Image EIMG;
    public Image RIMG;
    public int nerverchange = 1;


    public float cooldownone;
    public float Health = 1;
    public float Endurance = 1;
    public float Mana = 1;
    private float starTime;

    // Booleans used to coordinate with the animator's state machine
    bool Running;
    bool Moving;
    bool Grounded;
    bool Falling;
    
    float kDamagePushForce = 2.5f;
    float InvincibleTimer;
    float InvincibilityDuration = 3.5f;
    

    public float Fcooldown = 7;
    public float Scooldown = 22;
    public float Tcooldown = 3;
    public float FOcooldown = 75;

    bool Fiscooldown = false;
    bool Siscooldown = false;
    bool Tiscooldown = false;
    bool FOiscooldown = false;

    bool invencible = false;


    // References to other components (can be from other game objects!)
    // AudioSource Gothit;
    Animator Animator;
    Rigidbody2D RigidBody2D;
    Vector2 mFacingDirection;

    AudioSource BGM;
    AudioSource Light;
    AudioSource Freezy;
    AudioSource sacrify;
    AudioSource doom;
    AudioSource Hurt;
    
    

    [SerializeField]
    GameObject mDeathParticleEmitter;
    Rigidbody2D mRigidBody2D;

    





    void Start()
    {
        
        // Get references to other components and game objects
        RigidBody2D = GetComponent<Rigidbody2D>();
        // TODO: Get Animator Reference
        Animator = GetComponent<Animator>();
        mFacingDirection = Vector2.right;
        mRigidBody2D = GetComponent<Rigidbody2D>();

        AudioSource[] audioSources = GetComponents<AudioSource>();
        //  BusterShoot = audioSources[0];
        //  Gothit = audioSources[1];
        BGM = audioSources[0];
        Light = audioSources[1];
        Freezy = audioSources[2];
        sacrify = audioSources[3];
        doom = audioSources[4];
        Hurt = audioSources[5];
        

        BGM.Play();
    }

    void Update()
    {
        MoveCharacter();
        CheckFalling();
        CheckGrounded();

        /*
        // Update animator's variables
        Animator.SetBool("isRunning", Running);
        Animator.SetBool("isMoving", Moving);
        // TODO: Set Animator for Grounded
        Animator.SetBool("isGrounded", Grounded);
        // TODO: Set Animator for Falling
        Animator.SetBool("isFalling", Falling);
        */
        ManaIMG.fillAmount = Mana;

        if (invencible)
        {
            InvincibleTimer += Time.deltaTime;
            if (InvincibleTimer >= InvincibilityDuration)
            {
                invencible = false;
                InvincibleTimer = 0.0f;
            }
        }

    }

    



    private void MoveCharacter()
    {

        // Check if we are running or not
        Running = Input.GetButton("Run"); //returns true or false if pressed.    

        // Determine movement speed
        float moveSpeed = Running ? RunSpeed : WalkSpeed;
        //Change value    (  IF   )    TRUE    :   FALSE   ;

        // Check for movement
        Moving = Input.GetButton("Horizontal"); //returns true or false if pressed.
        float direction = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(direction, 0, 0) * moveSpeed * Time.deltaTime;
        FaceDirection(new Vector2(direction, 0));

        //Regenerate Endurance
        if (Endurance < 1 && Moving)
        {
            Endurance += (float)0.02 * Time.deltaTime;           
            EnduranceIMG.fillAmount = Endurance;
            //EnduranceChange.EnduranAmount = Endurance * 100;
        }
        if (Endurance < 1 && Grounded)
        {
            Endurance += (float)0.05 * Time.deltaTime;            
            EnduranceIMG.fillAmount = Endurance;
            //EnduranceChange.EnduranAmount = Endurance * 100;
        }


        //Regenerate Mana
        if (Mana < 1 )
        {
            Mana += (float)0.01 * Time.deltaTime;
            ManaIMG.fillAmount = Mana;
        }
        

        //Regenerate Health
        if (Health < 1)
        {
            Health += (float)0.002 * Time.deltaTime;
            healthIMG.fillAmount = Health;
        }

        // Check for running
        if (Running && Input.GetButton("Horizontal") && Endurance>0)
        {
            
            transform.position += new Vector3(direction, 0, 0) * RunSpeed * Time.deltaTime;
            FaceDirection(new Vector2(direction, 0));
            Endurance -= (float)0.01;
            //EnduranceChange.EnduranAmount= Endurance;
            EnduranceIMG.fillAmount = Endurance;
            
        }

        

        // Check if we can jump
        if (Grounded && Input.GetButtonDown("Jump"))
        {
            RigidBody2D.AddForce(Vector2.up * JumpForce);
        }


        



        //Skills for the player
        //Skill 1 Redemption
        if (Grounded && Input.GetButton("Skill1") && !Fiscooldown && Mana >= 0.15)
        {
            
            Takedamage(-0.25);
            ManaReduce(0.15);
            QIMG.fillAmount = 1;
            Fiscooldown = true;
            RedemptionEffect.active = true;
            Light.Play();
        }
        if(Fiscooldown)
        {
            QIMG.fillAmount -= 1 / Fcooldown * Time.deltaTime;
            if( QIMG.fillAmount == 0)
            {
                Fiscooldown = false;
            }
        }


        //Skill 2 Fanaticism
        if (Grounded && Input.GetButton("Skill2") && !Siscooldown && Mana >= 0.30)
        {
            
            invencible = true;          
            ManaReduce(0.30);
            WIMG.fillAmount = 1;
            Siscooldown = true;
            FanaticismEffect.active = true;
            Freezy.Play();
        }
        if(Siscooldown)
        {
            WIMG.fillAmount -= 1 / Scooldown * Time.deltaTime;
            if( WIMG.fillAmount == 0)
            {
                Siscooldown = false;
            }
        }


        //Skill 3 Sacrifise
        if (Grounded && Input.GetButton("Skill3") && !Tiscooldown && Health>0.3)
        {
            Rcolor.invisable = true;
            blackSoul.skill3 = true;
            StormMage.skill3 = true;
            Warith.skill3 = true;
            EIMG.fillAmount = 1;
            Takedamage(0.3);
            Tiscooldown = true;
            sacrify.Play();
          
        }
        if(Tiscooldown)
        {
           
           
            EIMG.fillAmount -= 1 / Tcooldown * Time.deltaTime;
            if (EIMG.fillAmount == 0)
            {
                Tiscooldown = false;
                
            }
        }


        //Skill 4 Desolation
        if (Grounded && Input.GetButton("Skill4") && !FOiscooldown && Mana >= 0.80)
        {
            ManaReduce(0.8);
            DesolationEff.invisable = true;
            blackSoul.skill4 = true;
            StormMage.skill4 = true;
            Knife.skill4 = true;
            RIMG.fillAmount = 1;
            FOiscooldown = true;
            doom.Play();
        }
        if(FOiscooldown)
        {
            RIMG.fillAmount -= 1 / FOcooldown * Time.deltaTime;
            if (RIMG.fillAmount == 0)
            {
                FOiscooldown = false;
            }
        }



    }

   



    private void CheckFalling()
    {
        Falling = RigidBody2D.velocity.y < 0.0f;
    }

    private void CheckGrounded()
    {
        Grounded = RigidBody2D.velocity.y == 0.0f;
    }

    private void FaceDirection(Vector2 direction)
    {
        if (direction == Vector2.zero)  //Don't change look.
            return;

        // Flip the sprite (NOTE: Vector3.forward is positive Z in 3D. The Sprite is on XY plane!)
        Quaternion rotation3D = direction == Vector2.right ? Quaternion.LookRotation(Vector3.forward) : Quaternion.LookRotation(Vector3.back);
        transform.rotation = rotation3D;
    }

    public void Takedamage(double dmg)
    {
        if ( !invencible )
        {
            if (Health > 1)
            {
                Health = 1;
            }
            Hurt.Play();
            /* Vector2 forceDirection = new Vector2(-mFacingDirection.x, 1.0f) * kDamagePushForce;
             mRigidBody2D.velocity = Vector2.zero;
             mRigidBody2D.AddForce(forceDirection, ForceMode2D.Impulse);*/   //Push back when got hurt


            Health -= (float)dmg;
            healthIMG.fillAmount = Health;

            if (Health <= 0)
                Die();
        }
        
      
    }

   


    public void ManaReduce(double reduce)
    {
        Mana -= (float)reduce;
        ManaIMG.fillAmount = Mana;
    }


    

    public void Die()
    {
        Instantiate(mDeathParticleEmitter, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}