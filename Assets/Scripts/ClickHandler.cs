using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickHandler : MonoBehaviour
{
    public GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        /* The eventsystem part is to make sure my mouse is not ver
         * a UI element. I might be able to get rid of it if I'm not
         * actually using a big UI down the line.
         */

        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            raycastLeft2d();
        }
    }

    private void raycastLeft2d()
    {
        Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);

        if (hit)
        {
            Debug.Log("I hit! " + hit.transform.gameObject);
            manager.selectedPlanet = hit.transform.gameObject;
        }
        else
            Debug.Log("Jack: I did not hit");
    }

    private void raycastLeftDown()
    {
        //Debug.Log("Starting left click function");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Debug.Log("Hit something");
            Debug.Log(hit.collider.name);
            GameObject clicked = hit.transform.gameObject;
            //selectedPlanet = clicked;
        }
        else
            Debug.Log("Hit nothing");
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
}
