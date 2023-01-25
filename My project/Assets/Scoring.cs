using UnityEngine;

public class Scoring : MonoBehaviour
{
    public static int Player1Score=0;
    public static int Player2Score=0;
    public static string Winner=string.Empty;
    public static Result Result;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
public enum Result { Player1, Player2, Draw, Win};
