using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private Slider speedSlider;

    [SerializeField]
    private GameObject player;

    private float currentTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<CarController>().enabled)
        {
            speedSlider.value = player.GetComponent<CarController>().CurrentSpeed;
        }
    }
}
