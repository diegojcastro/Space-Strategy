using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public int totalScore;
    public GameObject selectedPlanet;
    public GameObject targetPlanet;

    private void Awake()
    {

        // Uncomment below to use the one that starts in MainMenu
        // MakeSingleton();
    }

/*

    private void Update()
    {
        // The eventsystem part is to make sure my mouse is not ver
        // a UI element. I might be able to get rid of it if I'm not
        // actually using a big UI down the line.
        

        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            raycastLeftDown();
        }
    }

    private void raycastLeftDown()
    {
        Debug.Log("Starting left click function");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 20))
        {
            Debug.Log("Hit something");
            Debug.Log(hit.collider.name);
            GameObject clicked = hit.transform.gameObject;
            selectedPlanet = clicked;
        }
    }

    private void raycastRightDown()
    {

    }
    private void raycastLeftUp()
    {

    }

    private void raycastRightUp()
    {

    }
*/
    



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
