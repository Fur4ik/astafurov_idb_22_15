using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreChecker : MonoBehaviour
{
    private int score;
    public TMP_Text label;
    void Start()
    {
        score=0;
    }

    void OnTriggerEnter(Collider ball){
    if (ball.tag=="ball"){
    ++score;
    label.text="Score: "+score;
}
}
}
