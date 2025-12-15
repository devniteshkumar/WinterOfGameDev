using UnityEngine;

public class ZombieFollower : MonoBehaviour
{
    public float moveSpeed=4f;
    Transform player;
    Rigidbody2D rb;
    public float AttackRange=1f;
    Animator anim;
    void Start(){
        GameObject playerObj=GameObject.FindGameObjectWithTag("Player");
        rb=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        player=playerObj.transform;
    }

    void Update(){
        if(player!=null){
            Vector2 moveDir=(player.position-transform.position).normalized;
            float dist=Vector2.Distance(player.position, transform.position);
            if(dist>AttackRange){
                rb.linearVelocity=moveDir*moveSpeed;
            }
            else{
                rb.linearVelocity=Vector2.zero;
                anim.SetTrigger("Attack");
            }
        }
    }
}
