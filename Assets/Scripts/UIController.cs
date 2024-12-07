using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private Slider speedSlider;

    [SerializeField]
    private Slider speedSliderSecondCar;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject secondCar;

    [SerializeField]
    private GameObject pausePanel;

    private bool pauseActivated;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pausePanel.SetActive(false);

        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<CarController>().enabled)
        {
            speedSlider.value = player.GetComponent<CarController>().CurrentSpeed;
        }

        if (SceneManager.GetActiveScene().name != "1Car")
        {
            if (secondCar.GetComponent<CarController>().enabled)
            {
                speedSliderSecondCar.value = secondCar.GetComponent<CarController>().CurrentSpeed;
            }
        }

            if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu();
        }
    }

    public void PauseMenu()
    {
        if (!pauseActivated)
        {
            pauseActivated = true;
            pausePanel.SetActive(true);
            Time.timeScale = 0.0f;
        }
        else
        {
            pauseActivated = false;
            pausePanel.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }
}
