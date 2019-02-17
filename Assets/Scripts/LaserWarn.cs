using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserWarn : MonoBehaviour
{
    SpawnLasers lasers;
    Vector3 laserPos;
    Animator anim;
    private float laserYOffset;

    private void Awake()
    {
        laserYOffset = -3f;
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        lasers = Camera.main.GetComponent<SpawnLasers>();
        StartCoroutine(BlinkAfter(2.15f));
        StartCoroutine(DestroyAfter(3f));
    }

    // Update is called once per frame
    void Update()
    {
        
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
