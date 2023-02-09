using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbBehaviour : MonoBehaviour
{
    public bool levelOn = false;
    public Material idleMaterial, onMaterial;
    public Color idle = new Color(255, 100, 190);
    public Color on = new Color(255, 0, 0);
    public Light orbLight;
    public RoomManager roomManager;
    void Start(){
        levelOn = false;
        roomManager = GetComponentInParent<RoomManager>();
        orbLight = gameObject.GetComponentInChildren<Light>();
        orbLight.color = idle;
    }

    void Update(){
        if(!roomManager.levelClear && levelOn){
            orbLight.color = on;
            orbLight.GetComponent<MeshRenderer>().material = onMaterial;
        }else{
            orbLight.color = idle;
            orbLight.GetComponent<MeshRenderer>().material = idleMaterial;
        }
    }

    void OnCollisionEnter(Collision col){
        if(col.collider.tag == "Player"){
            if(!levelOn){
                levelOn = true;
                orbLight.color = on;
                roomManager.StartLevel();
            }else{
                if(roomManager.levelClear){
                    roomManager.GenerateNavMesh();
                    Destroy(transform.parent.gameObject);
                    //Destroy(gameObject);
                }
            }
        }
    }


}
