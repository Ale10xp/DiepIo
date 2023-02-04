using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{

    public Transform target;

    public Vector2 offSet;

    public  Vector2 SmoothOffSet;
    private Vector2 RealOffSet;

    Camera cam;
    public bool mouseOffset = false;
    // Start is called before the first frame update
    void Start()
    {
         cam = Camera.main;

        RealOffSet = offSet;

    }

    // Update is called once per frame
    void Update()
    {


        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 screenDimension = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        float minX = (screenDimension.x/2) - Mathf.Abs(screenDimension.x / 2);
        float maxX = screenDimension.x;

        float minY = (screenDimension.y / 2) - Mathf.Abs(screenDimension.y / 2);
        float maxY = screenDimension.y;


        if (mouseOffset)
        {
            RealOffSet = new Vector2(offSet.x + Map(mousePos.x, minX, maxX, -SmoothOffSet.x, SmoothOffSet.x),
                                     offSet.y + Map(mousePos.y, minY, maxY, -SmoothOffSet.y, SmoothOffSet.y));
        }

        print("MousePos: "+ mousePos + " Screen: " + screenDimension);

        transform.position = new Vector3(target.position.x + RealOffSet.x, target.position.y + RealOffSet.y, transform.position.z);



        


    }
 


    float Map(float x, float in_min, float in_max, float out_min, float out_max)
    {
        return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
    }


   



}
