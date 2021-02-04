
using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class Planet : MonoBehaviour
{
    public GameObject label;
    private GameObject loadedLabel;
    private PlanetTag labelScript;

    public Ship ship;
    
    // I can make a growth variable if I want them to increase pop at different rates
    //public int growth = 0;
    public string planetName= "Planet";
    public string faction = "Neutral";

    [SerializeField]
    private float population = 10f;
    [SerializeField]
    private int armor = 0;
    public string popText = "10";
    public float growthRate = 1f;

    public TextMeshProUGUI[] labelTexts;

    [Header("Parent References")]
    [SerializeField]
    private GameObject planetArray;
    [SerializeField]
    private GameObject gameManager;
    [SerializeField]
    private GameManager managerScript;

    public Planet[] adjacents;
    private List<Planet> adjacentsList;


    // Start is called before the first frame update
    void Start()
    {
        planetArray = transform.parent.gameObject;
        gameManager = planetArray.transform.parent.gameObject;
        managerScript = gameManager.GetComponent<GameManager>();


        loadedLabel = Instantiate(label, FindObjectOfType<Canvas>().transform);
        labelScript = label.GetComponent<PlanetTag>();

        PlaceLabelOnScreen();


        /* Now I'm trying to get the text referenced here so it can go up as the pop goes up
         * 
         * check whether it's TMPro or TMProUGUI
         */

        labelTexts = loadedLabel.GetComponentsInChildren<TextMeshProUGUI>();
        labelTexts[0].text = planetName;

        ColorizeLabel(faction);
        adjacentsList = new List<Planet>(adjacents); 

    }

    bool ValidTarget(Planet target)
    {

        return false;
    }


    // Update is called once per frame
    void Update()
    {
        PassiveGrowth();

        // Uncomment below to change labels as screen size changes.
        // PlaceLabelOnScreen();
    }

    void PlaceLabelOnScreen()
    {
        /* I am using the code below only at the start since it won't change throughout the game,
        so it doesn't make sense to put it on Update like the tutorial did
        */
        Vector3 posYoffset = transform.position;
        posYoffset.y -= 1;
        loadedLabel.transform.position = Camera.main.WorldToScreenPoint(posYoffset);
    }

    public void MoveTroops(Planet target)
    {
        if (target != this)
        {
            if (adjacentsList.Contains(target))
            {
                Debug.Log("I am moving troops to " + target.planetName);
                SpawnShips(target);
            }
            else
            {
                Debug.Log("Cannot move from " + planetName + " to " + target.planetName + " --not adjacent.");
            }



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
        newShip.faction = faction;
        newShip.sourcePlanet = this;
        
        
        
    }

    void ChangeOwner(string newOwner)
    {
        faction = newOwner;
        ColorizeLabel(faction);
    }

    void PassiveGrowth()
    {
        if (faction != "Neutral")
        {
            population += growthRate * Time.deltaTime;

        }
        popText = Mathf.FloorToInt(population).ToString();
        labelTexts[1].text = popText;
    }

    public void GrowPopulation(int num)
    {
        population += num;
    }

    public void TakeDamage(int num, Ship damageSource)
    {
        population -= num;
        if (population <= 0 )
        {
            population *= -1;
            ChangeOwner(damageSource.faction);
        }
    }

    void ColorizeLabel(string owner)
    {
        if (owner.ToLower() == "enemy")
        {
            labelTexts[0].color = labelScript.ENEMY;
            labelTexts[1].color = labelScript.ENEMY;
        }
        else if (owner.ToLower() == "neutral") 
        {
            labelTexts[0].color = labelScript.NEUTRAL;
            labelTexts[1].color = labelScript.NEUTRAL; 
        }
        else if (owner.ToLower() == "player")
        {
            labelTexts[0].color = labelScript.PLAYER;
            labelTexts[1].color = labelScript.PLAYER;
        }

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
