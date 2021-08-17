using UnityEngine;
using System.Collections;

public class HeroKnight : MonoBehaviour {

    [SerializeField] float      m_speed = 4.0f;
    [SerializeField] float      m_jumpForce = 7.5f;
    [SerializeField] float      m_rollForce = 6.0f;
    [SerializeField] float      m_plimitX, m_mlimitX;
    [SerializeField] LayerMask Mon_layer;
    [SerializeField] GameObject m_slideDust;
    [SerializeField] GameObject[] Slash = new GameObject[10];
    [SerializeField] GameObject[] MEffects = new GameObject[10];

    public Animator            m_animator;
    private Rigidbody2D         m_body2d;
    private Collider2D[]          PAttack;
    private Sensor_HeroKnight   m_groundSensor;
    private Sensor_HeroKnight   m_wallSensorR1;
    private Sensor_HeroKnight   m_wallSensorR2;
    private Sensor_HeroKnight   m_wallSensorL1;
    private Sensor_HeroKnight   m_wallSensorL2;
    private bool                m_grounded = false;
    public bool                m_attack, isAttack = false;
    public bool                m_rolling = false;
    public bool                m_blocking, m_blockOn = false;
    public bool                hurt_snd = false;
    private bool                m_doublejump, m_triplejump = true;
    public bool                attackable = true;
    public bool                m_dead;
    private int                 m_facingDirection = 1;
    private int                 m_currentAttack = 0;
    private float               m_timeSinceAttack = 0.0f;
    private float               m_blockingCool = 0f;
    private float               m_timeSinceBlock = 2.0f;
    private float               m_delayToIdle = 0.0f;
    private float               m_positionX, inputX, min;
    private int                 target;

    public Vector2 PAttackSize;
    public bool Inputtable = true;

    public static bool isSlash, isHit, isblock= false;

    // Use this for initialization
    void Start ()
    {
        this.transform.Find("PHit").gameObject.layer = 11;
        m_dead = false;
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
        m_groundSensor = transform.Find("GroundSensor").GetComponent<Sensor_HeroKnight>();
        m_wallSensorR1 = transform.Find("WallSensor_R1").GetComponent<Sensor_HeroKnight>();
        m_wallSensorR2 = transform.Find("WallSensor_R2").GetComponent<Sensor_HeroKnight>();
        m_wallSensorL1 = transform.Find("WallSensor_L1").GetComponent<Sensor_HeroKnight>();
        m_wallSensorL2 = transform.Find("WallSensor_L2").GetComponent<Sensor_HeroKnight>();
        PAttack = Physics2D.OverlapBoxAll(new Vector2(this.transform.position.x + 0.75f, this.transform.position.y + 0.75f), PAttackSize, 0, Mon_layer);
    }

    // Update is called once per frame
    void Update ()
    {
        // Increase timer that controls attack combo and static time
        m_timeSinceAttack += Time.deltaTime;
        m_timeSinceBlock += Time.deltaTime;
        m_blockingCool += Time.deltaTime;

        //Check character's position for limit it's movable distance
        m_positionX = this.gameObject.transform.position.x;

        //Check if character just landed on the ground
        if (!m_grounded && m_groundSensor.State())
        {
            m_grounded = true;
            m_animator.SetBool("Grounded", m_grounded);
            m_doublejump = true;
            m_triplejump = true;
        }

        //Check if character just started falling
        if (m_grounded && !m_groundSensor.State())
        {
            m_grounded = false;
            m_animator.SetBool("Grounded", m_grounded);
        }

        // -- Handle input and movement --
        inputX = Input.GetAxis("Horizontal");

        // Swap direction of sprite depending on walk direction
        if (!m_rolling && !m_blockOn && m_timeSinceBlock >= 0.75f && !m_dead)
        {
            if (inputX > 0 && !(m_positionX <= m_mlimitX))
            {
                this.GetComponent<SpriteRenderer>().flipX = false;
                m_facingDirection = 1;
            }
            else if (inputX < 0 && !(m_positionX >= m_plimitX))
            {
                this.GetComponent<SpriteRenderer>().flipX = true;
                m_facingDirection = -1;
            }
        }

        // Move
        if (!m_rolling && !m_blockOn && m_timeSinceBlock >= 0.75f && Inputtable == true && !m_dead)
        {
            if(m_positionX <= m_mlimitX && inputX < 0)
            {
                //Don't move
                m_body2d.velocity = new Vector2(0f, m_body2d.velocity.y);

            }
            else if (m_positionX >= m_plimitX && inputX >0)
            {
                //Don't move
                m_body2d.velocity = new Vector2(0f, m_body2d.velocity.y);
            }
            else
            {
                m_body2d.velocity = new Vector2(inputX * m_speed, m_body2d.velocity.y);
            }

        }

        //Set AirSpeed in animator
        m_animator.SetFloat("AirSpeedY", m_body2d.velocity.y);

        // -- Handle Animations --
        //Wall Slide
        m_animator.SetBool("WallSlide", (m_wallSensorR1.State() && m_wallSensorR2.State()) || (m_wallSensorL1.State() && m_wallSensorL2.State()));

        //Attack
        if (Input.GetKeyDown(KeyCode.Z) && m_timeSinceAttack > 0.25f && !m_rolling && !m_blocking && !m_blockOn && m_timeSinceBlock >= 0.75f && !m_dead)
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

            //Setting PAttack
            if (this.GetComponent<SpriteRenderer>().flipX == false)
            {
                PAttack = Physics2D.OverlapBoxAll(new Vector2(this.transform.position.x + 0.75f, this.transform.position.y + 0.75f), PAttackSize, 0, Mon_layer);
            }
            else if (this.GetComponent<SpriteRenderer>().flipX == true)
            {
                PAttack = Physics2D.OverlapBoxAll(new Vector2(this.transform.position.x - 0.75f, this.transform.position.y + 0.75f), PAttackSize, 0, Mon_layer);
            }

            //Checking Target
            if (PAttack.Length > 0)
            {
                float[] dis = new float[PAttack.Length];
                for (int i = 0; i < PAttack.Length; i++)
                {
                    dis[i] = Vector2.Distance(this.transform.position, PAttack[i].transform.position);
                }
                for (int i = 0; i < PAttack.Length; i++)
                {
                    if (min > dis[i])
                    {
                        min = dis[i];
                        target = i;
                    }
                }
            }
        }

