using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
   [SerializeField]
   private Transform pointPrefab;

   [SerializeField, Range(10, 100)]
   private int resolution = 10;

   //Animating the Graph
   private Transform[] points;
   
   private void Awake()
   {
      //adjust the scale and positions of the cubes to keep them inside the −1–1 domain
      float step = 2f / resolution;
      
      var position = Vector3.zero;
      
      var scale = Vector3.one * step/**/;
      
      //Animating the Graph
      points = new Transform[resolution];
      
      //Instantiate More Points Up to Resolution Size Which Sets on Inspector Panel
      for (int i = 0; i < points.Length; i++)
      {
         Transform point = points[i] = Instantiate(pointPrefab);
         
         position.x = (i + 0.5f) * step/**/ - 1f;
         
         point.localPosition = position;
         point.localScale = scale;

         //Setting Parent
         point.SetParent(transform, false);
      }
   }

   private void Update()
   {
      for (int i = 0; i < points.Length; i++)
      {
         Transform point = points[i];
         Vector3 position = point.localPosition;
         position.y = Mathf.Sin(Mathf.PI * (position.x + Time.time));
         point.localPosition = position;
      }
   }
}
