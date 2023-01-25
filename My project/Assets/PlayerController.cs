using TMPro;
using UnityEngine;
using UnityEngine.UIElements;


public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    private Animator playerAnim;
    private AudioSource playerAudio;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip deathSound;
    public AudioClip jumpSound;
  
    public float jumpForce = 1000;
    public bool isOnGround = true;
    public bool gameOver = false;
    public int NextLevelScore = 10;
    public KeyCode jumpKey;
    public int Score = 0;
    public TextMeshProUGUI TextMesh;
    Vector3 startPosition;
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity = new Vector3(0, -29.43f,0);
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
     
        if (Input.GetKeyDown(jumpKey) && isOnGround && !gameOver)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
//            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {

            transform.position = startPosition;
            gameOver = true;
            dirtParticle.Stop();
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
//            playerAudio.PlayOneShot(deathSound,1.0f);
        }
    }
 
    public void AddScore()
    {
        Score++;
        if (Score == NextLevelScore)
        {
            gameOver = true;
            Scoring.Result = Result.Win;
            dirtParticle.Stop();
            playerAnim.SetFloat("Speed_f", 0);
            playerAnim.SetFloat("Head_Vertical_f", 0.6f);
        }
        System.Console.WriteLine("AddScore "+gameObject.name);
        TextMesh.text = $"{Score}/{NextLevelScore}";
    }
}
