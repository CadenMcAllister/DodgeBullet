using UnityEngine;

public class Hit : MonoBehaviour
{

    public LogicScript logic;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    private void OnCollision(Collider2D collision){
        if (collision.gameObject.tag == "EnemyProjectiles"){
            logic.restarGame();
        }
    }
}
