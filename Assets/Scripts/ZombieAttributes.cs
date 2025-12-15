using UnityEngine;

public class ZombieAttributes : MonoBehaviour
{
    public float health=50f;
    public float AttackRange=1f;
    public float AttackDamage=5f;
    public LayerMask PlayerLayer;
    void Start()
    {
        
    }

    public void TakeDamage(float damage){
        health-=damage;
        Debug.Log("Zombie health:" + health);
        if(health<=0){
            Destroy(gameObject);
        }
    }
    public void DealDamage(){
        Collider2D hit=Physics2D.OverlapCircle(transform.position,AttackRange, PlayerLayer);
            if(hit!=null){
                hit.GetComponent<PlayerMovement>().health-=AttackDamage;

            }
    }
}
