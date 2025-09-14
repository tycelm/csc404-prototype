using UnityEngine;

public class HeadConsole : Interactable
{
    [SerializeField] private float range = 3f;
    public override void Interact(GameObject player)
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

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

        }
    }
}
