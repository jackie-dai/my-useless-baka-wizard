using UnityEngine;
using System.Collections;

public class FlapBehaviour : MonoBehaviour
{
    //essentially a double jump, but with 3x instead of 2x 
    #region Editor Variables
    [Header("Flap Settings")]
    [Tooltip("Number of flaps player can do.")]
    public int maxFlaps = 2;

    [Tooltip("Multiplier for the flap force applied to the player.")]
    public float flapForceMultiplier = 10f;

    [Tooltip("Time cooldown before jump resets.")]
    public float resetTime = 0.5f;
    #endregion

    #region Private Variables
    private bool canFlap = true;
    private float lastFlapTime = -100f;
    private int currentFlaps = 0;
    #endregion

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastFlapTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("w pressed down");
            Rigidbody2D rb = GetComponentInParent<Rigidbody2D>();
            if (rb != null)
            {

                Debug.Log("Can flap: " + canFlap + ", Current flaps: " + currentFlaps);
                
                if (canFlap)
                {
                    //apply flap force to parent component
                    rb.AddForce(Vector3.up * flapForceMultiplier, ForceMode2D.Impulse);
                    
                    currentFlaps++;
                    lastFlapTime = Time.time;
                    if (currentFlaps >= maxFlaps)
                    {
                        canFlap = false;
                    }
                }
            }
            else
            {
                Debug.LogWarning("No Rigidbody2D found in parent.");
            }
        }


        //check if can reset flaps
        if (!canFlap)
        {
            if (Time.time - lastFlapTime > resetTime)
            {
                canFlap = true;
                currentFlaps = 0;
            }
        }
    }
}
