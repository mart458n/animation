using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript: MonoBehaviour
{
    public float maxSpeed = 10.0f;
    public bool faceRight = true;

    Animator anim;
    private Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("movementSpeed", Mathf.Abs(move));
        rigid.velocity = new Vector2(move * maxSpeed, rigid.velocity.y);

        if((move > 0 && !faceRight) || (move < 0 && faceRight)) 
        {
            FlipFacing();
        }
    }

    void FlipFacing() 
    {
        faceRight = !faceRight;
        Vector3 charScale = transform.localScale;
        charScale.x = -1 * charScale.x;
        transform.localScale = charScale;
    }
}
