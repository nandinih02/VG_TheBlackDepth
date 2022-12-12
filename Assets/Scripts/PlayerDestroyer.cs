using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDestroyer : MonoBehaviour
{
    private Animator animator;
    PlayerLivesTracker livesTracker;

    private float delay = 1f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
       
        livesTracker = FindObjectOfType<PlayerLivesTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
           
            StartCoroutine(RemoveLife());
          
        }
    }

    void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator RemoveLife()
    {
        Debug.Log("Remove Life called");
       
            livesTracker.DecreaseLives();
        
        Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
                Destroy(this.gameObject);
        yield return new WaitForSeconds(1);    
         
    }

    

}
