using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
public class jumpingwithjohn : MonoBehaviour
{   
    public float turnSpeed = 20;
    public float moveSpeed = 1f;
    public float JumpForce = 10f;
    public float GravityModifier = 1f;
    public float outOfBounds = -10f;
    public bool IsOnGround = true;
    public Transform checkPointAreaObject;
    public bool isAtCheckpoint;
    public GameObject 
    private Vector3 _movement;
    //private Animator _animator; 
    private Quaternion _rotation = Quaternion.identity;
    private Vector3 _defaultGravity = new Vector3(0f, -9.81f, 0f);
    private Vector3 _startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        //_animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        //Physics.gravity = _defaultGravity;
        Physics.gravity *= GravityModifier;
        Debug.Log(Physics.gravity);
        //Debug.Log(Physics.gravity);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && IsOnGround)
        {
            _rigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            IsOnGround = false;
        }

        if(transform.position.y < outOfBounds)
        {
            transform.position = _startingPostion;
        }
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        _movement.Set(horizontal, 0f, vertical);
        _movement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately (horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately (vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        //m_Animator.SetBool ("IsWalking", isWalking);

        Vector3 desiredForward = Vector3.RotateTowards (transform.forward, _movement, turnSpeed * Time.deltaTime, 0f);
        _rotation = Quaternion.LookRotation (desiredForward);

        _rigidbody.MovePosition (_rigidbody.position + _movement * moveSpeed * Time.deltaTime);
        _rigidbody.MoveRotation (_rotation);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsOnGround = true;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == checkPointAreaObject)
        {
            isAtCheckpoint = true;
            //Debug.Log(_startingPosition);
            _startingPosition = checkPointAreaObject.transform.position;
            //Debug.Log(_startingPosition);
        }
    }
}
