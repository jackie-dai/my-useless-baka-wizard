using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    #region Private
    private float interactRange = 4f;
    private Rigidbody2D playerRB;
    private GameObject equipped = null;
    private Animator anim;
    private SpriteRenderer spriteRenderer;

    #endregion
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        //animation stuff
        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(move));
        if (move < 0 )
        {
            spriteRenderer.flipX = false;
        } else if (move > 0) {
        
            spriteRenderer.flipX = true;
        }

        //add basic left right 2D movement
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * Time.deltaTime * 5);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * Time.deltaTime * 5);
        }

        //if (Input.GetKeyDown(KeyCode.E))
        //{   
        //    if (!equipped) // equip item
        //    {
        //        RaycastHit2D[] hits = Physics2D.BoxCastAll(playerRB.position, new Vector2(0.5f, 0.5f), 0f, Vector2.zero, 0f);
        //        foreach (RaycastHit2D hit in hits)
        //        {
        //            if (hit.collider.TryGetComponent(out IInteractable interactable))
        //            {
        //                interactable.Interact(transform);
        //            }
        //        }
        //        equipped = true;
        //    } else // unequip
        //    {
        //        Transform firstChild = transform.GetChild(0); 
        //        firstChild.parent = null;
        //        equipped = false;
        //    }
        //}
    }


    public bool EquipItem(GameObject itemPrefab) //returns true if item was equipped successfully, false if not
    {
        if (itemPrefab != null)
        {
            //unequip current item if there is one
            if (equipped != null)
            {
                Destroy(equipped);
                equipped = null;
            }

            GameObject equippedItem = Instantiate(itemPrefab, transform);
            equipped = equippedItem;
            //need to disable the sprite of item, and have player sprite update to show equipped item instead, including animation update
            equippedItem.transform.SetParent(transform);
            equippedItem.GetComponent<SpriteRenderer>().enabled = false; // hide the item's own sprite
            return true;
        }
        else
        {
            Debug.LogWarning("Item prefab is null. Cannot equip item.");
            return false;

        }
    }
}
