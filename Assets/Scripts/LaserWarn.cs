using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserWarn : MonoBehaviour
{
    private GameObject player;
    private float laserYOffset = -1.2f;
    SpawnLasers lasers;
    Vector3 laserPos;
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        lasers = Camera.main.GetComponent<SpawnLasers>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BlinkAfter(2.15f));
        StartCoroutine(DestroyAfter(3f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdState(float distance)
    {
        anim.Play(0, 0, distance * 0.01f);
    }

    IEnumerator BlinkAfter(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        anim.SetBool("isBlinking", true);
    }

    IEnumerator DestroyAfter(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(transform.parent.gameObject);
    }

    void OnDestroy()
    {
        laserPos = transform.position;
        laserPos = new Vector3(laserPos.x, laserPos.y + laserYOffset, laserPos.z);
        lasers.SpawnLaser(laserPos);
    }
}
