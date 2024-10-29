
using Unity.VisualScripting;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header ("Patrol Bounds")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Params")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    [SerializeField] private Animator animate;
    

    private void Awake()
    {
        initScale = enemy.localScale;
    }

    private void Update()
    {
        if(movingLeft)
        {
           if(enemy.position.x >= leftEdge.position.x)
           {
                MoveDirection(-1);
           }
           else{
                ChangeDirection();
           }
            
        }
        else{
            if(enemy.position.x <= rightEdge.position.x)
            {
                MoveDirection(1);
            }
            else{
                ChangeDirection();
            }
            
        }
    }

    private void ChangeDirection()
    {
        animate.SetBool("moving", false);
        movingLeft = !movingLeft;
    }

    private void MoveDirection(int direction)
    {
        animate.SetBool("moving", true);

        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * direction, initScale.y, initScale.z);

        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * direction * speed, enemy.position.y, enemy.position.z);

    }

}
