using NUnit.Framework.Internal.Filters;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarSelectedParameters : MonoBehaviour
{
    [SerializeField]
    private GameObject wheelHubs;
    [SerializeField]
    private GameObject playerCars;
    [SerializeField]
    private GameObject collidersCar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "1Car")
        {
            int carSelected = PlayerPrefs.GetInt("CARSELECTED");

            playerCars.gameObject.transform.GetChild(0).gameObject.SetActive(false);

            playerCars.gameObject.transform.GetChild(carSelected).gameObject.SetActive(true);

            if (carSelected == 0)
            {
                wheelHubs.gameObject.transform.GetChild(0).gameObject.transform.localPosition = new Vector3(0.7f, 0.54f, 1.27f);
                wheelHubs.gameObject.transform.GetChild(1).gameObject.transform.localPosition = new Vector3(0.71f, 0.54f, -1.76f);
                wheelHubs.gameObject.transform.GetChild(2).gameObject.transform.localPosition = new Vector3(-0.7f, 0.54f, 1.27f);
                wheelHubs.gameObject.transform.GetChild(3).gameObject.transform.localPosition = new Vector3(-0.71f, 0.54f, -1.76f);

                collidersCar.gameObject.transform.GetChild(1).gameObject.GetComponent<BoxCollider>().center = new Vector3(0, 0.84f, 0.03f);
                collidersCar.gameObject.transform.GetChild(1).gameObject.GetComponent<BoxCollider>().size = new Vector3(1.07f, 2.68f, 1.13f);
            }
            if (carSelected == 1)
            {
                wheelHubs.gameObject.transform.GetChild(0).gameObject.transform.localPosition = new Vector3(0.6f, 0.54f, 1.18f);
                wheelHubs.gameObject.transform.GetChild(1).gameObject.transform.localPosition = new Vector3(0.6f, 0.54f, -1.86f);
                wheelHubs.gameObject.transform.GetChild(2).gameObject.transform.localPosition = new Vector3(-0.6f, 0.54f, 1.18f);
                wheelHubs.gameObject.transform.GetChild(3).gameObject.transform.localPosition = new Vector3(-0.6f, 0.54f, -1.86f);

                collidersCar.gameObject.transform.GetChild(1).gameObject.GetComponent<BoxCollider>().center = new Vector3(0, 1.06f, 0.03f);
                collidersCar.gameObject.transform.GetChild(1).gameObject.GetComponent<BoxCollider>().size = new Vector3(1f, 3.12f, 1.19f);
            }
            if (carSelected == 2)
            {
                wheelHubs.gameObject.transform.GetChild(0).gameObject.transform.localPosition = new Vector3(0.6f, 0.54f, 1.15f);
                wheelHubs.gameObject.transform.GetChild(1).gameObject.transform.localPosition = new Vector3(0.6f, 0.54f, -2.08f);
                wheelHubs.gameObject.transform.GetChild(2).gameObject.transform.localPosition = new Vector3(-0.6f, 0.54f, 1.15f);
                wheelHubs.gameObject.transform.GetChild(3).gameObject.transform.localPosition = new Vector3(-0.6f, 0.54f, -2.08f);

                collidersCar.gameObject.transform.GetChild(1).gameObject.GetComponent<BoxCollider>().center = new Vector3(0, 2.21f, -0.06f);
                collidersCar.gameObject.transform.GetChild(1).gameObject.GetComponent<BoxCollider>().size = new Vector3(1.07f, 5.43f, 1.37f);
            }
            if (carSelected == 3)
            {
                wheelHubs.gameObject.transform.GetChild(0).gameObject.transform.localPosition = new Vector3(0.6f, 0.54f, 1.45f);
                wheelHubs.gameObject.transform.GetChild(1).gameObject.transform.localPosition = new Vector3(0.6f, 0.54f, -1.58f);
                wheelHubs.gameObject.transform.GetChild(2).gameObject.transform.localPosition = new Vector3(-0.6f, 0.54f, 1.45f);
                wheelHubs.gameObject.transform.GetChild(3).gameObject.transform.localPosition = new Vector3(-0.6f, 0.54f, -1.58f);

                collidersCar.gameObject.transform.GetChild(1).gameObject.GetComponent<BoxCollider>().center = new Vector3(0, 2.21f, 0.02f);
                collidersCar.gameObject.transform.GetChild(1).gameObject.GetComponent<BoxCollider>().size = new Vector3(1.07f, 5.43f, 1.21f);
            }
            if (carSelected == 4)
            {
                wheelHubs.gameObject.transform.GetChild(0).gameObject.transform.localPosition = new Vector3(0.6f, 0.54f, 1.52f);
                wheelHubs.gameObject.transform.GetChild(1).gameObject.transform.localPosition = new Vector3(0.6f, 0.54f, -2.32f);
                wheelHubs.gameObject.transform.GetChild(2).gameObject.transform.localPosition = new Vector3(-0.6f, 0.54f, 1.52f);
                wheelHubs.gameObject.transform.GetChild(3).gameObject.transform.localPosition = new Vector3(-0.6f, 0.54f, -2.32f);

                collidersCar.gameObject.transform.GetChild(1).gameObject.GetComponent<BoxCollider>().center = new Vector3(0, 3.42f, -0.08f);
                collidersCar.gameObject.transform.GetChild(1).gameObject.GetComponent<BoxCollider>().size = new Vector3(1.07f, 7.8f, 1.43f);
            }
            if (carSelected == 5)
            {
                wheelHubs.gameObject.transform.GetChild(0).gameObject.transform.localPosition = new Vector3(0.8f, 0.54f, 1.23f);
                wheelHubs.gameObject.transform.GetChild(1).gameObject.transform.localPosition = new Vector3(0.8f, 0.54f, -2f);
                wheelHubs.gameObject.transform.GetChild(2).gameObject.transform.localPosition = new Vector3(-0.8f, 0.54f, 1.23f);
                wheelHubs.gameObject.transform.GetChild(3).gameObject.transform.localPosition = new Vector3(-0.8f, 0.54f, -2f);

                collidersCar.gameObject.transform.GetChild(1).gameObject.GetComponent<BoxCollider>().center = new Vector3(0, 3.18f, -0.11f);
                collidersCar.gameObject.transform.GetChild(1).gameObject.GetComponent<BoxCollider>().size = new Vector3(1.23f, 7.3f, 1.49f);
            }
        }        
    }
}
