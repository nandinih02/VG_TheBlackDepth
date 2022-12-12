using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxigenMetr : MonoBehaviour
{
    public Slider oxygenBar;
    public float oxygenAmount =10.0f;
    public float currentOxygen;
    private float value;

    PlayerLivesTracker livesTracker;

    // Start is called before the first frame update
    void Start()
    {
        currentOxygen = oxygenAmount;
        livesTracker = FindObjectOfType<PlayerLivesTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            currentOxygen -= 5 * Time.deltaTime;
        }
        else
        {
            currentOxygen -= Time.deltaTime;
        }
            value = currentOxygen / oxygenAmount;
            oxygenBar.value = value;
            if (value <= 0)
            {
                livesTracker.DecreaseLives();
                currentOxygen = oxygenAmount;
            }
       
    }
}
