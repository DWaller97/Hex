using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Animal : MonoBehaviour
{
    public enum Diet{
        Herbivore,
        Carnivore,
        Omnivore
    };
    public int health, movementSpeed, strength, sightWidth = 5, sightDistance = 10;
    public Diet diet;

    private NavMeshAgent agent;
    private NavMeshPath path;
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void LookAround(){

    }
    private void Update()
    {
    }

    /// <summary>
    /// Callback to draw gizmos that are pickable and always drawn.
    /// </summary>
    void OnDrawGizmos()
    {
    }


}
