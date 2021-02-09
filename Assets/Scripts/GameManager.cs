using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public int totalScore;
    public Planet selectedPlanet;
    public Planet targetPlanet;
    [SerializeField]
    private Planet oldSelection;

    [Header("Inputs")]
    public bool targeting;

    private void Awake()
    {

        // Uncomment below to use the one that starts in MainMenu
        // MakeSingleton();
    }



    private void Update()
    {
        if (selectedPlanet == null)
        {
            if (oldSelection != null)
            {
                foreach (Planet p in oldSelection.adjacents)
                    p.Unhighlight();

                oldSelection = null;
            }
        }
        else
        {
            if (oldSelection != selectedPlanet && oldSelection != null)
            {
                foreach (Planet p in oldSelection.adjacents)
                    p.Unhighlight();
                oldSelection = selectedPlanet;
                foreach (Planet p in selectedPlanet.adjacents)
                {
                    p.Highlight();
                }
            }
            if (targetPlanet != null && targeting == true)
            {
                selectedPlanet.MoveTroops(targetPlanet);

                targeting = false;
                selectedPlanet = null;
                targetPlanet = null;
            }
            else if (selectedPlanet != oldSelection)
            {
                oldSelection = selectedPlanet;
                foreach (Planet p in selectedPlanet.adjacents)
                {
                    p.Highlight();
                }
            }
        }
        
    }

   

    



    /*
     * Uncomment to use the MainMenu GameManager with DontDestroyOnLoad
     * 
    private void MakeSingleton()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    */

}
