using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public LogicScript logic;
    public float volumeScale = 1f;
    public AudioClip jump;
    public AudioSource audioSource;
    public GameObject Player;
    public Rigidbody2D rb;
    public float speed;
    private float horizontal;
    [SerializeField]
    private float jumpingPower = 5f;
    [SerializeField]
    private LayerMask groundLayer;
    public GameObject groundCheck;
    [SerializeField]
    private BoxCollider2D coll;
    [SerializeField]
    private float maxSpeed = 200f;
        
    void Start(){
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }
        //uses a raycast to determine if the player has terrain of the ground layer below themselves
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, groundLayer);
    }

    //check if the player is going faster the the max speed and clamps that down to the max speed
    public void Update(){    

        if (rb.velocity.magnitude > maxSpeed){
            rb.velocity = Vector2.ClampMagnitude (rb.velocity, maxSpeed);
        }

    if (Input.GetKeyDown(KeyCode.LeftShift)){
        Time.timeScale = 0.5f; // Slow down time if the player is pressing down on left shift
    }

    if (Input.GetKeyUp(KeyCode.LeftShift)){
        Time.timeScale = 1f; // Returns time to normal
    }

    horizontal = Input.GetAxisRaw("Horizontal");

    if (Input.GetButtonDown("Jump") && IsGrounded())
    {
        audioSource.PlayOneShot(jump, 2f);        
        rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
    }

    if (Input.GetButtonUp("Jump") && rb.velocity.y == 0f)
    {
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.1f);
    }

    rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);


    }

    private void OnTriggerEnter2D(Collider2D collider){

        if (collider.gameObject.name == "ScoreCollider(Clone)"){
            logic.addScore(1);
        }

    }
}



