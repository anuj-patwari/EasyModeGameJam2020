using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] int keyID;
   

    public IEnumerator Open()
    {
        GetComponent<Rigidbody>().AddForce(transform.up * 1000);
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.GetComponent<PlayerController>().SearchForKey(keyID) == true)
            {
                StartCoroutine(Open());
            }

        }
    }
}
