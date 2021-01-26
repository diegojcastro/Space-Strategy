using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Ship : MonoBehaviour
{
    public GameObject label;
    private GameObject loadedLabel;

    [Header("Attributes")]
    public string faction;
    public int power;
    public int oldPower;
    public int speed;
    public Planet targetPlanet;
    public Vector2 direction;

    public TextMeshProUGUI labelText;



    // Start is called before the first frame update
    void Start()
    {
        loadedLabel = Instantiate(label, FindObjectOfType<Canvas>().transform);

        



    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsTarget();
        DisplayPowerLabel();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("I hit something, seemingly " + collision);
    }

    void DisplayPowerLabel()
    {
        Vector3 posYoffset = transform.position;
        posYoffset.y -= 0.5f;
        loadedLabel.transform.position = Camera.main.WorldToScreenPoint(posYoffset);

        if ( oldPower != power )
        {
            labelText = loadedLabel.GetComponent<TextMeshProUGUI>();
            labelText.text = power.ToString();
            oldPower = power;
        }
 
    }

    void MoveTowardsTarget()
    {
        transform.position = (Vector2)transform.position + direction * speed * Time.deltaTime;
    }

    void ResolveDamage(int dmg)
    {

    }

    void Explode()
    {

    }
}
