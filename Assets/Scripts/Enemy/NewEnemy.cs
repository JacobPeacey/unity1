using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemy : MonoBehaviour
{
    //variables
    private GameObject player;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float health = 10f;
    [SerializeField] private float minDistance = 5f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject bulletSpawnPoint;


    //Start
    void Start()
    {
	    player = GameObject.Find("Player");
    }

    //Update
    void Update()
    {
	    //Make the enemy look at the player
	    transform.LookAt(player.transform);

	    //Move the enemy towards the player
	    transform.position += transform.forward * speed * Time.deltaTime;

	    //Shoot the player if the enemy is far enough away
	    if(Vector3.Distance(transform.position, player.transform.position) >= minDistance)
	    {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
	    }
    }   
}
