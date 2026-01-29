using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
   private Animator anim;
   private PlayerMovements playerMovements;
   [SerializeField] private float attackCooldown;
   private float cooldownTimer;
   [SerializeField] Transform firePoint;
   [SerializeField] GameObject[] fireballs;
   


    private void Awake()
    {
        anim=GetComponent<Animator>();
        playerMovements=GetComponent<PlayerMovements>();
    }
    private void Update()
    {
        if (Input.GetMouseButton(0)&& cooldownTimer > attackCooldown && playerMovements.canAttack())
        
            Attack();
            cooldownTimer +=Time.deltaTime;
    
    }
     private void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer=0;

        fireballs[FindFireball()].transform.position= firePoint.position; // fireballs firepoint kısmından gidiyor her seferinde ateşlendiğinde
        fireballs[FindFireball()].GetComponent<projectile>().SetDirection(Mathf.Sign(transform.localScale.x));

    }
    private int FindFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
