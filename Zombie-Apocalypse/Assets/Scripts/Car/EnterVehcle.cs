using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class EnterVehcle : MonoBehaviour {

    public GameObject camera;
    public GameObject player;
    public GameObject exitTrigger;
    public GameObject theCar;
    private int triggerCheck;
    private AudioSource audio;
    private Rigidbody rb;

    private void OnTriggerEnter(Collider other)
    {
        triggerCheck = 1;
    }
    private void OnTriggerExit(Collider other)
    {
        triggerCheck = 0;
    }
    private void Update()
    {
        if (triggerCheck == 1)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                rb = theCar.GetComponent<Rigidbody>();
                rb.constraints = RigidbodyConstraints.None;
                theCar.transform.tag = "Player";
                camera.SetActive(true);
                player.SetActive(false);
                audio = theCar.GetComponent<AudioSource>();
                if (audio != null)
                    audio.enabled = true;
                
                theCar.GetComponent<CarController>().enabled = true;
                theCar.GetComponent<CarUserControl>().enabled = true;
                theCar.GetComponent<CarAudio>().enabled = true;
                exitTrigger.SetActive(true);
                

            }
        }
    }


}
