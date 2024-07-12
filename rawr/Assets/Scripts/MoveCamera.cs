using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float rotSpeed;
    private Transform planet;
    [SerializeField] private bool isZoomed;

    public Vector3 planetCentre;
    public float radius;

    public float zoomScale;
    public float zoomRate;
    

    // Start is called before the first frame update
    void Start()
    {
        planet = GameObject.FindWithTag("Ground").transform;
        planetCentre = planet.position;
    }

    // Update is called once per frame
    void Update()
    {

        Rotate();
        float verInput = Input.GetAxis("Vertical");

        if (verInput > 0)
        {
            ZoomCameraIn();
        }

        if (verInput < 0)
        {
            ZoomCameraOut();
        }
    }

    void ZoomCameraIn()
    {
        zoomScale += zoomRate * Time.deltaTime;
        if (zoomScale > 1) zoomScale = 1;
        
        ApplyZoom();
    }

    void ZoomCameraOut()
    {
        zoomScale -= zoomRate * Time.deltaTime;
        if (zoomScale < 0) zoomScale = 0;
        
        ApplyZoom();
    }

    void ApplyZoom()
    {
        transform.position = Vector3.Lerp(planetCentre, planetCentre + (transform.up * radius), zoomScale) + Vector3.back * 10;
        gameObject.GetComponent<Camera>().orthographicSize = Mathf.Lerp(25f, 10f, zoomScale);
    }

    void Rotate()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        transform.RotateAround(planet.position, Vector3.back,horizontalInput * rotSpeed * Time.deltaTime );
    }
}
