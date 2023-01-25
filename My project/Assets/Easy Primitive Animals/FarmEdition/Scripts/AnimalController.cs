using System.Collections;
using UnityEngine;

namespace EasyPrimitiveAnimals
{
    public class AnimalController : MonoBehaviour
    {
        // Leg and body object variables
        public GameObject FrontLegL;
        public GameObject FrontLegR;
        public GameObject RearLegL;
        public GameObject RearLegR;

        // Leg and body rotation variables
        private Vector3 legStartPosA = new Vector3(10.0f, 0f, 0f);
        private Vector3 legEndPosA = new Vector3(-10.0f, 0f, 0f);

        private Vector3 legStartPosB = new Vector3(-10.0f, 0f, 0f);
        private Vector3 legEndPosB = new Vector3(10.0f, 0f, 0f);

        private float rotSpeed;

        // Wander variables.
        public float moveAngle = 90f; // Define angle the animal turns after a collision.
        public float movSpeed = 1f; // Define speed that animal moves. This is also used to calculate leg movement speed.

        private bool canRotate = true;
        private bool canPeck = true;

        private void Start()
        {
        }

        private void Update()
        {

        }

        private void OnCollisionEnter(Collision collision)
        {

        }

        private IEnumerator SpinMeRound()
        {
            // Disable option to rotate.
            canRotate = false;

            // Rotate animal.
            this.transform.rotation *= Quaternion.Euler(0, moveAngle, 0);

            // Wait...
            yield return new WaitForSeconds(1f);

            // Enable option to rotate.
            canRotate = true;
        }

        private IEnumerator TimeToPeck()
        {
            // Disable option to peck.
            canPeck = false;

            // Change X rotation to 45 degrees
            this.transform.eulerAngles = new Vector3(45f, transform.eulerAngles.y, transform.eulerAngles.z);

            // Wait...
            yield return new WaitForSeconds(0.2f);

            // Change X rotation to 0 degrees
            this.transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, transform.eulerAngles.z);

            yield return new WaitForSeconds(Random.Range(3f, 7f));

            // Enable option to peck.
            canPeck = true;
        }
    }
}
