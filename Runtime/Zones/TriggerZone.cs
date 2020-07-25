using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PowerTools
{
    [AddComponentMenu("Zones/TriggerZone")]
    [RequireComponent(typeof(BoxCollider2D))]
    public class TriggerZone : MonoBehaviour
    {
        [Header("Player Enter")]
        public bool ActionOnEnter;
        public UnityEvent enterEvent;

        [Header("Player Enter")]
        public bool ActionOnStay;
        public UnityEvent stayEvent;

        [Header("Player Exit")]
        public bool ActionOnExit;
        public UnityEvent exitEvent;

        // Invoke custom event if player enters the Collider
        public void OnTriggerEnter2D(Collider2D coll)
        {
            if (ActionOnEnter)
            {
                if (enterEvent != null)
                {
                    enterEvent.Invoke();
                }
            }
            else
            {
                return;
            }
        }

        // Invoke custom event if player stays in the Collider
        public void OnTriggerStay2D(Collider2D collision)
        {
            if (ActionOnStay)
            {
                if (stayEvent != null)
                {
                    stayEvent.Invoke();
                }
            }
            else
            {
                return;
            }
        }

        // Invoke custom event if player exits the Collider
        public void OnTriggerExit2D(Collider2D coll)
        {
            if (ActionOnExit)
            {
                if (exitEvent != null)
                {
                    exitEvent.Invoke();
                }
            }
            else
            {
                return;
            }
        }

        // Draw red rectangle around boxcollider
        private void OnDrawGizmos()
        {
            BoxCollider2D collider = GetComponent<BoxCollider2D>();
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position, collider.bounds.size);
        }
    }
}
