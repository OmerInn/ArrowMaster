using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public int EnemySize;
    public PlayerController.PlayerStatus enemyStatus;
    [SerializeField] Animator anim;
    public bool Death;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DeathAnim()
    {
        anim.Play("Death");
    }
}
