using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class timeToStart : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float countdownTime = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player.GetComponent<CarController>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(countdownTime > 0)
        {
            countdownTime -= Time.deltaTime;
        }
        else
        {
            player.GetComponent<CarController>().enabled = true;
        }
    }
}
