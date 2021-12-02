using UnityEngine;
[RequireComponent(typeof(Animator))]
public class animationExplode : MonoBehaviour
{
    Animator animator;
    float speed;
    bool isExploding = false;

    void Start()
    {
        //Get Animator component
        animator = GetComponent<Animator>();
        speed = animator.GetFloat("AnimationSpeed");
    }

public void Explosion()
    {
        if (isExploding == false)
        {
            //Add a Tag value to the animation block, select the animation block from the Animator Controlelr and set its Tag in the Inspector
            if (animator.GetCurrentAnimatorStateInfo(0).IsTag("1"))
            {
                speed = 1;
                animator.SetFloat("AnimationSpeed", speed);
                isExploding = true;
            }
            else
            {
                animator.SetTrigger("explodeTrigger");
                isExploding = true;
            }

        }

        else
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsTag("1"))
            {
                speed = -1;
                animator.SetFloat("AnimationSpeed", speed);
                isExploding = false;
            }
            else
            {
                speed = -1;
                animator.SetFloat("AnimationSpeed", speed);
                animator.SetTrigger("explodeTrigger");
                isExploding = false;
            }

        }
    }
    void Update()
    {

        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("1") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            animator.Play("Scene", -1, 1);
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsTag("1") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 0)
        {
            animator.Play("Scene", -1, 0);
        }

        //Play animation on key press
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //Add a Tag value to the animation block, select the animation block from the Animator Controlelr and set its Tag in the Inspector
            if (animator.GetCurrentAnimatorStateInfo(0).IsTag("1"))
            {
                speed = 1;
                animator.SetFloat("AnimationSpeed", speed);
            }
            else { animator.SetTrigger("explodeTrigger"); }
        }
        //Reverse animation on key press
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsTag("1"))
            {
                speed = -1;
                animator.SetFloat("AnimationSpeed", speed);
            }
            else
            {
                speed = -1;
                animator.SetFloat("AnimationSpeed", speed);
                animator.SetTrigger("explodeTrigger");
            }
        }

    }
}