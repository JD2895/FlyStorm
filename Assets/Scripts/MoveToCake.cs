using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveToCake : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject cake;
    private Vector3 targetPosition;
    private float speed;

    // Sound
    public AudioClip flysound;
    private AudioSource source;
    private float volLowRange;
    private float volHighRange;
    public float vol;
    public int once;

    // Menu
    public GameObject menu_object;
    public Button menu_button;

    // Background
    public SpriteRenderer backSmall;
    public SpriteRenderer backBig;
    public float setStart;
    public float setGo;
    public Color[] smallColorList;
    public Color[] bigColorList;
    public int colorSelector;
    private float startTime;
    private float goTime;

    // Ending
    public SpriteRenderer fadeoutSprite;
    private bool fadeout;
    private float initTime;
    public float duration;
    public GameObject actualLevel;
    public GameObject end_menu;

    // Audio
    public AudioSource beats;
    public float fadeBeat;
    private float startVolume;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // target the cake
        targetPosition = new Vector3(0.01f, -3.08f, -4f);
        speed = 3.0f;

        // volume control
        volLowRange = 0.75f;
        volHighRange = 1.2f;
        if (vol == 0)
        {
            vol = Random.Range(volLowRange, volHighRange);
        }

        // background changing
        startTime = 999999999999999.99f;
        colorSelector = 0;

        // fadeout
        fadeout = false;
        startVolume = beats.volume;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);

        if (backSmall != null && backBig != null){
            if (Time.time > startTime){
                if (Time.time > goTime){
                    goTime += setGo;
                    backSmall.color = smallColorList[colorSelector % 16];
                    backBig.color = bigColorList[colorSelector % 14];
                    colorSelector += 1;
                }
            }
        }

        if (fadeoutSprite != null){
            if (fadeout == true) {
                float t = (Time.time - initTime) / duration;
                
                fadeoutSprite.color = new Color(0f,0f,0f,Mathf.SmoothStep(0, 1, t));             
            }

            if(fadeoutSprite.color.a > 0.999){
                actualLevel.SetActive(false);
                
                if (end_menu != null){
                    end_menu.SetActive(true);
                }
            }
        }
                
        if (beats!=null){
            Debug.Log(beats.volume);
            if (once == 2){
                if(beats.volume > 0){
                    beats.volume -= fadeBeat;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Palm") && once <= 1)
        {
            // only for darude fly
            if (once == 1)
            {
                once++;
                startTime = Time.time + setStart;
                goTime = startTime + setGo;
            }

            source.PlayOneShot(flysound, vol);
            if (transform.position.x < 0)
            {
                targetPosition = new Vector3(-15.0f, 0f, -4f);   // set target position to the left, offscreen
            } else
            {
                targetPosition = new Vector3(15.0f, 0f, -4f);   // set target position to the right, offscreen
            }
            speed = 6;

            initTime = Time.time;
            fadeout = true;
            
        }

        if (collision.CompareTag("Destroy") && once <= 1)
        {
            if (menu_button != null){
                menu_button.interactable = true;
            }
            if (menu_object != null){
                menu_object.SetActive(true);
            }
            Destroy(gameObject);
        }
    }
}
