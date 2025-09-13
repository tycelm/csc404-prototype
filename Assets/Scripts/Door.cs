using UnityEngine;

public class Door : Interactable
{
    [SerializeField] private Transform Destination;
    [SerializeField] private float range = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    public override void Interact()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        if (players.Length == 0)
        {
            Debug.Log("No players found.");
            return;
        }

        // Find closest player
        GameObject closestPlayer = null;
        float closestDist = Mathf.Infinity;

        foreach (GameObject p in players)
        {
            float dist = Vector3.Distance(transform.position, p.transform.position);
            if (dist < closestDist)
            {
                closestDist = dist;
                closestPlayer = p;
            }
        }

        // Check if close enough
        if (closestPlayer != null && closestDist <= range)
        {
            CharacterController charControl = closestPlayer.GetComponent<CharacterController>();
            charControl.enabled = false;
            closestPlayer.transform.position = Destination.position;
            charControl.enabled = true;
            Debug.Log("Teleported closest player: " + closestPlayer.name);
        }
        else
        {
            Debug.Log("No player close enough to use the door.");
        }
    }
}
