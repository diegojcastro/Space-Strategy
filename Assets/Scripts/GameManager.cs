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

    [Header("Inputs")]
    public bool targeting;

    private void Awake()
    {

        // Uncomment below to use the one that starts in MainMenu
        // MakeSingleton();
    }



    private void Update()
    {
        if (selectedPlanet != null && targetPlanet != null && targeting == true)
        {
            selectedPlanet.MoveTroops(targetPlanet);

            targeting = false;
            selectedPlanet = null;
            targetPlanet = null;
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
