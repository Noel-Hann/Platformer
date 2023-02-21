using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

//referenced https://levelup.gitconnected.com/raycast-from-mouse-position-in-unity-63a828e92593

public class Raycasting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            Debug.Log("mouse pressed");

            RaycastHit hitInfo;
            Vector2 position = Input.mousePosition;
            Ray direction = Camera.main.ScreenPointToRay(position);

            if (Physics.Raycast(direction, out hitInfo))
            {
                Debug.Log("something was hit");
                Destroy(hitInfo.collider.gameObject);
            }

            //Debug.DrawRay(position, Vector3.up,Color.green);
            //if (Physics.Raycast(position, Vector3.back,100f))
            //{
            //    Debug.Log("something was hit");
            //}
        }

    }
    
}
