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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player1GoalDetector = 0;
        player2GoalDetector = 0;
        recordSaved = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("detecta el coche");
            player1GoalDetector++; //Suma uno al detector
        }
        
        else if (other.gameObject.tag == "SecondCar")
        {
            player2GoalDetector++; //Suma uno al detector del player 2
        }

        else if (other.gameObject.tag == "ThirdCar")
        {
            player3GoalDetector++; //Suma uno al detector del player 2
        }

        else if (other.gameObject.tag == "FourthCar")
        {
            player4GoalDetector++; //Suma uno al detector del player 2
        }

        //Pruebas con el detector a 1, pero tiene que ser 2 cuando funcione
        if (player1GoalDetector == 2 && !recordSaved && player.gameObject.GetComponent<Checkpoints>().midleCheckpointPassed && player.gameObject.GetComponent<Checkpoints>().finalCheckpointPassed) 
            //Si el coche pasa una segunda vez por la meta y ha pasado por el checkpoint del medio (aprox) y el �ltimo, guarda el tiempo y acaba la carrera
        {
            recordSaved = true;
            record.GetComponent<TMP_Text>().text = timeToStart.gameTime.ToString("mm':'ss'.'ff");

                if (SceneManager.GetActiveScene().name == "1Car") //Si estamos en la escena 1Car sale este cartelito Lap complete
                {
                    winner.gameObject.SetActive(true);
                    winner.transform.GetChild(0).gameObject.SetActive(true);
                }
                else //Si estamos en las otras escenas 2Car y 4Car se activa player1Wins
                {
                     winner.gameObject.SetActive(true);
                     winner.transform.GetChild(1).gameObject.SetActive(true);
                }
        }

        if (player2GoalDetector == 2 && !recordSavedSecondCar) //Si el coche pasa una segunda vez por la meta guarda el tiempo
        {
            recordSavedSecondCar = true;
            recordSecondCar.GetComponent<TMP_Text>().text = timeToStart.gameTimeSecondCar.ToString("mm':'ss'.'ff");
            winner.gameObject.SetActive(true);
            winner.transform.GetChild(2).gameObject.SetActive(true);      
        }

        if (player3GoalDetector == 2 && !recordSavedThirdCar) //Si el coche pasa una segunda vez por la meta guarda el tiempo
        {
            recordSavedThirdCar = true;
            recordThirdCar.GetComponent<TMP_Text>().text = timeToStart.gameTimeThirdCar.ToString("mm':'ss'.'ff");
            winner.gameObject.SetActive(true);
            winner.transform.GetChild(3).gameObject.SetActive(true);
        }

        if (player4GoalDetector == 2 && !recordSavedFourthCar) //Si el coche pasa una segunda vez por la meta guarda el tiempo
        {
            recordSavedFourthCar = true;
            recordFourthCar.GetComponent<TMP_Text>().text = timeToStart.gameTimeFourthCar.ToString("mm':'ss'.'ff");
            winner.gameObject.SetActive(true);
            winner.transform.GetChild(4).gameObject.SetActive(true);
        }

    }
}
