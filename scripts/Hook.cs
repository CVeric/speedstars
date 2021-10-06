using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{


    [SerializeField] float hookSpeed = 50.0f;

    Grapple grapple;
    Rigidbody rigid;
    LineRenderer lineRenderer;

    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        Vector3[] positions = (new Vector3[] { transform.position, grapple.transform.position });
        lineRenderer.SetPositions(positions);
    }
    public void initialize(Grapple grapple, Transform shootTransform)
    {
        transform.forward = shootTransform.forward;
        this.grapple = grapple;
        rigid = GetComponent<Rigidbody>();
        lineRenderer = GetComponent<LineRenderer>();
        rigid.AddForce(transform.forward * hookSpeed, ForceMode.Impulse);
    }

    public void OnTriggerEnter(Collider other)
    {
        if ((LayerMask.GetMask("Grapple") & 1 << other.gameObject.layer) > 0)
        {
            rigid.useGravity = false;
            rigid.isKinematic = true;

            grapple.StartPull();
        }
    }
}
