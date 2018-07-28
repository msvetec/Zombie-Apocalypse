using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour {

    public float radius = 1f;
    public Transform player;
    public GameObject takePanel;
    public Text itemName;
    public  Item item;

    private void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance <= radius)
        {
            //Debug.Log("Use");
            takePanel.SetActive(true);
            itemName.text = item.name;
            if (Input.GetKeyDown(KeyCode.F))
            {
                PickUp();
            }

        }
        else
        {
            takePanel.SetActive(false);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    private void PickUp()
    {
        Debug.Log("Picking up item" + item.name);
        takePanel.SetActive(false);
        bool wasPickedUp = Inventory.instance.Add(item);
        if (wasPickedUp)
        {
            Destroy(gameObject);
        }
    }
}
