using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float startTime;

    public TextMeshProUGUI relojText;

    public PanelManager panelManager;

    void Start()
    {
        
    }

    
    void Update()
    {

        relojText.text = startTime.ToString("0.0");

        startTime -= Time.deltaTime;

        if(startTime <= 0)
        {

           Win();

        }

        
    }


    public void Win()
    {
        GameManager.instance.SwitchState("Win");
        panelManager.switchPanel("Win");
    }
}
