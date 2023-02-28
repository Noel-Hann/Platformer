using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerascript : MonoBehaviour
{
    private Transform _transform;

    public GameObject mario;

    private Transform marioTransform;
    // Start is called before the first frame update
    void Start()
    {
        _transform = GetComponent<Transform>();
        marioTransform = mario.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        _transform.position = new Vector3(marioTransform.position.x, _transform.position.y, _transform.position.z);
    }
}
