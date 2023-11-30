using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Text myText;
    [SerializeField] private Player myPlayer;

    private void Update()
    {
        myText.text = "Your Score: " + myPlayer.Points().ToString();
    }
}
