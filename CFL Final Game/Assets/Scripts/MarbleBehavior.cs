using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleBehavior : MonoBehaviour
{
    public float moveSpeed = 25f;
    public float rotateSpeed = 45f;
    public float jumpVelocity = 5f;
    public float distanceToGround = 0.1f;
    public LayerMask groundLayer;

    public GameObject blast;
    public float blastSpeed = 100f;
    
    private float fbInput;
    private float lrInput;

    
    private Rigidbody _rb;

    private CapsuleCollider _col;
    
    void Start()
    {
        //You'll need to add a rigidbody to the marble first
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        fbInput = Input.GetAxis("Vertical") * moveSpeed;
        lrInput = Input.GetAxis("Horizontal") * rotateSpeed;
        
        this.transform.Translate(Vector3.forward * fbInput * Time.deltaTime);
        this.transform.Rotate(Vector3.up * lrInput * Time.deltaTime);
        
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space)) {
            _rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
        }
    }
    
    void FixedUpdate()
    {
        fbInput = Input.GetAxis("Vertical") * moveSpeed;
        lrInput = Input.GetAxis("Horizontal") * rotateSpeed;

        Vector3 rotation = Vector3.up * fbInput;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);
       
        _rb.MovePosition(this.transform.position + this.transform.forward * fbInput * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation * angleRot);
   
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newBlast = Instantiate(blast, this.transform.position, this.transform.rotation) as GameObject;

            Rigidbody blastRB = newBlast.GetComponent<Rigidbody>();

            blastRB.velocity = this.transform.forward * blastSpeed;
        }
    }

    private bool IsGrounded()
    {
        Vector3 capsuleBottom = new Vector3(_col.bounds.center.x, _col.bounds.min.y, _col.bounds.center.z);
        bool grounded = Physics.CheckCapsule(_col.bounds.center, capsuleBottom, distanceToGround, groundLayer, QueryTriggerInteraction.Ignore);

        return grounded;
    }
    
}
