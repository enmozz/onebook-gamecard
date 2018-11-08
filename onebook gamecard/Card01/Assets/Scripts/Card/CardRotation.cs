using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CardRotation : MonoBehaviour {

    public RectTransform cardFront;
    public RectTransform cardBack;
    public Transform targetFacePoint;
    public Collider col;

    private bool ShowimgBack = false;

    public void Update()
    {
        RaycastHit[] hits;
        hits = Physics.RaycastAll(origin: Camera.main.transform.position + targetFacePoint.position,
            direction: (-Camera.main.transform.position + targetFacePoint.position).normalized,
            maxDistance: (-Camera.main.transform.position + targetFacePoint.position).magnitude);

        bool passdThroughTargetcollider = false;

        foreach (RaycastHit h in hits)
        {
            if (h.collider == col)
            {
                passdThroughTargetcollider = true;
            }
        }

        if (passdThroughTargetcollider != ShowimgBack)
        {
            ShowimgBack = passdThroughTargetcollider;
            if (ShowimgBack)
            {
                cardFront.gameObject.SetActive(false);
                cardBack.gameObject.SetActive(true);
            }
            else
            {
                cardFront.gameObject.SetActive(true);
                cardBack.gameObject.SetActive(false);
            }
        }
    }


}
