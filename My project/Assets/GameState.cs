using System.Collections;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    PlayerController player1Controller;
    PlayerController player2Controller;
    public string Player1Name = "Player1";
    public string Player2Name = "Player2";
    public TextMeshProUGUI Player1Text;
    public TextMeshProUGUI Player2Text;
    // Start is called before the first frame update
    void Start()
    {
        player1Controller = Player1.GetComponent<PlayerController>();
        player2Controller = Player2.GetComponent<PlayerController>();
        Player1Text.text = Player1Name;
        Player2Text.text = Player2Name;
    }

    // Update is called once per frame
    void Update()
    {
        if (player1Controller.gameOver && player2Controller.gameOver)
        {
            Scoring.Player1Score = player1Controller.Score;
            Scoring.Player2Score = player2Controller.Score;
            if (Scoring.Player1Score > Scoring.Player2Score)
            {
                Scoring.Result = Result.Player1;
                Scoring.Winner = Player1Name;
            }
            else if (Scoring.Player1Score < Scoring.Player2Score)
            {
                Scoring.Result = Result.Player2;
                Scoring.Winner = Player2Name;
            }
            else if ( Scoring.Result != Result.Win)
                Scoring.Result = Result.Draw;
            StartCoroutine(DisplayGameOverScreen());
        }
      
    }
    IEnumerator DisplayGameOverScreen()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(2);
    }

}
