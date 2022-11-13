using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    float timeElapsed;
    public float delayUntilDestroy=2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
            if (timeElapsed > delayUntilDestroy) Destroy(this.gameObject);
    }

   
}