        //OverlapBoxAll(Attack Monster)
        if(!m_rolling && m_attack && !m_blocking && !m_blockOn && m_timeSinceBlock >= 0.75f && !m_dead && m_blockingCool >= 1f && PAttack.Length > 0 && isAttack == true)
        {
            //Checking Multiple Targets or not
            if (GameManager.lvUp == 1)
            {
                PAttack[target].transform.parent.GetComponent<Monster>().hp--;
                PAttack[target].transform.parent.GetComponent<Monster>().colorChange = true;
                PAttack[target].GetComponent<EHit>().isHit = true;
                GameObject effect0 = Instantiate(Slash[0]);
                effect0.transform.parent = null;
                effect0.transform.position = PAttack[target].transform.position;
            }
            else if(GameManager.lvUp == 2)
            {
                for(int i = 0; i < PAttack.Length; i++)
                {
                    PAttack[i].transform.parent.GetComponent<Monster>().hp--;
                    PAttack[i].transform.parent.GetComponent<Monster>().colorChange = true;
                    PAttack[i].GetComponent<EHit>().isHit = true;
                    GameObject effect0 = Instantiate(Slash[0]);
                    effect0.transform.parent = null;
                    effect0.transform.position = PAttack[i].transform.position;
                }
            }
            isAttack = false;
        }

        // Block
        else if (Input.GetKeyDown(KeyCode.V) && !m_rolling && GameManager.mana > 1  && !m_blocking && !m_blockOn && m_timeSinceBlock >= 0.75f && m_blockingCool >= 1f && !m_dead)
        {
            m_animator.SetTrigger("Block");
            m_animator.SetBool("IdleBlock", false);
            GameManager.mana--;
        }

        else if (Input.GetKeyDown(KeyCode.V))
            m_animator.SetBool("IdleBlock", false);

        // Roll
        else if (Input.GetKeyDown(KeyCode.LeftShift) && m_timeSinceAttack > 0.25f && !m_rolling && GameManager.mana > 1 && !m_blocking && !m_blockOn && m_timeSinceBlock >= 0.75f && !m_dead)
        {
                Inputtable = true;
                m_rolling = true;
                m_animator.SetTrigger("Roll");
                m_body2d.velocity = new Vector2(m_facingDirection * m_rollForce, m_body2d.velocity.y);
                GameManager.mana--;
                this.transform.Find("PHit").gameObject.layer = 7;
        }
            

        //Jump
        else if (Input.GetKeyDown(KeyCode.C) && m_timeSinceAttack > 0.25f && m_grounded && !m_rolling && !m_blocking && !m_blockOn && m_timeSinceBlock >= 0.75f && !m_dead)
        {
            Inputtable = true;
            m_animator.SetTrigger("Jump");
            m_grounded = false;
            m_animator.SetBool("Grounded", m_grounded);
            m_body2d.velocity = new Vector2(m_body2d.velocity.x, m_jumpForce);
            m_groundSensor.Disable(0.2f);
        }

