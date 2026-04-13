using UnityEngine;
using System.Collections;

public class SpringBehaviour : MonoBehaviour, IInteractable
{


    //want to add the cap to spring force as editor variable
    #region Editor Variables
    [Header("Spring Settings")]
    [Tooltip("Maximum time the spring can be held down to apply force.")]
    public float maxHoldTime = 2f;

    [Tooltip("Multiplier for the jump force applied to the player.")]
    public float jumpForceMultiplier = 10f;
    #endregion
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
            SoundManager.Instance?.PlayRubberFrogCoiling();
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
            if (timeHeld < maxHoldTime) //arbitrary cap to prevent excessive force of 2
            {
                timeHeld += Time.deltaTime;
            }
            
            yield return null;
        }

        //apply force to parent component
        Rigidbody2D rb = GetComponentInParent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(Vector3.up * timeHeld * jumpForceMultiplier, ForceMode2D.Impulse);
            SoundManager.Instance?.PlayRubberFrogSpringing();
        }
        else
        {
            Debug.LogWarning("No Rigidbody2D found in parent.");
        }
    }

    public void Interact(Transform player) 
    {   
        Debug.Log("equip");
        transform.parent = player;
    }


}
