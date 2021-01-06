using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Planet : MonoBehaviour
{
    public GameObject label;
    private GameObject loadedLabel;
    

    private int growth = 0;
    public string planetName= "Planet";
    private string faction = "Neutral";

    public float population = 10f;
    public string popText = "10";
    


    // Start is called before the first frame update
    void Start()
    {
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
        
        //loadedLabel.GetComponentsInChildren<TextMeshPro>

    }

    // Update is called once per frame
    void Update()
    {
        population += Time.deltaTime;
        popText = Mathf.FloorToInt(population).ToString();
    }

    void MoveTroops()
    {

    }
}
