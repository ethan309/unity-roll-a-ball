using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Valve.VR.InteractionSystem.Sample
{
    public class SnapToPoint : MonoBehaviour, Resetable
    {
        private bool shouldReset;
        private Vector3 snapTo;
        private Quaternion snapAngle;
        private Rigidbody body;
        public float snapTime = 2;

        private float dropTimer;
        private Interactable interactable;

        public void ToggleReset(bool status)
        {
            print(status);
            shouldReset = status;
        }

        private void Start()
        {
            snapTo = transform.TransformDirection(transform.position);
            snapAngle = transform.rotation;
            shouldReset = false;
            interactable = GetComponent<Interactable>();
            body = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            bool used = false;
            if (interactable != null)
                used = interactable.attachedToHand;

            if (used)
            {
                print('1');
                body.isKinematic = false;
                dropTimer = -1;
            }
            else if (shouldReset)
            {
                print('2');
                dropTimer += Time.deltaTime / (snapTime / 2);

                body.isKinematic = dropTimer > 1;

                // Already back in target position
                if (dropTimer > 1)
                {
                    //transform.parent = snapTo;
                    transform.position = snapTo;
                    transform.rotation = snapAngle;
                    shouldReset = false;
                }
                // Still returning to target position
                else
                {
                    float t = Mathf.Pow(35, dropTimer);

                    body.velocity = Vector3.Lerp(body.velocity, Vector3.zero, Time.fixedDeltaTime * 4);
                    if (body.useGravity)
                        body.AddForce(-Physics.gravity);

                    transform.position = Vector3.Lerp(transform.position, snapTo, Time.fixedDeltaTime * t * 3);
                    transform.rotation = Quaternion.Slerp(transform.rotation, snapAngle, Time.fixedDeltaTime * t * 2);
                }
            }
        }
    }
}