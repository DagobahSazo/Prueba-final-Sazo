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

   
}

