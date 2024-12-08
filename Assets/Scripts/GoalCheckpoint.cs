using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalCheckpoint : MonoBehaviour
{
    [SerializeField]
    private GameObject record;
    [SerializeField]
    private GameObject recordSecondCar;
    [SerializeField]
    private GameObject recordThirdCar;
    [SerializeField]
    private GameObject recordFourthCar;

    private bool recordSaved;
    private bool recordSavedSecondCar;
    private bool recordSavedThirdCar;
    private bool recordSavedFourthCar;

    private int player1GoalDetector; //Es un contador. El coche pasa dos veces por meta, en la salida y en la llegada. Se guardar� el tiempo la segunda vez.
    private int player2GoalDetector;
    private int player3GoalDetector;
    private int player4GoalDetector;

    [SerializeField]
    private GameObject winner;

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject playerSecondCar;
    [SerializeField]
    private GameObject playerThirdCar;
    [SerializeField]
    private GameObject playerFourthCar;

    private string recordNow;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player1GoalDetector = 0;
        player2GoalDetector = 0;
        recordSaved = false;
        recordSavedSecondCar = false;
        recordSavedThirdCar = false;
        recordSavedFourthCar = false;

        if (!PlayerPrefs.HasKey("RECORDTIME"))
        {
            PlayerPrefs.SetFloat("RECORDTIME", 300.0f);
        }
        UpdateRecordTexts();
    }

    public void UpdateRecordTexts()
    {
        recordNow = TimeSpan.FromSeconds(PlayerPrefs.GetFloat("RECORDTIME")).ToString("mm':'ss'.'ff");

        record.GetComponent<TMP_Text>().text = recordNow;

        if (SceneManager.GetActiveScene().name == "2Car" || SceneManager.GetActiveScene().name == "4Car")
        {
            recordSecondCar.GetComponent<TMP_Text>().text = recordNow;
        }

        if (SceneManager.GetActiveScene().name == "4Car")
        {
            recordThirdCar.GetComponent<TMP_Text>().text = recordNow;
            recordFourthCar.GetComponent<TMP_Text>().text = recordNow;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Delete))
        {
            PlayerPrefs.SetFloat("RECORDTIME", 300.0f);

            UpdateRecordTexts();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player1GoalDetector++; //Suma uno al detector del player 1
        }
        
        else if (other.gameObject.tag == "SecondCar")
        {
            player2GoalDetector++; //Suma uno al detector del player 2
        }

        else if (other.gameObject.tag == "ThirdCar")
        {
            player3GoalDetector++; //Suma uno al detector del player 3
        }

        else if (other.gameObject.tag == "FourthCar")
        {
            player4GoalDetector++; //Suma uno al detector del player 4
        }

        if (player1GoalDetector >= 2 && !recordSaved && player.gameObject.GetComponent<Checkpoints>().midleCheckpointPassed && player.gameObject.GetComponent<Checkpoints>().finalCheckpointPassed) 
        {
            recordSaved = true;

            if(timeToStart.gameTime.TotalSeconds < PlayerPrefs.GetFloat("RECORDTIME"))
            {
                PlayerPrefs.SetFloat("RECORDTIME", (float)timeToStart.gameTime.TotalSeconds);
            }

            winner.gameObject.SetActive(true);
            winner.transform.GetChild(1).gameObject.SetActive(true);

            CancelInvoke("GoToMainmenu");
            Invoke("GoToMainmenu", 3.0f);
        }

        if (player2GoalDetector >= 2 && !recordSavedSecondCar && playerSecondCar.gameObject.GetComponent<Checkpoints>().midleCheckpointPassed && playerSecondCar.gameObject.GetComponent<Checkpoints>().finalCheckpointPassed)
        {
            recordSavedSecondCar = true;

            if (timeToStart.gameTimeSecondCar.TotalSeconds < PlayerPrefs.GetFloat("RECORDTIME"))
            {
                PlayerPrefs.SetFloat("RECORDTIME", (float)timeToStart.gameTimeSecondCar.TotalSeconds);
            }

            winner.gameObject.SetActive(true);
            winner.transform.GetChild(2).gameObject.SetActive(true);

            CancelInvoke("GoToMainmenu");
            Invoke("GoToMainmenu", 3.0f);
        }

        if (player3GoalDetector >= 2 && !recordSavedThirdCar && playerThirdCar.gameObject.GetComponent<Checkpoints>().midleCheckpointPassed && playerThirdCar.gameObject.GetComponent<Checkpoints>().finalCheckpointPassed)
        {
            recordSavedThirdCar = true;

            if (timeToStart.gameTimeThirdCar.TotalSeconds < PlayerPrefs.GetFloat("RECORDTIME"))
            {
                PlayerPrefs.SetFloat("RECORDTIME", (float)timeToStart.gameTimeThirdCar.TotalSeconds);
            }

            winner.gameObject.SetActive(true);
            winner.transform.GetChild(3).gameObject.SetActive(true);

            CancelInvoke("GoToMainmenu");
            Invoke("GoToMainmenu", 3.0f);
        }

        if (player4GoalDetector >= 2 && !recordSavedFourthCar && playerFourthCar.gameObject.GetComponent<Checkpoints>().midleCheckpointPassed && playerFourthCar.gameObject.GetComponent<Checkpoints>().finalCheckpointPassed)
        {
            recordSavedFourthCar = true;

            if (timeToStart.gameTimeFourthCar.TotalSeconds < PlayerPrefs.GetFloat("RECORDTIME"))
            {
                PlayerPrefs.SetFloat("RECORDTIME", (float)timeToStart.gameTimeFourthCar.TotalSeconds);
            }

            winner.gameObject.SetActive(true);
            winner.transform.GetChild(4).gameObject.SetActive(true);

            CancelInvoke("GoToMainmenu");
            Invoke("GoToMainmenu", 3.0f);
        }

    }

    public void GoToMainmenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
