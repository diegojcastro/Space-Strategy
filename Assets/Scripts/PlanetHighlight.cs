
using UnityEngine;

public class PlanetHighlight : MonoBehaviour
{

    public GameManager manager;
    private Planet selected;
    private Renderer[] renderers;
    public GameObject bigHighlight;
    public GameObject smallHighlight;


    // Start is called before the first frame update
    void Start()
    {
        renderers = GetComponentsInChildren<Renderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        GoToSelectedPlanet();
        RotateChildren();
    }

    private void GoToSelectedPlanet()
    {
        selected = manager.selectedPlanet;

        if (selected != null)
        {
            transform.position = selected.transform.position;
            foreach (Renderer r in renderers)
            {
                r.enabled = true;
            }

        }
        else
        {
            foreach (Renderer r in renderers)
            {
                r.enabled = false;
            }
        }
    }

    private void RotateChildren()
    {
        float bigRotation = -10f * Time.deltaTime;
        float smallRotation = 19f * Time.deltaTime;

        bigHighlight.transform.Rotate(0, 0, bigRotation);
        smallHighlight.transform.Rotate(0, 0, smallRotation);
    }
}
