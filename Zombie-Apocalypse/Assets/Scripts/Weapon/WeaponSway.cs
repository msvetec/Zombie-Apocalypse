using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSway : MonoBehaviour {

    [SerializeField]
    private float amount;
    [SerializeField]
    private float smoothAmount;
    [SerializeField]
    private float maxAmount;
    
    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.localPosition;

    }

    private void Update()
    {
        if(!Inventory.instance.inventoryOn)
        WeaponSwayStart();

    }
    private void WeaponSwayStart()
    {
        float movementX = -Input.GetAxis("Mouse X") * amount;
        float movementY = -Input.GetAxis("Mouse Y") * amount;
        movementX = Mathf.Clamp(movementX, -maxAmount, maxAmount);
        movementY = Mathf.Clamp(movementY, -maxAmount, maxAmount);

        Vector3 finalPosition = new Vector3(movementX, movementY, 0);
        transform.localPosition = Vector3.Lerp(transform.localPosition, finalPosition + initialPosition, Time.deltaTime * smoothAmount);
    }


}
