using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace _Complete
{
    public class Pickup : MonoBehaviour
    {
        private int coinCount;
        public TextMeshProUGUI coinText;
        public AudioClip coinSound;
        public AudioClip burgerSound;
        public AudioClip drinkSound;
        public AudioClip winSound;
        public AudioClip lvlupSound;
        public AudioClip deadSound;

        private void OnTriggerEnter2D(Collider2D other)
        {
            bool foundCollectable = false;
            bool foundTower = false;
            bool foundBird = false;
            bool foundField = false;
            AudioClip clip = null;
            int collectableValue = 0;

            if (other.CompareTag("coin"))
            {
                clip = coinSound;
                collectableValue = 1;
                foundCollectable = true;
            }
            else if (other.CompareTag("burger"))
            {
                clip = burgerSound;
                collectableValue = 10;
                foundCollectable = true;
            }
            else if (other.CompareTag("drink"))
            {
                clip = drinkSound;
                collectableValue = 15;
                foundCollectable = true;
            }
            else if(other.CompareTag("tower"))
            {
                clip = winSound;
                foundTower = true;
            }
            else if(other.CompareTag("bird"))
            {
                clip = lvlupSound;
                foundBird = true;
            }
            else if(other.CompareTag("field"))
            {
                clip = deadSound;
                foundField = true;
            }

            if (foundCollectable)
            {
               
                AudioSource.PlayClipAtPoint(clip, other.transform.position);
                Destroy(other.gameObject);
                coinCount += collectableValue;
                coinText.text = coinCount.ToString();

            }
            if (foundTower)
            {
                Destroy(gameObject);
                AudioSource.PlayClipAtPoint(clip, other.transform.position);

            }
            if (foundBird)
            {
                Destroy(other.gameObject);
                AudioSource.PlayClipAtPoint(clip, other.transform.position);
            }

            if (foundField)
            {
                Destroy(gameObject);
                AudioSource.PlayClipAtPoint(clip, other.transform.position);
            }



        }

    }
}
