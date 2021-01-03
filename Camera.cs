using System.Threading;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

public class Camera : MonoBehaviour
{

  public GameObject graph;
  public float speed = 5.0f;
  
    void Start(){}

    void Update()
    {
      // find centre of the graph
      float _count_elements_ = 0.0f;
      double radius = 0.0d;
      float xmean = 0.0f;
      float ymean = 0.0f;
      float zmean = 0.0f;
      double deltax = 0.0d;
      double deltay = 0.0d;
      double deltaz = 0.0d;
      double theta = 0.0d;

      foreach (Transform child in graph.transform){
      xmean += child.position.x;
      ymean += child.position.y;
      zmean += child.position.z;
      _count_elements_ += 1;
      }
      
      xmean /= _count_elements_;
      ymean /= _count_elements_;
      zmean /= _count_elements_;
      
      deltax = transform.position.x  - xmean;
      deltay = transform.position.y  - ymean;
      deltaz = transform.position.z  - zmean;
      radius = Sqrt(Pow(deltax,2f) + Pow(deltaz,2f)); /* note that radius here does NOT include vertical, only flat in the plane */
      theta = Atan2(deltaz , deltax);  

      UnityEngine.Debug.Log("camera delta [x, y, z] = [" + deltax + ", " + deltay + ", " + deltaz + "], radius =" + radius + ", theta = " + theta); 
      
      transform.LookAt(new Vector3(xmean, ymean, zmean));
      
      if (Input.GetKey("up")){
	transform.position += new Vector3(0,0,Time.deltaTime*speed);
      }

      if (Input.GetKey("down")){
	transform.position -= new Vector3(0,0,Time.deltaTime*speed);
      }
      if (Input.GetKey("a")){
	transform.position += new Vector3((float)(-radius * Cos(theta) + radius * Cos (theta + PI /180)), 0 , (float)(-radius * Sin(theta) + radius * Sin (theta + PI /180) ));
      }
      if (Input.GetKey("d")){
	transform.position += new Vector3((float)(-radius * Cos(theta) + radius * Cos (theta - PI /180)), 0 , (float)(-radius * Sin(theta) + radius * Sin (theta - PI /180) ));
      }
            if (Input.GetKey("w")){
	transform.position += new Vector3(0,Time.deltaTime*speed,0);
      }

      if (Input.GetKey("s")){
	transform.position -= new Vector3(0,Time.deltaTime*speed,0);
      }
    }
    
} 
