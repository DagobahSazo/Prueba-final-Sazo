using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadosTime : MonoBehaviour
{
    public PanelManager panelManager;

    private void OnEnable()
    {
        GameManager.OnStateChange += HandleStateChange;
    }

    private void OnDisable()
    {
        GameManager.OnStateChange -= HandleStateChange;
    }

    private void HandleStateChange(string state)
    {
        if (state == "Gay")
	    {
            Time.timeScale = 1f;
        }

	    else if (state == "GameOver")
	    {
            Time.timeScale = 0f;
        }

	    else if (state == "Win")
        {
            Time.timeScale = 0f;
        }
        else if (state == "Menu")
        {
            Time.timeScale = 0f;
        }
    }


    
}
