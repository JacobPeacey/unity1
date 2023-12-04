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
    [SerializeField] private float fireElapsedTime = 0;
    [SerializeField] private Vector3 initalPosition;
   

    //Start
    void Start()
    {
        initalPosition = transform.position;
	    player = GameObject.Find("Player");
    }

    //Update
    void Update()
    {
	    //Make the enemy look at the player
	    transform.LookAt(player.transform);

	    //Move the enemy towards the player
	   
 
        if (fireElapsedTime > 1)
        { 
          Shoot();
          fireElapsedTime = 0;
        }
        else 
        {
            fireElapsedTime = fireElapsedTime + Time.deltaTime; 
        }

        if (this.transform.position.y < -10)
        {
            transform.position = new Vector3(0,5,0);
        }    
    }   

    void Shoot()
    {
        if(Vector3.Distance(transform.position, player.transform.position) >= minDistance)
	    {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
           

        
	    } 
    }
}
