using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    private GameObject lastCheckpoint;

    [SerializeField]
    private GameObject warningMessage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        warningMessage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (lastCheckpoint != null)
            {
                this.gameObject.transform.position = lastCheckpoint.transform.GetChild(0).position;
                this.gameObject.transform.rotation = lastCheckpoint.transform.GetChild(0).rotation;
                CancelInvoke("ShowWarningMessage");
                warningMessage.SetActive(false);
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
            Invoke("ShowWarningMessage", 1.5f);
        }
    }

    public void ShowWarningMessage()
    {
        warningMessage.SetActive(true);
    }
}
