using UnityEngine;
using TMPro;


public class Ship : MonoBehaviour
{
    public GameObject label;
    private GameObject loadedLabel;
    public Planet hitPlanet = null;

    [Header("Attributes")]
    public string faction;
    public int power;
    public int oldPower;
    public int speed;
    public Planet sourcePlanet;
    public Planet targetPlanet;
    public Vector2 direction;

    public TextMeshProUGUI labelText;
    private SpriteRenderer spriteRenderer;

    // In the future I can change this to use Animator instead
    // I'll likely change it once we have death/attack animations.
    [Header("imageHolders")]
    public Sprite friend;
    public Sprite enemy;



    // Start is called before the first frame update
    void Start()
    {
        loadedLabel = Instantiate(label, FindObjectOfType<Canvas>().transform);
        spriteRenderer = GetComponent<SpriteRenderer>();
        SelectSprite();
        RotateSprite();



    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsTarget();
        DisplayPowerLabel();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject != sourcePlanet.gameObject)
        {
            Debug.Log("I hit something, seemingly " + collision.gameObject);
            hitPlanet = collision.GetComponent<Planet>();
            if (hitPlanet)
            {
                if (hitPlanet.faction == faction)
                {
                    Reinforce(hitPlanet);
                }
                else
                {
                    AttackPlanet(hitPlanet);
                }
            }
            else
            {
                Ship hitShip = collision.GetComponent<Ship>();
                if (hitShip)
                {
                    Debug.Log("Hit a ship.");
                }
                else
                {
                    Debug.Log("Did not find a ship collision.");
                }
            }
            
        }
        
        
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

    void Reinforce(Planet target)
    {
        target.GrowPopulation(this.power);
        DestroyShipAndLabel();
    }

    void DestroyShipAndLabel()
    {
        Destroy(loadedLabel);
        Destroy(gameObject);
    }

    void AttackPlanet(Planet target)
    {
        target.TakeDamage(this.power, this);
        DestroyShipAndLabel();
    }

    void SelectSprite()
    {
        if (faction.ToLower() == "player")
            spriteRenderer.sprite = friend;
        else if (faction.ToLower() == "enemy")
            spriteRenderer.sprite = enemy;
    }

    void RotateSprite()
    {
        if (faction.ToLower() == "player")
        {
            if (direction != Vector2.zero)
            {
                float angle = -90f + Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }
        else if (faction.ToLower() == "enemy")
        {
            if (direction != Vector2.zero)
            {
                float angle = 90f + Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }
    }
}
