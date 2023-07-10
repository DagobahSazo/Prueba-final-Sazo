using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    
    public List<Container> panels;

    public string initialIdentifier;
    private string actualIdentifier;



    private void OnEnable()
    {
        switchPanel(initialIdentifier); 
    }

    private void OnDisable()
    {
        
    }

    public void switchPanel(string newIdentifier)
    {
        if(actualIdentifier == newIdentifier) return;
        actualIdentifier = newIdentifier;

        foreach (Container container in panels)
        {
            if(container.identificador == newIdentifier) container.panel.Open();
            else container.panel.Close();
        }
    }

    [System.Serializable]
    public class Container
    {
        public string identificador;
        public Panel panel;
        
    }
}
