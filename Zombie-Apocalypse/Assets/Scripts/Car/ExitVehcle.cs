using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class ExitVehcle : MonoBehaviour {

    public GameObject camera;
    public GameObject player;
    public GameObject exitTrigger;
    public GameObject theCar;
    public GameObject exitPlace;
    private Rigidbody rb;


  
    private void Update()
    {
      if (Input.GetKeyDown(KeyCode.F))
        {
            rb = theCar.GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.FreezePositionX;
            theCar.transform.tag = "Untagged";
            camera.SetActive(false);
            player.SetActive(true);
            player.transform.position = exitPlace.transform.position;
            theCar.GetComponent<CarController>().enabled = false;
            theCar.GetComponent<CarUserControl>().enabled = false;
            theCar.GetComponent<CarAudio>().enabled = false;
            theCar.GetComponent<AudioSource>().enabled = false;
            exitTrigger.SetActive(false);
        }
        
    }

}
