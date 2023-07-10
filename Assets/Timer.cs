using System.Collections;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float startTime;
    public TextMeshProUGUI relojText;
    public PanelManager panelManager;

    private bool isRunning;

    private void Start()
    {
        
     
        StartTimer();
    }

    private void StartTimer()
    {
        startTime = 10f;
        isRunning = true;
        StartCoroutine(TimerCoroutine());
    }

    private IEnumerator TimerCoroutine()
    {
        while (isRunning)
        {
            relojText.text = startTime.ToString("0.0");
            startTime -= Time.deltaTime;

            if (startTime <= 0)
            {
                
                yield return new WaitForSeconds(0.1f);
                Win();
                
                yield break; 
            }

            yield return null; 
        }
    }

    public void Win()
    {
        
        GameManager.instance.SwitchState("Win");
        panelManager.switchPanel("Win");
    }

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

           StartTimer();
        }
        else if (state == "GameOver")
        {
           Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }

        else if (state == "Win")
        {
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
        else if (state == "Menu")
        {
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }


    }

}

