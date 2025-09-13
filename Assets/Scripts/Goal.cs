using UnityEngine;

public class Goal : MonoBehaviour
{
    bool emergency;

    void Start()
    {
        emergency = false;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            Debug.Log("Hand entered trigger: " + other.name);
            EmergencyEvent();
        }
    }

    void EmergencyEvent()
    {
        emergency = true;

    }

    public void StopEmergency()
    {
        emergency = false;
    }
}
