using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Planet : MonoBehaviour
{
    public GameObject label;
    private GameObject loadedLabel;

    public Ship ship;
    
    // I can make a growth variable if I want them to increase pop at different rates
    //public int growth = 0;
    public string planetName= "Planet";
    public string faction = "Neutral";

    public float population = 10f;
    public string popText = "10";

    public TextMeshProUGUI[] labelTexts;

    [Header("Parent References")]
    [SerializeField]
    private GameObject planetArray;
    [SerializeField]
    private GameObject gameManager;
    [SerializeField]
    private GameManager managerScript;
    


    // Start is called before the first frame update
    void Start()
    {
        planetArray = transform.parent.gameObject;
        gameManager = planetArray.transform.parent.gameObject;
        managerScript = gameManager.GetComponent<GameManager>();


        loadedLabel = Instantiate(label, FindObjectOfType<Canvas>().transform);

        /* I am using the code below only at the start since it won't change throughout the game,
            so it doesn't make sense to put it on Update like the tutorial did
        */
        Vector3 posYoffset = transform.position;
        posYoffset.y -= 1;
        loadedLabel.transform.position = Camera.main.WorldToScreenPoint(posYoffset);


        /* Now I'm trying to get the text referenced here so it can go up as the pop goes up
         * 
         * check whether it's TMPro or TMProUGUI
         */

        labelTexts = loadedLabel.GetComponentsInChildren<TextMeshProUGUI>();
        labelTexts[0].text = planetName;



    }

    // Update is called once per frame
    void Update()
    {
        population += Time.deltaTime;
        popText = Mathf.FloorToInt(population).ToString();
        labelTexts[1].text = popText;
    }

    public void MoveTroops(Planet target)
    {
        if (target != this)
        {
            Debug.Log("I am moving troops to " + target.planetName);
            SpawnShips(target);
        }

    }

    void SpawnShips(Planet target)
    {
        float plusOne = population % 2;
        float spawnPop = population / 2;
        population = spawnPop + plusOne;

        Ship newShip = Instantiate(ship, transform, true);
        newShip.power = (int)spawnPop;
        newShip.transform.position = transform.position;
        newShip.targetPlanet = target;
        Vector2 dir = target.transform.position - newShip.transform.position;
        dir.Normalize();
        newShip.direction = dir;
        
        
    }

    void ChangeOwner(string newOwner)
    {

    }

    /*
    private void OnMouseDown()
    {
        managerScript.selectedPlanet = gameObject;
    }

    private void OnMouseUp()
    {
        //if (Input.GetMouseButtonUp(1))
        {
            managerScript.targetPlanet = gameObject;
        }
    }
    */
}
