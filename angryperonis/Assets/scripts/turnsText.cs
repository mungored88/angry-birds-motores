using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class turnsText : MonoBehaviour
{
    public Text turnsLeft;
    public float turnCount;

    // Start is called before the first frame update
    void Start()
    {
        turnCount = GameObject.FindGameObjectWithTag("Manager").GetComponent<TurnMananger>().turns;
    }
    // Update is called once per frame
    void Update()
    {
        turnCount = GameObject.FindGameObjectWithTag("Manager").GetComponent<TurnMananger>().turns;
        turnsLeft.text = "Quedan " + turnCount + " turnos";
    }
}
