using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 30;
    PlayerController playerControlerScript;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        playerControlerScript = Player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControlerScript.gameOver)
        {
            transform.Translate(Time.deltaTime * Vector3.left * speed);
        }
    }
}
