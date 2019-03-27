using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveToMouse : MonoBehaviour
{
    public Vector3 targetPosition;
    private Rigidbody2D current;
    public int power;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = -4;
            //transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * 5);
            //gameObject.rigidbody.AddForce((whateverObject.transform.position - transform.position).normalized * someFactor);
            gameObject.GetComponent<Rigidbody2D>().AddForce((targetPosition - transform.position).normalized * Time.deltaTime * power);
        }

        
    }
}
