using UnityEngine;
using System.Collections;

public class HeroKnight : MonoBehaviour {

    [SerializeField] float      m_speed = 4.0f;
    [SerializeField] float      m_jumpForce = 7.5f;
    [SerializeField] float      m_rollForce = 6.0f;
    [SerializeField] GameObject m_slideDust;

    private Animator            m_animator;
    private Rigidbody2D         m_body2d;
    private Sensor_HeroKnight   m_groundSensor;
    private Sensor_HeroKnight   m_wallSensorR1;
    private Sensor_HeroKnight   m_wallSensorR2;
    private Sensor_HeroKnight   m_wallSensorL1;
    private Sensor_HeroKnight   m_wallSensorL2;
    private bool                m_grounded = false;
    private bool                m_rolling = false;
    public bool                m_blocking = false;
    private bool                m_blockOn = false;
    private bool                m_doublejump = true;
    public bool                Inputtable = true;
    private int                 m_facingDirection = 1;
    private int                 m_currentAttack = 0;
    private float               m_timeSinceAttack = 0.0f;
    private float               m_blockingCool = 0f;
    private float               m_timeSinceBlock = 2.0f;
    private float               m_delayToIdle = 0.0f;
    private bool                disPAttack1, disPAttack2 = false;

    public GameObject PAttack1, PAttack2;
    public static bool isSlash = false;

    // Use this for initialization
    void Start ()
    {
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
        m_groundSensor = transform.Find("GroundSensor").GetComponent<Sensor_HeroKnight>();
        m_wallSensorR1 = transform.Find("WallSensor_R1").GetComponent<Sensor_HeroKnight>();
        m_wallSensorR2 = transform.Find("WallSensor_R2").GetComponent<Sensor_HeroKnight>();
        m_wallSensorL1 = transform.Find("WallSensor_L1").GetComponent<Sensor_HeroKnight>();
        m_wallSensorL2 = transform.Find("WallSensor_L2").GetComponent<Sensor_HeroKnight>();
    }

    // Update is called once per frame
    void Update ()
    {
        // Increase timer that controls attack combo and static time
        m_timeSinceAttack += Time.deltaTime;
        m_timeSinceBlock += Time.deltaTime;
        m_blockingCool += Time.deltaTime;

        //Check if character just landed on the ground
        if (!m_grounded && m_groundSensor.State())
        {
            m_grounded = true;
            m_animator.SetBool("Grounded", m_grounded);
            m_doublejump = true;
        }

        //Check if character just started falling
        if (m_grounded && !m_groundSensor.State())
        {
            m_grounded = false;
            m_animator.SetBool("Grounded", m_grounded);
        }

        // -- Handle input and movement --
        float inputX = Input.GetAxis("Horizontal");

        // Swap direction of sprite depending on walk direction
        if (!m_rolling && !m_blockOn && m_timeSinceBlock >= 0.75f)
        {
            if (inputX > 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
                m_facingDirection = 1;
            }

            else if (inputX < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
                m_facingDirection = -1;
            }
        }

        // Move
        if (!m_rolling && !m_blockOn && m_timeSinceBlock >= 0.75f && Inputtable == true)
        {
            m_body2d.velocity = new Vector2(inputX * m_speed, m_body2d.velocity.y);
        }

        //Set AirSpeed in animator
        m_animator.SetFloat("AirSpeedY", m_body2d.velocity.y);

        // -- Handle Animations --
        //Wall Slide
        m_animator.SetBool("WallSlide", (m_wallSensorR1.State() && m_wallSensorR2.State()) || (m_wallSensorL1.State() && m_wallSensorL2.State()));

        //Attack
        if (Input.GetKeyDown(KeyCode.Z) && m_timeSinceAttack > 0.25f && !m_rolling && !m_blocking && !m_blockOn && m_timeSinceBlock >= 0.75f)
        {
            m_blocking = false;
            m_currentAttack++;

            // Loop back to one after third attack
            if (m_currentAttack > 3)
                m_currentAttack = 1;

            // Reset Attack combo if time since last attack is too large
            if (m_timeSinceAttack > 1.0f)
                m_currentAttack = 1;

            // Call one of three attack animations "Attack1", "Attack2", "Attack3"
            m_animator.SetTrigger("Attack" + m_currentAttack);

            // Reset timer
            m_timeSinceAttack = 0.0f;
        }

        // Block
        else if (Input.GetKeyDown(KeyCode.V) && !m_rolling && GameManager.mana > 1  && !m_blocking && !m_blockOn && m_timeSinceBlock >= 0.75f && m_blockingCool >= 1f)
        {
            PAttack1.SetActive(false);
            PAttack2.SetActive(false);
            m_animator.SetTrigger("Block");
            m_animator.SetBool("IdleBlock", false);
            GameManager.mana--;
        }

        else if (Input.GetKeyDown(KeyCode.V))
            m_animator.SetBool("IdleBlock", false);

        // Roll
        else if (Input.GetKeyDown(KeyCode.LeftShift) && !m_rolling && GameManager.mana > 1 && !m_blocking && !m_blockOn && m_timeSinceBlock >= 0.75f)
        {
            Inputtable = true;
            m_rolling = true;
            m_animator.SetTrigger("Roll");
            m_body2d.velocity = new Vector2(m_facingDirection * m_rollForce, m_body2d.velocity.y);
            GameManager.mana--;
            this.gameObject.tag = "Untagged";
        }
            

        //Jump
        else if (Input.GetKeyDown(KeyCode.C) && m_grounded && !m_rolling && !m_blocking && !m_blockOn && m_timeSinceBlock >= 0.75f)
        {
            Inputtable = true;
            m_animator.SetTrigger("Jump");
            m_grounded = false;
            m_animator.SetBool("Grounded", m_grounded);
            m_body2d.velocity = new Vector2(m_body2d.velocity.x, m_jumpForce);
            m_groundSensor.Disable(0.2f);
        }

        //Double Jump
        else if (Input.GetKeyDown(KeyCode.C) && m_doublejump && !m_rolling && !m_blocking && !m_blockOn && m_timeSinceBlock >= 0.75f)
        {
            Inputtable = true;
            m_animator.SetTrigger("DoubleJump");
            m_doublejump = false;
            m_body2d.velocity = new Vector2(m_body2d.velocity.x, m_jumpForce);
        }

        //Run
        else if (Mathf.Abs(inputX) > Mathf.Epsilon)
        {
            // Reset timer
            m_delayToIdle = 0.05f;
            m_animator.SetInteger("AnimState", 1);
        }

        //Idle
        else
        {
            // Prevents flickering transitions to idle
            m_delayToIdle -= Time.deltaTime;
                if(m_delayToIdle < 0)
                    m_animator.SetInteger("AnimState", 0);
        }
    }

