using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    public enum EnemyType
    { 
        STEALANDRUN,
        IDLE,
        ARREST

     }
    public EnemyType enemyType;

    [SerializeField] float Range;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
