using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickHandler : MonoBehaviour
{
    public GameManager manager;
    //public int layerMask;

    // Start is called before the first frame update
    void Start()
    {
        // Layer Mask might be necessary if clicking my ships is interfering with
        // clicking the planet. At the moment, this should not happen, though.
        //layerMask = LayerMask.GetMask("Planets"); 
    }

// Update is called once per frame
private void Update()
    {
        /* The eventsystem part is to make sure my mouse is not ver
         * a UI element. I might be able to get rid of it if I'm not
         * actually using a big UI down the line.
         */

        /*
         * This is actually a bit of a problem currently
         * because I cannot target through a ship's power label
         */

        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            raycastLeft2d();
        }
        if (Input.GetMouseButtonDown(1) && !EventSystem.current.IsPointerOverGameObject())
        {
            raycastRight2d();
        }
        //if (Input.GetMouseButtonUp(1) && !EventSystem.current.IsPointerOverGameObject())
        //{
        //    raycastRight2dUp();
        //}
    }

    private void raycastLeft2d()
    {
        Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);

        if (hit)
        {
            //Debug.Log("I hit! " + hit.transform.gameObject);
            manager.selectedPlanet = hit.transform.gameObject.GetComponent<Planet>();
            manager.targeting = false;
        }
        else
        {
            //Debug.Log("Jack: I did not hit");
            manager.selectedPlanet = null;
            manager.targeting = false;
        }
    }

    private void raycastRight2d()
    {
        Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);

        if (hit && manager.selectedPlanet != null)
        {
            // I can use hit.transform.GetComponent<Planet>() or hit.transform.gameObject.GetComponent<Planet>()
            // Calling gameObject on hit.transform seems redundant but I'm leaving it there just in case.

            //Debug.Log("I hit! " + hit.transform.GetComponent<Planet>());
            //manager.targetPlanet = null;
            manager.targetPlanet = hit.transform.gameObject.GetComponent<Planet>();
            manager.targeting = true;
        }
        else
        {
            //Debug.Log("Jack: I did not hit");
            manager.targetPlanet = null;
            manager.targeting = false;
        }
    }

    /* The block below will be commented out for now as I move to left click to select, right click to target.
     * It was useful when movement was done with a right click -> Drag right click for movement, like vector targeting
     *  in League.
     */

    /* 
    private void raycastRight2dUp()
    {
        Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);

        if (hit)
        {
            //Debug.Log("Aiming at " + hit.transform.gameObject);
            manager.targetPlanet = hit.transform.gameObject.GetComponent<Planet>();
        }
        else
        {
            //Debug.Log("Jack: I did not hit");
            manager.targetPlanet = null;
        }
    }

    */




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
