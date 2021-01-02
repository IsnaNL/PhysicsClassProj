using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

 public class Shooter : MonoBehaviour
{

    public GameObject Projectile;
    public bool isRigidBody;
    public TextMeshProUGUI angletext;
    public TextMeshProUGUI forceText;
    public Slider ForceSlider;
    public Slider HeightSlider;
    // private Rigidbody projRb;
    public Transform ShootPos;
    private Vector3 resultantforce;
    private float force;
    private Vector3 mousePos;
    private Vector3 worldPos;
    // private Vector3 relativePos;
    //private float angle;
    //   private bool gameStart;

    // public Slider forceSlider;
    // public Slider heightSlider;
    private void Start()
    {
        //projRb = Projectile.GetComponent<Rigidbody>();
    }
    private KeyCode Shoot = KeyCode.Mouse0;
    private void Update()
    {

        transform.position = new Vector3(0, HeightSlider.value, 0);

        force = ForceSlider.value;

        mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        if (worldPos.x >= 0)
        {

            var relativePos = worldPos - ShootPos.localPosition;
            var rotation = Quaternion.LookRotation(relativePos);
            ShootPos.localRotation = Quaternion.Euler(rotation.eulerAngles);

        }
        else
        {
            worldPos.x = 0;
        }



       // Debug.Log(ShootPos.localRotation.eulerAngles);
        angletext.text =  ( " Angle :"+ ShootPos.rotation.eulerAngles.x);
        forceText.text = (" force :" + force);
        if (Input.GetKeyDown(Shoot))
        {
            var Proj = Instantiate(Projectile, ShootPos.position, transform.localRotation);
            Rigidbody rb = Proj.GetComponent<Rigidbody>();
            if (isRigidBody)
            {
               
                //rb.useGravity = true;

                rb.AddForce(ShootPos.forward * force, ForceMode.Impulse);
            }
            else
            {
                NonRBshot(Proj.GetComponent<Projectile>(),rb);
               // rb.useGravity = false;
            }
         
        }
      
        
    }
    void  NonRBshot(Projectile proj, Rigidbody rb)
    {
        if (!isRigidBody)
        {
            proj.isNonRbForce = true;
            proj.force = force;
            proj.dir = ShootPos.transform.forward;
            proj.rb = rb;
            //proj.groundLayer = 10;
        }
    }
    private void FixedUpdate()
    {

    }
}
       
    
   