    // Animation Events
    // Called in end of roll animation.
    void AE_ResetRoll()
    {
        m_rolling = false;
        this.gameObject.tag = "Player";
    }

    // Called in slide animation.
    void AE_SlideDust()
    {
        Vector3 spawnPosition;

        if (m_facingDirection == 1)
            spawnPosition = m_wallSensorR2.transform.position;
        else
            spawnPosition = m_wallSensorL2.transform.position;

        if (m_slideDust != null)
        {
            // Set correct arrow spawn position
            GameObject dust = Instantiate(m_slideDust, spawnPosition, gameObject.transform.localRotation) as GameObject;
            // Turn arrow in correct direction
            dust.transform.localScale = new Vector3(m_facingDirection, 1, 1);
        }
    }

    //"Death and Hurt" Animation & System + Blocking System and Animation
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EAttack"))
        {
            if(m_blocking == true)
            {
                m_animator.SetTrigger("BlockingOn");
                m_blocking = false;
                collision.gameObject.transform.parent.GetComponent<Monster>().hp--;
            }
            else
            {
                GameManager.hp--;
                if (!(GameManager.hp <= 0) && !m_rolling)
                {
                    m_animator.SetTrigger("Hurt");
                    PAttack1.SetActive(false);
                    PAttack2.SetActive(false);
                    m_blocking = false;
                    m_blockOn = false;
                }
                else if (GameManager.hp <= 0)
                {
                    m_animator.SetTrigger("Death");
                    PAttack1.SetActive(false);
                    PAttack2.SetActive(false);
                }
            }
        }
    }
    
    void PAttack_Active()
    {
        if (GetComponent<SpriteRenderer>().flipX == true)
        {
            PAttack2.SetActive(true);
            disPAttack2 = true;
        }
        else if (GetComponent<SpriteRenderer>().flipX == false)
        {
            PAttack1.SetActive(true);
            disPAttack1 = true;
        }
    }
    void PAttack_Hide()
    {
        if (disPAttack2 == true)
        {
            disPAttack2 = false;
            PAttack2.SetActive(false);
        }
        else if (disPAttack1 == true)
        {
            disPAttack1 = false;
            PAttack1.SetActive(false);
        }
    }

    void Block_Start()
    {
        if(m_blockingCool >= 1f)
        {
            Inputtable = false;
            m_blocking = true;
            Debug.Log("true");
        }
    }
    void Block_End()
    {
        m_blocking = false;
        Inputtable = true;
        m_blockingCool = 0f;
        m_animator.SetTrigger("BlockingEnd");
    }

    void BlockOn_Start()
    {
        m_timeSinceBlock = 0f;
        m_blockOn = true;
        m_blocking = false;
    }
    void BlockOn_End()
    {
        m_blockOn = false;
        Inputtable = true;
    }

    void SoundPlay()
    {
        isSlash = true;
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SlashSnd();
    }
}
