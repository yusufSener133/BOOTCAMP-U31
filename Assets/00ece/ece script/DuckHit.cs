using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckHit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f; // Z eksenini s�f�rla (2D oyun oldu�u i�in)


            Ray2D ray = new Ray2D(mousePosition, Vector2.zero);

            // Raycast ile t�klama noktas�ndaki objeyi alg�la
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            // Alg�lanan obje varsa
            if (hit.collider.gameObject.CompareTag("ordek"))
            {
                Debug.Log("T�klanan obje: " + hit.collider.gameObject.name);
            }
        }
    }




    public Animator OrdekAnim;

    public void OynatVurulmaAnimasyonu()
    {
        OrdekAnim.SetTrigger("Hasar");
    }
}