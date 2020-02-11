using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject ScoreBorad;
    public string lives = "Lives";
    public int nomliv;
    public int liv=1;
    void Start()
    {
        ScoreBorad = GameObject.Find("Score");
    }

    // Update is called once per frame
    void Update()
    {
        ScoreBorad.GetComponent<Text>().text = "Lives "+nomliv +" left";

        if (Input.GetKeyDown(KeyCode.U))
            hurt();
        
    }

    void hurt()
    {
        nomliv--;
    }
}
