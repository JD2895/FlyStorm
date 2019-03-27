using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameOver : MonoBehaviour
{
    // controlling an external gameObject
    public GameObject largeCircle;

    //controlling scaling
    public Vector3 newScale;
    public float enlargeSpeed;
    public GameObject tutorialLevel;
    public GameObject actualLevel;
    public bool enlargeMe;

    //gameover menu
    public GameObject menu_object;

    // Start is called before the first frame update
    void Start()
    {
        enlargeMe = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(enlargeMe == true) {
            largeCircle.transform.localScale = Vector3.Lerp (largeCircle.transform.localScale, newScale, enlargeSpeed * Time.deltaTime);
        }

        // stopping other flies
        if(largeCircle.transform.localScale.x > 0.1){
            tutorialLevel.SetActive(false);
            actualLevel.SetActive(false);
            
            if (menu_object != null){
                menu_object.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fly"))
        {
            enlargeMe = true;
        }
    }
}
