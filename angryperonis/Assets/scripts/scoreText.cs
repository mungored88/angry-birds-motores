using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreText : MonoBehaviour
{
    public Text score;
    public float scoreCount;

    // Start is called before the first frame update
    void Start()
    {
        scoreCount = GameObject.FindGameObjectWithTag("Manager").GetComponent<TurnMananger>().score;
    }
    // Update is called once per frame
    void Update()
    {
        scoreCount = GameObject.FindGameObjectWithTag("Manager").GetComponent<TurnMananger>().score;
        score.text = "Partida terminada! \n Tu puntaje es de \n" + scoreCount + " puntos";
    }
}
