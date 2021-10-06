using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    [SerializeField] float pullSpeed = 0.5f;
    [SerializeField] float stopDistance = 4.0f;
    [SerializeField] GameObject HookPrefab;
    [SerializeField] Transform shootTransform;
    [SerializeField] KeyCode fireKey;


    Hook hook;
    bool pulling;
    Rigidbody rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        pulling = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hook == null && Input.GetKeyDown(fireKey))
        {
            StopAllCoroutines();
            pulling = false;
            hook = Instantiate(HookPrefab, shootTransform.position, Quaternion.identity).GetComponent<Hook>();
            hook.initialize(this, shootTransform);
            StartCoroutine(DestroyHookAfterLifetime());
        } else if(hook != null && Input.GetMouseButtonDown(0))
        {
            DestroyHook();
        }

        if (!pulling || hook == null) return;

        if (Vector3.Distance(transform.position, hook.transform.position) <= stopDistance)
        {
            DestroyHook();
        }
        else
        {
            rigid.AddForce((hook.transform.position - transform.position).normalized * pullSpeed, ForceMode.VelocityChange);
        }
    }

    public void StartPull() { pulling = true; }

    public void DestroyHook()
    {
        if (hook == null) return;
        pulling = false;
        Destroy(hook.gameObject);
        hook = null;
    }

    private IEnumerator DestroyHookAfterLifetime()
    {
        yield return new WaitForSeconds(8f);
        DestroyHook();
    }
}
