using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enlarge : MonoBehaviour
{
	public Vector3 newScale;
	public float enlargeSpeed;
	public bool enlargeMe;
	public GameObject tutorialLevel;
	public GameObject actualLevel;

    // Start is called before the first frame update
    void Start()
    {
        enlargeMe = false;
    }

    // Update is called once per frame
    void Update()
    {
    	if(enlargeMe == true) {
        	transform.localScale = Vector3.Lerp (transform.localScale, newScale, enlargeSpeed * Time.deltaTime);
        }

        if(transform.localScale.x > 0.1){
            tutorialLevel.SetActive(false);
            actualLevel.SetActive(true);
        }
    }

    public void set_enlarge(bool toEnlarge){
        enlargeMe = toEnlarge;
    }
}
