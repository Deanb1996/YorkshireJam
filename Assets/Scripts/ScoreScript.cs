using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{

    private float timeAlive;
    public Text scoreText;
  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeAlive += Time.deltaTime;
        scoreText.text = "Score: " + timeAlive.ToString("F2");
    }

    private void OnDestroy()
    {
        StaticVars.score = timeAlive;
    }
}
