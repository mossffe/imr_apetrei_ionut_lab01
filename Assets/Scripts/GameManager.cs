using Unity.VisualScripting;
using UnityEngine;
using Vuforia;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform cactusTracker;
    [SerializeField] Transform dogTracker;

    Transform cactus;
    Transform dog;

    Animator cactusAnimator;
    Animator dogAnimator;

    void Start()
    {
        cactus = cactusTracker.GetChild(0);
        dog = dogTracker.GetChild(0);

        cactusAnimator = cactus.GetComponent<Animator>();
        dogAnimator = dog.GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 cactusPos = cactus.GetComponent<Transform>().position;
        Vector3 dogPos = dog.GetComponent<Transform>().position;

        if(Vector3.Distance(cactusPos, dogPos) < 0.15) // 15 cm
        {
            cactusAnimator.SetBool("LeaveAttack", false);
            dogAnimator.SetBool("LeaveAttack", false);
            cactusAnimator.SetBool("EnterAttack", true);
            dogAnimator.SetBool("EnterAttack", true);
        }
        else
        {
            cactusAnimator.SetBool("EnterAttack", false);
            dogAnimator.SetBool("EnterAttack", false);
            cactusAnimator.SetBool("LeaveAttack", true);
            dogAnimator.SetBool("LeaveAttack", true);
        }
    }
}
