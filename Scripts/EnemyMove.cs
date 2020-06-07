using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyMove : MonoBehaviour
{
    public Transform weaponPosition;
    public Camera cam;
    public NavMeshAgent agent;
    public FieldOfView fow;
    public GameObject bullet;
    public Animator anim;
    public bool isDead = false;
    Ray thugRay;
    public Color rayColor;
    bool isShooting = false;
    public bool isGoing = false;
    public bool isGetHit = false;
    int angle;
    public int hp;
    public Vector3 currentDestination;

    public float degreesPerSecound;
    [SerializeField]
    private Transform damagePopupTransform;
    List<Transform> temporary;
    private void FixedUpdate()
    {
        if (isDead == false)
        {
            temporary = new List<Transform>(fow.visibleTargets);
            Vector3 dirFroMeToDestination = (currentDestination - transform.position);

            if (temporary.Count != 0)
            {
                Vector3 dirFroMeToPlayer = (temporary[0].position - transform.position);
                dirFroMeToPlayer.y = 0.0f;
                Quaternion lookRotation = Quaternion.LookRotation(dirFroMeToPlayer);

                transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 100 * degreesPerSecound / 360f);
            }
            if (isGetHit == false && temporary.Count == 0)
            {
                dirFroMeToDestination.y = 0.0f;
                if (dirFroMeToDestination != Vector3.zero)
                {
                    Quaternion lookRotation = Quaternion.LookRotation(dirFroMeToDestination);

                    transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 100 * degreesPerSecound / 360f);
                }
            }

            if (isGetHit == true && temporary.Count == 0)
            {
                transform.Rotate(0, 8, 0);
            }

            thugRay = new Ray(transform.position, transform.forward * 10);
            Debug.DrawRay(transform.position, transform.forward * 100, Color.green);
            if (temporary.Count != 0)
            {
                if (isDead == false)
                {
                    StartCoroutine(RotateToPlayer());
                }
            }

            else
            {
                agent.isStopped = false;
                isShooting = false;
                if (isGoing == false)
                {
                    StartCoroutine(GoToDestination());
                }
            }

            if (isDead == true)
            {
                StopAllCoroutines();
            }
        }
    }
    public void HeadshotHit()
    {
        if (isDead == false)
        {
            isGetHit = true;
            TakeDamage(100);
            hp -= 100;
            CheckHp();
            StartCoroutine(Wait());
        }
    }

    public void ChestCollider()
    {
        if (isDead == false)
        {
            int damage = Random.Range(28, 40);
            isGetHit = true;
            TakeDamage(damage);
            hp -= damage;
            CheckHp();
            StartCoroutine(Wait());
        }
    }

    public void KnifeColider()
    {
        if (isDead == false)
        {
            int damage = Random.Range(45, 55);
            isGetHit = true;
            TakeDamage(damage);
            hp -= damage;
            CheckHp();
            StartCoroutine(Wait());
        }
    }

    public void LegCollider()
    {
        if (isDead == false)
        {
            int damage = Random.Range(2, 18);
            isGetHit = true;
            TakeDamage(damage);
            hp -= damage;
            CheckHp();
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.4f);
        isGetHit = false;
    }

    public void RotateEnemy()
    {
        if (isDead == false)
        {
            transform.Rotate(new Vector3(10, 10, 10), 90);
        }
    }

    public void CheckHp()
    {
        if (hp <= 0)
        {
            StopAllCoroutines();
            if (gameObject.layer == 11)
            {
                GamePlayData.Instance.DecreaseEnemyAmount();
            }
            if (gameObject.layer == 9)
            {
                GamePlayData.Instance.DecreaseFriendlyAmount();
            }
            temporary.Clear();
            StartCoroutine(WaitFour());
            anim.Play("dead");
            agent.isStopped = true;
            isDead = true;
        }
    }

    IEnumerator WaitFour()
    {
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }

    IEnumerator RotateToPlayer()
    {
        if (isDead == false)
        {
            yield return new WaitForSeconds(0.5f);
            if (temporary.Count != 0)
            {
                if (!isShooting)
                {
                    if (isDead == false)
                    {
                        StartCoroutine(ExampleCoroutine());
                        isShooting = true;
                    }
                }
            }
        }
    }

    IEnumerator GoToDestination()
    {
        anim.Play("Walk");
        isGoing = true;
        int x = Random.Range(95, 185);
        int z = Random.Range(93, 193);
        currentDestination = new Vector3(x, 0, z);

        while (temporary.Count == 0)
        {
            if (isDead == false)
            {
                agent.SetDestination(currentDestination);
                yield return new WaitForSeconds(4f);
                isGoing = false;
            }
        }
    }

    IEnumerator ExampleCoroutine()
    {
        while (temporary.Count != 0 && isDead == false)
        {
            if (temporary.Count == 0)
            {
                break;
            }

            float distance = Vector3.Distance(this.transform.position, temporary[0].position);
            if (distance > 30)
            {
                if (temporary.Count == 0)
                {
                    break;
                }
                float randomAngle = Random.Range(-3f, 0f);
                float angle = distance / 6.2f;
                weaponPosition.transform.localRotation = Quaternion.Euler(-angle + randomAngle, 0, 0);

                Instantiate(bullet, weaponPosition.position, weaponPosition.rotation);
                SoundManager.Instance.ShootSound();
                yield return new WaitForSeconds(0.5f);

            }

            if (distance < 30 && distance > 14)
            {
                if (temporary.Count == 0)
                {
                    break;
                }
                float randomAngle = Random.Range(-3f, -2f);
                float angle = distance / 8.5f;
                weaponPosition.transform.localRotation = Quaternion.Euler(-angle + randomAngle, 0, 0);

                Instantiate(bullet, weaponPosition.position, weaponPosition.rotation);
                SoundManager.Instance.ShootSound();
                yield return new WaitForSeconds(0.5f);

            }
            if (distance <= 14)
            {
                if (temporary.Count == 0)
                {
                    break;
                }
                float randomAngle = Random.Range(0f, 10f);
                float angle = 1.5f;
                weaponPosition.transform.localRotation = Quaternion.Euler(angle + randomAngle, 0, 0);
                Instantiate(bullet, weaponPosition.position, weaponPosition.rotation);
                SoundManager.Instance.ShootSound();
                yield return new WaitForSeconds(0.5f);
            }
        }
    }


    public void TakeDamage(int amount)
    {
        DamagePopUpManager.instance.DisplayDamagePopUp(amount, damagePopupTransform);
    }
}













