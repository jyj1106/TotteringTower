using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float spd = 5f;
    public float jumpforce = 300f;
    public float distance = 0.8f;
    public bool doublejump = true;
    Vector2 boxSize = new Vector2(0.4f, 0.05f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(-spd * Time.deltaTime, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(spd * Time.deltaTime, 0f, 0f);
        }

        bool onground = isLanding();

        if (Input.GetKeyDown(KeyCode.Space) && onground == true)
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpforce));
        }
        else if (Input.GetKeyDown("space") && doublejump)
        {
            doublejump = false;
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpforce));
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && onground == true)
        {
            this.gameObject.layer = 7;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            spd = 15f;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            spd = 5f;
        }

        isLanding();
    }

    bool isLanding()
    {
        // RaycastHit2D raycastHit = Physics2D.Raycast(this.transform.position, Vector2.down, distance, LayerMask.GetMask("Floor"));

        RaycastHit2D raycastHit = Physics2D.BoxCast(this.transform.position, boxSize, 0f, Vector2.down, distance, LayerMask.GetMask("Floor"));

        if(raycastHit.collider != null)
        {
            if(raycastHit.collider.tag == "Ground")
            {
                doublejump = true;
                return true;
            }
        }
        else
        {
            this.gameObject.layer = 6;
        }

        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(this.transform.position, Vector2.down * distance);
        Gizmos.DrawWireCube(this.transform.position + Vector3.down * distance, boxSize);
    }
}
