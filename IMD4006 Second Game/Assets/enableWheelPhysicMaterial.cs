using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class enableWheelPhysicMaterial : MonoBehaviour
{
    private WheelCollider wheel;
 
 
    private float originalSidewaysStiffness;
    private float originalForwardStiffness;
 
   [Header("Tires")]
    public bool race;
    public bool allTerrain;
    public bool dirtnsnow;
    public bool wet;
    public bool studded;
 
 
    void Start()
    {
        wheel = GetComponent<WheelCollider>();
 
        originalSidewaysStiffness = wheel.sidewaysFriction.stiffness;
        originalForwardStiffness = wheel.forwardFriction.stiffness;
    }
    // static friction of the ground material.
    void FixedUpdate()
    {
        WheelHit hit;
        if (wheel.GetGroundHit(out hit))
        {
            WheelFrictionCurve fFriction = wheel.forwardFriction;
            fFriction.stiffness = hit.collider.material.staticFriction * originalForwardStiffness;
            wheel.forwardFriction = fFriction;
 
 
            WheelFrictionCurve sFriction = wheel.sidewaysFriction;
            sFriction.stiffness = hit.collider.material.staticFriction * originalSidewaysStiffness;
            wheel.sidewaysFriction = sFriction;
            
            if (race){
                wheel.mass=20;
                
                if(hit.collider.gameObject.tag=="asphault"){
                    originalForwardStiffness=1.4f;
                    originalSidewaysStiffness=2f;
                } else if(hit.collider.gameObject.tag=="dirt"){
                    originalForwardStiffness=0.9f;
                    originalSidewaysStiffness=0.7f;
                } else if(hit.collider.gameObject.tag=="ice"){
                    originalForwardStiffness=0.9f;
                    originalSidewaysStiffness=0.7f;
                } else if(hit.collider.gameObject.tag=="wet"){
                    originalForwardStiffness=0.5f;
                    originalSidewaysStiffness=0.6f;
                }
            } else if (allTerrain){
                wheel.mass=25;

                if(hit.collider.gameObject.tag=="asphault"){
                    originalForwardStiffness=0.9f;
                    originalSidewaysStiffness=0.9f;
                } else if(hit.collider.gameObject.tag=="dirt"){
                    originalForwardStiffness=1.6f;
                    originalSidewaysStiffness=1f;
                } else if(hit.collider.gameObject.tag=="ice"){
                    originalForwardStiffness=1.2f;
                    originalSidewaysStiffness=0.7f;
                } else if(hit.collider.gameObject.tag=="wet"){
                    originalForwardStiffness=1f;
                    originalSidewaysStiffness=1f;
                }
                
            }  else if (dirtnsnow){
                wheel.mass=30;

                if(hit.collider.gameObject.tag=="asphault"){
                    originalForwardStiffness=1.3f;
                    originalSidewaysStiffness=1f;
                } else if(hit.collider.gameObject.tag=="dirt"){
                    originalForwardStiffness=2.5f;
                    originalSidewaysStiffness=1.8f;
                } else if(hit.collider.gameObject.tag=="ice"){
                    originalForwardStiffness=0.8f;
                    originalSidewaysStiffness=0.8f;
                } else if(hit.collider.gameObject.tag=="wet"){
                    originalForwardStiffness=1f;
                    originalSidewaysStiffness=1f;
                }
            }  else if (wet){
                wheel.mass=25;
                
                if(hit.collider.gameObject.tag=="asphault"){
                    originalForwardStiffness=0.6f;
                    originalSidewaysStiffness=0.5f;
                } else if(hit.collider.gameObject.tag=="dirt"){
                    originalForwardStiffness=1.2f;
                    originalSidewaysStiffness=0.7f;
                } else if(hit.collider.gameObject.tag=="ice"){
                    originalForwardStiffness=1f;
                    originalSidewaysStiffness=0.8f;
                } else if(hit.collider.gameObject.tag=="wet"){
                    originalForwardStiffness=1.9f;
                    originalSidewaysStiffness=1.9f;
                }
            }  else if (studded){
                wheel.mass=33;
                
                if(hit.collider.gameObject.tag=="asphault"){
                    originalForwardStiffness=0.7f;
                    originalSidewaysStiffness=0.7f;
                } else if(hit.collider.gameObject.tag=="dirt"){
                    originalForwardStiffness=1.3f;
                    originalSidewaysStiffness=1f;
                } else if(hit.collider.gameObject.tag=="ice"){
                    originalForwardStiffness=2.5f;
                    originalSidewaysStiffness=2.5f;
                } else if(hit.collider.gameObject.tag=="wet"){
                    originalForwardStiffness=0.5f;
                    originalSidewaysStiffness=0.6f;
                }
            }
        }
    }
}
 