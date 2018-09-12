using System;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Animator Animator;
    public float WalkSpeed;
    public float RunSpeed;

    private float _Speed;
    private Rigidbody2D _Rigidbody;
    private int _QtdeJump;
	// Use this for initialization
	void Start ()
	{
	    _QtdeJump = 0;
	    _Speed = WalkSpeed;
	    _Rigidbody = gameObject.GetComponent<Rigidbody2D>();
        _Rigidbody.freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update ()
	{

	    if (Input.GetKey(KeyCode.A))
	        _MoveLeft();
        else if (Input.GetKey(KeyCode.D))
	        _MoveRight();
        else
	        Animator.SetInteger("move", 0);

        if (Input.GetKeyDown(KeyCode.Space))
	        _Jump();
	}
    void _MoveLeft()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Animator.SetInteger("move", 2);
            _Speed = RunSpeed;
        }
        else
        {
            Animator.SetInteger("move", 1);
            _Speed = WalkSpeed;
        }
        transform.rotation = Quaternion.Euler(0, 180f, 0);
        transform.position += (Vector3.left * _Speed) * Time.deltaTime;
    }
    void _MoveRight()
    {
        if (Input.GetKey(KeyCode.LeftShift) && !Animator.GetBool("jump"))
        {
            Animator.SetInteger("move", 2);
            _Speed = RunSpeed;
        }
        else
        {
            Animator.SetInteger("move", 1);
            _Speed = WalkSpeed;
        }

        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.position += (Vector3.right * _Speed) * Time.deltaTime;
    }

    void _Jump()
    {
        if (_QtdeJump == 2) return;
        _QtdeJump++;
        Animator.SetBool("jump", true);
        _Rigidbody.AddForce(Vector2.up * 4.5f, ForceMode2D.Impulse);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "scene")
        {
            if (Math.Abs(collision.collider.bounds.max.y - GetComponent<BoxCollider2D>().bounds.min.y) <= 0.1)
            {
                Animator.SetBool("jump", false);
                _QtdeJump = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "death")
        {
            Animator.SetBool("damage", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Animator.SetBool("damage", false);
    }
}
