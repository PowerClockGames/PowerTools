using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;
using UnityEngine.Events;

namespace PowerTools
{
    [AddComponentMenu("Zones/CutsceneZone")]
    [RequireComponent(typeof(BoxCollider2D))]
    public class CutsceneZone : MonoBehaviour
    {
        [Header("Settings")]
        public PlayableDirector director;
        public bool playerCanMove;
        public bool hideControls;

        [Space(10)]
        public bool actionOnCutsceneEnd;
        public UnityEvent actionAfterCutscene;

        public void OnTriggerEnter2D(Collider2D coll)
        {
            Character character = coll.GetComponent<Character>();
            // Hide player controls
            if(hideControls)
            {
                //TODO hide controls
            }

            StartCoroutine(playCutscene(character));
        }

        public void OnTriggerExit2D(Collider2D coll)
        {
            return;
        }

        // Play Cutscene from Timeline and invoke methods
        private IEnumerator playCutscene(Character character)
        {
            // Freeze Player if toggled
            if (!playerCanMove)
            {
                if(character != null)
                {
                    character.Freeze();
                }
            }
            director.Play();

            //Stop Cutscene after it ended
            yield return new WaitForSeconds((float)director.playableAsset.duration);
            director.Stop();

            if (character != null)
            {
                character.UnFreeze();
            }

            // Reenable mobile controls
            if (hideControls)
            {
                //TODO hide controls
            }

            // Invoke custom event
            if (actionOnCutsceneEnd)
            {
                if(actionAfterCutscene != null)
                {
                    actionAfterCutscene.Invoke();
                }
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
