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

    public GameObject fuelObject;
    public Slider fuelSlider;
    public int fuelFallRate;
    public int maxFuel;


    private void OnTriggerEnter(Collider other)
    {
        triggerCheck = 1;
    }
    private void OnTriggerExit(Collider other)
    {
        triggerCheck = 0;
    }
    private void Start()
    {
        fuelSlider.maxValue = maxFuel;
        fuelSlider.value = maxFuel;
        
    }
    private void Update()
    {
        if (triggerCheck == 1)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                CarActivate();
            }
        }
        if (fuelSlider.value >= 0 && triggerCheck==1)
        {
            fuelSlider.value -= Time.deltaTime / fuelFallRate * 10;
        }
        if (fuelSlider.value <= 0)
        {
            NoFuel();
        }
    }
    private void CarActivate()
    {
        fuelObject.SetActive(true);
        if (fuelSlider.value >= 0)
        {
            fuelSlider.value -= Time.deltaTime / fuelFallRate * 10;
        }
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
    private void NoFuel()
    {
        theCar.GetComponent<CarController>().enabled = false;
        theCar.GetComponent<CarUserControl>().enabled = false;
        theCar.GetComponent<CarAudio>().enabled = false;
    }


}
