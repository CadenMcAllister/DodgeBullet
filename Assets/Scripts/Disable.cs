using UnityEngine;

public class Disable : MonoBehaviour
{
[SerializeField] private PointEffector2D myMagnet;
[SerializeField] private PointEffector2D myMagnet2;

[SerializeField] private PointEffector2D myMagnet3;


    // Start is called before the first frame update
    void Start()
    {
        myMagnet = GetComponent<PointEffector2D>();
        myMagnet2 = GetComponent<PointEffector2D>();
        myMagnet3 = GetComponent<PointEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && myMagnet.name == "Magnet"){
            myMagnet.enabled = !myMagnet.enabled;
        }

        if (Input.GetKeyDown(KeyCode.Q) && myMagnet2.name == "Magnet 2"){
            myMagnet2.enabled = !myMagnet2.enabled;
        }

        if (Input.GetKeyDown(KeyCode.H)){
            myMagnet3.enabled = !myMagnet3.enabled;
        }
    }
}
