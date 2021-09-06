using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 public class CameraFollow : MonoBehaviour
 {
    public Transform player;
    [SerializeField] private Vector3 offset = new Vector3(0.0f, 0.0f, -10.0f);
 
     void LateUpdate ()
     {
         if (player != null)
             transform.position = player.position + offset;
     }
 }
