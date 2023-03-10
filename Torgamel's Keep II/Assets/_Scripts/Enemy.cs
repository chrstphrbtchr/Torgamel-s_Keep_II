using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CheckSurroundings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void MoveEnemy(List<Vector3> mvmt)
    {
        // raycast cardinal directions
        // all unoccupied spots = roll a die
        // move to winning spot.
    }

    List<Vector3> CheckSurroundings()
    {
        Ray[] rayArray = {
            new Ray(transform.position, transform.forward),
            new Ray(transform.position, -transform.forward),
            new Ray(transform.position, -transform.right),
            new Ray(transform.position, transform.right) };
        List<Vector3> directions = new List<Vector3>();

        for(int i = 0; i < rayArray.Length; i++)
        {
            RaycastHit hit;
            Physics.Raycast(rayArray[i], out hit, 2f, 3, QueryTriggerInteraction.Ignore);
            
            if (hit.collider == null)
            {
                directions.Add(rayArray[i].direction);
            }
        }

        return directions;
    }
}
