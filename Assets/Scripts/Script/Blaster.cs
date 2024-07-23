using System.Collections;
using System.Collections.Generic;
//using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;
using System.Linq;





public class Blaster : MonoBehaviour
{
    [SerializeField] Projectile _projectilePrefab;

    [SerializeField] Transform _muzzle;
    [SerializeField][Range(0f, 5f)] float _coolDownTime = 0.25f;

    [SerializeField]
    private XRNode xRNode = XRNode.RightHand;

    private List<InputDevice> devices = new List<InputDevice>();

    private InputDevice device;
    private bool triggerIsPressed;


    bool CanFire
    {
        get
        {
            _coolDown -= Time.deltaTime;
            return _coolDown <= 0f;
        }
    }

    float _coolDown;
    //Button button = GetComponent<Button>();
    // Update is called once per frame
  

    void GetDevice()
    {
        InputDevices.GetDevicesAtXRNode(xRNode, devices);
        device = devices.FirstOrDefault();
    }
    void OnEnable()
    {
        if (!device.isValid)
        {
            GetDevice();
        }
    }

    void Update()
    {
        if (!device.isValid)
        {
            GetDevice();
        }

        bool triggerButtonValue = false;
        if (device.TryGetFeatureValue(CommonUsages.triggerButton, out triggerButtonValue) && triggerButtonValue && !triggerIsPressed)
        {
            triggerIsPressed = true;
            if (CanFire)
            {
                FireProjectile();
            }
           
        }
        else if (!triggerButtonValue && triggerIsPressed)
        {
            triggerIsPressed = false;
          
        }

        if (CanFire && Input.GetMouseButton(0))
        {
            FireProjectile();

        }

       
    }

    void FireProjectile()
    {
        _coolDown = _coolDownTime;
        Instantiate(_projectilePrefab, _muzzle.position, transform.rotation);
    }
}