        //Double Jump
        else if (Input.GetKeyDown(KeyCode.C) && m_doublejump && !m_rolling && !m_blocking && !m_blockOn && m_timeSinceBlock >= 0.75f && !m_dead)
        {
            Inputtable = true;
            m_animator.SetTrigger("DoubleJump");
            m_doublejump = false;
            m_body2d.velocity = new Vector2(m_body2d.velocity.x, m_jumpForce);
        }

        //Triple Jump
        else if(Input.GetKeyDown(KeyCode.C) && !m_doublejump && m_triplejump && !m_rolling && !m_blocking && !m_blockOn && m_timeSinceBlock >= 0.75f && !m_dead && GameManager.coinUse)
        {
            Inputtable = true;
            m_animator.SetTrigger("TripleJump");
            m_triplejump = false;
            m_body2d.velocity = new Vector2(m_body2d.velocity.x, m_jumpForce);
            GameManager.coinEnd = true;
            GameManager.coinUse = false;
            GameManager.mana--;
        }

        else if (Input.GetKeyDown(KeyCode.Backspace) && m_dead)
        {
            GameManager.hp = 5;
        }

        //Run
        else if (Mathf.Abs(inputX) > Mathf.Epsilon && !(m_positionX >= m_plimitX) && !(m_positionX <= m_mlimitX) && !m_dead)
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

        if(m_rolling == true)
        {
            if (m_positionX >= m_plimitX || m_positionX <= m_mlimitX)
            {
                m_body2d.velocity = new Vector2(0f, m_body2d.velocity.y);
            }
        }
    }

    //"Death and Hurt" Animation & System + Blocking System and Animation
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EAttack"))
        {
            GameObject Mefc0 = Instantiate(MEffects[0]);
            Mefc0.transform.parent = null;
            Mefc0.transform.position = this.transform.Find("Pos").transform.Find("HitEffect_pos").transform.position;

            if (m_blocking == true)
            {
                m_animator.SetTrigger("BlockingOn");
                this.transform.Find("PHit").gameObject.layer = 7;
                m_blocking = false;
                collision.gameObject.transform.parent.GetComponent<Monster>().hp--;
                collision.gameObject.transform.parent.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 0.3f);
                collision.transform.parent.GetComponent<Monster>().colorChange = true;
                GameObject effect1 = Instantiate(Slash[1]);
                effect1.transform.parent = null;
                effect1.transform.position = collision.transform.parent.position;
            }
            else
            {
                GameManager.hp--;
                if (!(GameManager.hp <= 0) && !m_rolling && !m_blockOn)
                {
                    m_animator.SetTrigger("Hurt");
                    m_blocking = false;
                    m_blockOn = false;
                    this.transform.Find("PHit").gameObject.layer = 7;
                    Invoke("InvincibleOff", 0.25f);
                    hurt_snd = true;
                }
                else if (GameManager.hp <= 0)
                {
                    m_blocking = false;
                    m_blockOn = false;
                    m_animator.SetTrigger("Death");
                    m_dead = true;
                    this.transform.Find("PHit").gameObject.layer = 7;
                }
            }
        }
    }

    // Animation Events
    // Called in end of roll animation.
    void AE_ResetRoll()
    {
        m_rolling = false;
        this.transform.Find("PHit").gameObject.layer = 11;
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

    void PAttack_Start()
    {
        m_attack = true;
        isAttack = true;
    }

    void PAttack_End()
    {
        m_attack = false;
        isAttack = false;
    }

    void Block_Start()
    {
        if(m_blockingCool >= 1f)
        {
            Inputtable = false;
            m_blocking = true;
            m_blockingCool = 0f;
        }
    }
    void Block_End()
    {
        m_blocking = false;
        Inputtable = true;
        m_animator.SetTrigger("BlockingEnd");
    }

    void BlockOn_Start()
    {
        m_timeSinceBlock = 0f;
        m_blockOn = true;
        m_blocking = false;
        isblock = true;
        m_body2d.velocity = new Vector2(0f, 0f);
    }
    void BlockOn_End()
    {
        this.transform.Find("PHit").gameObject.layer = 11;
        m_blockOn = false;
        Inputtable = true;
    }

    void SoundPlay()
    {
        isSlash = true;
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SlashSnd();
    }

    void SoundCheckOn()
    {
        if(PAttack.Length > 0)
        {
            isHit = true;
        }
        else
        {
            isHit = false;
        }
    }

    public void InvincibleOff()
    {
        this.transform.Find("PHit").gameObject.layer = 11;
    }

    private void OnDrawGizmos()
    {
        if(this.GetComponent<SpriteRenderer>().flipX == false)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(new Vector2(transform.position.x + 0.75f, transform.position.y + 0.75f), PAttackSize);
        }
        else if (this.GetComponent<SpriteRenderer>().flipX == true)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(new Vector2(transform.position.x - 0.75f, transform.position.y + 0.75f), PAttackSize);
        }
    }
}
