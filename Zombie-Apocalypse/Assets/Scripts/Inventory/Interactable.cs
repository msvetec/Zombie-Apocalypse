using UnityEngine;

using UnityEngine.UI;

public class Interactable : MonoBehaviour {

    public float radius = 2f;
    public Transform player;
    
    public Text text;
    public float time;
    private float waitTime = 2f;
    public  Item item;
    private bool wasPickedUp;


    private void Start()
    {
        wasPickedUp = true;
    }
    private void Update()
    {
        time += Time.deltaTime;
        float distance = Vector3.Distance(player.position, transform.position);
       
            if (distance <= radius)
            {

                if(!Inventory.instance.torbaPuna)
                text.text = "Press key <color=#88FF6AFF> << F >> </color> to Use: " + item.name;
                else
                text.text = "Torba je puna!!";

            if (Input.GetKeyDown(KeyCode.F))
                {
                    PickUp();
                }


            }
            else
            {
                text.text = "";
            }
        
        

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    private void PickUp()
    {
        //Debug.Log("Picking up item" + item.name);
        //takePanel.SetActive(false);
        wasPickedUp = Inventory.instance.Add(item);
        if (wasPickedUp)
        {
            Destroy(gameObject);
            text.text = "";
        }
        
            



    }
}
