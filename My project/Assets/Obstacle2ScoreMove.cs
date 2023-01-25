using UnityEngine;

public class Obstacle2ScoreMove : MonoBehaviour
{
    public float speed = 30;
    float leftBoundary = -15;
    PlayerController playerControllerScript;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player2").GetComponent<PlayerController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.gameOver)
        {
            transform.Translate(Time.deltaTime * Vector3.forward * speed);
        }
        else
        {
            anim.SetFloat("Speed_f", 0);
        }
        if (transform.position.x < leftBoundary)
        {
            playerControllerScript.AddScore();
            Destroy(gameObject);
        }
    }
}
