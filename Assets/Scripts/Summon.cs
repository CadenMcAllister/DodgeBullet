using UnityEngine;
using UnityEngine.UI;
public class Summon : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileForce = 10f;

    public GameObject target;
    private Rigidbody2D rb;
    private Vector3 offset;

    public Text Ammo;
    public float ammoCounter = 7f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update(){
    
    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    mousePos.z = 0f;
        if (ammoCounter > 0f){
            if (Input.GetMouseButtonDown(0)){
            // Create a new instance of the projectile prefab at the Mouse position
            GameObject newProjectile = Instantiate(projectilePrefab, mousePos, transform.rotation);
            Rigidbody2D rb = newProjectile.GetComponent<Rigidbody2D>();

            // Calculate the direction to the player
            Vector2 directionToTarget = (target.transform.position - transform.position).normalized;
            
            rb.AddForce(directionToTarget * projectileForce, ForceMode2D.Impulse);

            ammoCounter -= 1;
            }
        }
        Ammo.text = ammoCounter.ToString(); 
    }
}
