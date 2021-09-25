using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNshoot : MonoBehaviour
{

    public float power = 10f;
    public Rigidbody2D rb;

    public Vector2 minPower;
    public Vector2 maxPower;

    public TrajectoryLine tl;

    Camera cam;
    Vector2 force;
    Vector3 startPoint;
    Vector3 endtPoint;

    private void Start()
    {
        cam = Camera.main;
        tl = GetComponent<TrajectoryLine>();

    }
    
    private void Update()
    {
      if (Input.GetMouseButtonDown(0))
        {
            startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            //Debug.Log(startPoint);
            startPoint.z = 15;
        }

      if (Input.GetMouseButton(0))
        {
            Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            currentPoint.z = 15;
            tl.RenderLine(startPoint, currentPoint);

        }


        if (Input.GetMouseButtonUp(0))
        {
            endtPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            endtPoint.z = 15;

            force = new Vector2(Mathf.Clamp(startPoint.x - endtPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endtPoint.y, minPower.y, maxPower.y));
            rb.AddForce(force * power, ForceMode2D.Impulse);
            tl.Endline();
        
        }
    }


}
