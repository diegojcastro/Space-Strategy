using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineHandler : MonoBehaviour
{
    private LineRenderer lr;
    [SerializeField]
    private Transform[] points;
    [SerializeField]
    private Vector3[] vectors;


    private void Awake()
    {
        lr = GetComponent<LineRenderer>();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (points.Length > 0)
        {
            for (int i = 0; i < points.Length; i++)
            {
                lr.SetPosition(i, points[i].position);
            }
        }
    }


    public void DrawLine(Planet selected, Planet[] planets)
    {
        lr.positionCount = planets.Length *2;
        // Possibly not *2 here


        Transform[] pts = new Transform[lr.positionCount];

        for(int i = 0; i < planets.Length; i++)
        {
            pts[i*2] = planets[i].transform;
            pts[i * 2 + 1] = selected.transform;
        }
        points = pts;



    }

    public void ClearPoints()
    {
        lr.positionCount = 0;
    }
}
