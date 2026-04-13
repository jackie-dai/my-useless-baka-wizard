using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSelection : MonoBehaviour
{
    public Sprite selected;  
    public Sprite unselected;
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>(); 
        sr.sprite = unselected; 
    }

    void OnMouseEnter() 
    {
        sr.sprite = selected;
    }

    void OnMouseExit()
    {
        sr.sprite = unselected;
    }

    void OnMouseDown()
    {
        if (transform.gameObject.tag == "StartBtn")
        {
            SceneManager.LoadScene("Main");
        }
    }
}