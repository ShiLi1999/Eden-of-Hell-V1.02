using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnduranceChange : MonoBehaviour {

    public Text EnduranceTXT;
    public static float EnduranAmount = 100;

    void Start()
    {
        EnduranceTXT = GetComponent<Text>();
        //score = 0;
        //UpdateScore();
    }

    // public void AddScore (int newScoreValue)
    // {
    //     score += newScoreValue;
    //     UpdateScore();
    //  }


    private void Update()
    {

        EnduranceTXT.text = "Endurance: " + EnduranAmount  + "/100";
       // EnduranceTXT.text = "Endurance: " + EndNum + "/100";

    }
}
