using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(0, 0, 10);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(0, 0, -10);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(-10, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(10, 0, 0);
        }
        if (transform.position.y<-10)
        {
            transform.position = new Vector3(0, 4, 0);
        }
    }
    private void OnCollisionStay(Collision hit)
    {
        if (hit.gameObject.tag == "Enemy")
        {
            transform.position = new Vector3(0, 4, 0);
        }
        if (hit.gameObject.tag == "goal")
        {
            transform.position = new Vector3(0, 0, 65);
        }
    }
}
