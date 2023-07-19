using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject projectile;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        GameObject projectile = GetComponent<GameObject>();
        Invoke("Destroy", 5);
    }

    void Destroy(){
        Destroy(gameObject);
    }

}
