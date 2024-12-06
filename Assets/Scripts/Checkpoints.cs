using System.Security.Authentication.ExtendedProtection;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;
using UnityEngine.SceneManagement;

public class Checkpoints : MonoBehaviour
{
    private GameObject lastCheckpoint;

    [SerializeField]
    private GameObject warningMessage;

    public bool midleCheckpointPassed;
    public bool finalCheckpointPassed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        midleCheckpointPassed = false;
        finalCheckpointPassed = false;
        //warningMessage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (lastCheckpoint != null && this.gameObject.tag == "Player")
            {
                this.gameObject.transform.position = lastCheckpoint.transform.GetChild(0).position + new Vector3(-2.0f, 0.0f, 0.0f);
                this.gameObject.transform.rotation = lastCheckpoint.transform.GetChild(0).rotation;
                CancelInvoke("ShowWarningMessage");
                //warningMessage.SetActive(false);
                warningMessage.transform.GetChild(0).gameObject.SetActive(false);
                this.GetComponent<CarController>().enabled = true;
                this.GetComponent<CarController>().m_Rigidbody.linearVelocity = Vector3.zero;
            }
        }

        if (Input.GetKeyDown(KeyCode.M))
        {            
            if (lastCheckpoint != null && this.gameObject.tag == "SecondCar")
            {
                gameObject.transform.position = lastCheckpoint.transform.GetChild(0).position + new Vector3(2.0f, 0.0f, 0.0f);
                gameObject.transform.rotation = lastCheckpoint.transform.GetChild(0).rotation;
                CancelInvoke("ShowWarningMessageP2");
                //warningMessage.SetActive(false);
                warningMessage.transform.GetChild(1).gameObject.SetActive(false);
                this.GetComponent<CarController>().enabled = true;
                this.GetComponent<CarController>().m_Rigidbody.linearVelocity = Vector3.zero;
            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Checkpoint")
        {
            if(other.gameObject.name == "Checkpoint1")
            {
                midleCheckpointPassed = true;
            }
            if (other.gameObject.name == "Checkpoint2")
            {
                finalCheckpointPassed = true;
            }

            lastCheckpoint = other.gameObject;
        }
        if (other.gameObject.tag == "Terrain")
        {
            if (SceneManager.GetActiveScene().name == "1Car")
            {
                Invoke("ShowWarningMessage", 1.5f);
            }

            if (SceneManager.GetActiveScene().name == "2Car")
            {
                if (this.gameObject.tag == "Player")
                {
                    Invoke("ShowWarningMessage", 1.5f);
                }
                else if (this.gameObject.tag == "SecondCar")
                {
                    Invoke("ShowWarningMessageP2", 1.5f);
                }
            }
            
            StopCar();
        }
    }
    

    public void ShowWarningMessage()
    {
        //warningMessage.SetActive(true);
        warningMessage.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void ShowWarningMessageP2()
    {
       // warningMessage.SetActive(true);
        warningMessage.transform.GetChild(1).gameObject.SetActive(true);
    }

    public void StopCar()
    {
        this.GetComponent<CarController>().enabled = false;
    }
}
