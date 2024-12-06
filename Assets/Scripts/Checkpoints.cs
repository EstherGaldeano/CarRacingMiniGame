using System.Security.Authentication.ExtendedProtection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoints : MonoBehaviour
{
    private GameObject lastCheckpoint;

    [SerializeField]
    private GameObject warningMessage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //warningMessage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
           
                if (lastCheckpoint != null && this.gameObject.tag == "Player")
                {
                    gameObject.transform.position = lastCheckpoint.transform.GetChild(0).position + new Vector3(-2.0f, 0.0f, 0.0f);
                    gameObject.transform.rotation = lastCheckpoint.transform.GetChild(0).rotation;
                    CancelInvoke("ShowWarningMessage");
                //warningMessage.SetActive(false);
                warningMessage.transform.GetChild(0).gameObject.SetActive(false);
            }
            
        }

        if (Input.GetKeyDown(KeyCode.M) )
        {
            
                if (lastCheckpoint != null && this.gameObject.tag == "SecondCar")
                {

                    gameObject.transform.position = lastCheckpoint.transform.GetChild(0).position + new Vector3(2.0f, 0.0f, 0.0f);
                    gameObject.transform.rotation = lastCheckpoint.transform.GetChild(0).rotation;
                    CancelInvoke("ShowWarningMessageP2");
                    //warningMessage.SetActive(false);
                    warningMessage.transform.GetChild(1).gameObject.SetActive(false);

                }
            
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Checkpoint")
        {
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
}
