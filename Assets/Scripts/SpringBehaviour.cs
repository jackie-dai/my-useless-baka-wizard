using UnityEngine;
using System.Collections;

public class SpringBehaviour : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if S is pressed then released, parent component (which will be player) will jump up with force proportional to the time S was held down
        if (Input.GetKeyDown(KeyCode.S))
        {
            //start counting time
            StartCoroutine(Jump());
        }
    }

    //want this to be ienumerator
    IEnumerator Jump()
    {
        float timeHeld = 0f;
        while (Input.GetKey(KeyCode.S))
        {
            //print time held
            Debug.Log("Time held: " + timeHeld);
            timeHeld += Time.deltaTime;
            yield return null;
        }
        //apply force to parent component
        Rigidbody2D rb = GetComponentInParent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(Vector3.up * timeHeld * 10f, ForceMode2D.Impulse);
        }
        else
        {
            Debug.LogWarning("No Rigidbody2D found in parent.");
        }
    }


}
