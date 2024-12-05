using NUnit.Framework.Internal.Filters;
using UnityEngine;

public class CarSelectedParameters : MonoBehaviour
{
    [SerializeField]
    private GameObject wheelHubs;
    [SerializeField]
    private GameObject playerCars;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int carSelected = PlayerPrefs.GetInt("CARSELECTED");

        playerCars.gameObject.transform.GetChild(0).gameObject.SetActive(false);

        playerCars.gameObject.transform.GetChild(carSelected).gameObject.SetActive(true);

        if(carSelected == 0)
        {
            wheelHubs.gameObject.transform.GetChild(0).gameObject.transform.localPosition = new Vector3(0.7f, 0.54f, 1.27f);
            wheelHubs.gameObject.transform.GetChild(1).gameObject.transform.localPosition = new Vector3(0.71f, 0.54f, -1.76f);
            wheelHubs.gameObject.transform.GetChild(2).gameObject.transform.localPosition = new Vector3(-0.7f, 0.54f, 1.27f);
            wheelHubs.gameObject.transform.GetChild(3).gameObject.transform.localPosition = new Vector3(-0.71f, 0.54f, -1.76f);
        }
        if (carSelected == 1)
        {
            wheelHubs.gameObject.transform.GetChild(0).gameObject.transform.localPosition = new Vector3(0.6f, 0.54f, 1.18f);
            wheelHubs.gameObject.transform.GetChild(1).gameObject.transform.localPosition = new Vector3(0.6f, 0.54f, -1.86f);
            wheelHubs.gameObject.transform.GetChild(2).gameObject.transform.localPosition = new Vector3(-0.6f, 0.54f, 1.18f);
            wheelHubs.gameObject.transform.GetChild(3).gameObject.transform.localPosition = new Vector3(-0.6f, 0.54f, -1.86f);
        }
        if (carSelected == 2)
        {
            wheelHubs.gameObject.transform.GetChild(0).gameObject.transform.localPosition = new Vector3(0.6f, 0.54f, 1.15f);
            wheelHubs.gameObject.transform.GetChild(1).gameObject.transform.localPosition = new Vector3(0.6f, 0.54f, -2.08f);
            wheelHubs.gameObject.transform.GetChild(2).gameObject.transform.localPosition = new Vector3(-0.6f, 0.54f, 1.15f);
            wheelHubs.gameObject.transform.GetChild(3).gameObject.transform.localPosition = new Vector3(-0.6f, 0.54f, -2.08f);
        }
        if (carSelected == 3)
        {
            wheelHubs.gameObject.transform.GetChild(0).gameObject.transform.localPosition = new Vector3(0.6f, 0.54f, 1.45f);
            wheelHubs.gameObject.transform.GetChild(1).gameObject.transform.localPosition = new Vector3(0.6f, 0.54f, -1.58f);
            wheelHubs.gameObject.transform.GetChild(2).gameObject.transform.localPosition = new Vector3(-0.6f, 0.54f, 1.45f);
            wheelHubs.gameObject.transform.GetChild(3).gameObject.transform.localPosition = new Vector3(-0.6f, 0.54f, -1.58f);
        }
        if (carSelected == 4)
        {
            wheelHubs.gameObject.transform.GetChild(0).gameObject.transform.localPosition = new Vector3(0.6f, 0.54f, 1.52f);
            wheelHubs.gameObject.transform.GetChild(1).gameObject.transform.localPosition = new Vector3(0.6f, 0.54f, -2.32f);
            wheelHubs.gameObject.transform.GetChild(2).gameObject.transform.localPosition = new Vector3(-0.6f, 0.54f, 1.52f);
            wheelHubs.gameObject.transform.GetChild(3).gameObject.transform.localPosition = new Vector3(-0.6f, 0.54f, -2.32f);
        }
        if (carSelected == 5)
        {
            wheelHubs.gameObject.transform.GetChild(0).gameObject.transform.localPosition = new Vector3(0.8f, 0.54f, 1.23f);
            wheelHubs.gameObject.transform.GetChild(1).gameObject.transform.localPosition = new Vector3(0.8f, 0.54f, -2f);
            wheelHubs.gameObject.transform.GetChild(2).gameObject.transform.localPosition = new Vector3(-0.8f, 0.54f, 1.23f);
            wheelHubs.gameObject.transform.GetChild(3).gameObject.transform.localPosition = new Vector3(-0.8f, 0.54f, -2f);
        }
    }
}
