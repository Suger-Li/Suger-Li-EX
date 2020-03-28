using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float MoveSpeed = 0;

    [SerializeField]
    private float JumpPower = 0;

    private Rigidbody rb;
    //private bool Grounded;
    private int jumpCount;

    private Animator anim;
    private bool MoveStop;
    private AnimatorStateInfo stateinfo;

    public GameObject AttackPoint;
    public string AttackPointTag;

    public KeyCode LeftKey;
    public KeyCode RightKey;
    public KeyCode JumpKey;
    public KeyCode AttackKey;
    public KeyCode AttackKey2;

    public Text HP;
    private int PlayerHP;

    private Collider PlayerCollider;

    public GameObject WinText;
    public GameObject Explosion;

    public GameObject EngergyBall;
    public Vector3 force;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        AttackPoint.SetActive(false);
        WinText.SetActive(false);
        jumpCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        HP.text = PlayerHP.ToString();
        if (MoveStop == false)
        {
            if (Input.GetKey(LeftKey))
            {
                transform.rotation = Quaternion.Euler(0, -90, 0);
                transform.position += new Vector3(-10 * MoveSpeed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(RightKey))
            {
                transform.rotation = Quaternion.Euler(0, 90, 0);
                transform.position += new Vector3(10 * MoveSpeed * Time.deltaTime, 0, 0);
            }
        }
        if(Input.GetKeyDown(JumpKey))
        {
           /* if(Grounded)
            {
                Grounded = false;
                rb.AddForce(Vector3.up * JumpPower);
            }
            */
            if(jumpCount <= 1)
            {
                rb.AddForce(Vector3.up * JumpPower);
                jumpCount += 1;
            }
        }
        if(Input.GetKey(LeftKey) || Input.GetKey(RightKey))
        {
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }

        if(Input.GetKeyDown(AttackKey))
        {
            anim.SetBool("Attack", true);
        }
        else
        {
            anim.SetBool("Attack", false);
        }
        stateinfo = anim.GetCurrentAnimatorStateInfo(0);
        if (stateinfo.IsName("Base Layer.Attack"))
        {
            MoveStop = true;
            AttackPoint.SetActive(true);
        }
        else
        {
            MoveStop = false;
            AttackPoint.SetActive(false);
        }

        if(transform.position.x <= -12 || transform.position.x >=12)
        {
            Destroy(gameObject);
            WinText.SetActive(true);
            Instantiate(Explosion.gameObject, transform.position, Quaternion.identity);
        }

        if(Input.GetKeyDown(AttackKey2))
        {
            GameObject EnergyBalls = GameObject.Instantiate(EngergyBall) as GameObject;
            EnergyBalls.transform.position = transform.position + new Vector3(0, 2, 0);
            EnergyBalls.transform.rotation = transform.rotation;
            force = transform.forward * 1000;
            EnergyBalls.GetComponent<Rigidbody>().AddForce(force);
            Destroy(EnergyBalls.gameObject, 2);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            //Grounded = true;
            jumpCount = 0;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == AttackPointTag)
        {
            PlayerHP += 10;

            if(PlayerHP < 100)
            {
                Vector3 KnockBackForce;
                KnockBackForce = transform.forward * PlayerHP / -2;
                rb.AddForce(KnockBackForce);
            }
            if (PlayerHP >= 100)
            {
                Vector3 KnockBackForce;
                KnockBackForce = transform.forward * PlayerHP / -2*50;
                rb.AddForce(KnockBackForce);
                PlayerCollider.enabled = false;
            }
        }
    }
}
