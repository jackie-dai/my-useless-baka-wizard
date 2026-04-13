using UnityEngine;
using System.Collections;

public class PermeablePlatform : MonoBehaviour
{
    [SerializeField] float dropTime = 0.3f;
    
    float lastSPress;
    Collider2D platformCollider;

    void Start()
    {
        platformCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            // double tap s
            if (Time.time - lastSPress < 0.3f)
            {
                StartCoroutine(DisableCollider());
            }
            lastSPress = Time.time;
        }
    }

    IEnumerator DisableCollider()
    {
        platformCollider.enabled = false;
        yield return new WaitForSeconds(dropTime);
        platformCollider.enabled = true;
    }
}