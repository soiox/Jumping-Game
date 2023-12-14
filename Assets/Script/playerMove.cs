using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1f;
    [SerializeField]
    private float JumpHit = 1f;
    private Vector2 vec2;
    private bool onJump = true;
    private Rigidbody2D rig;
    private float timer;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKey(KeyCode.Space) && (!onJump))
        {
            onJump = true;
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 100 * JumpHit);
            
        }
        vec2 = new Vector2((Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed) + transform.position.x,transform.position.y);
        transform.position = (vec2);
        if(transform.position.y < -7.5f)
        {
            transform.position = new Vector3(0f,5f,0f);
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }
    void FixedUpdate()
    {
        if (rig.velocity.y == 0)
        {
            timer = 0.0f;
            while (true)
            {
                timer += Time.deltaTime;
                if(timer > 0.2f && rig.velocity.y == 0)
                {
                    break;
                }
            }
            onJump = false;
        }
    }
}
