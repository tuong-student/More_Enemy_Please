using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using System.Threading;
using UnityEngine;

namespace NOOD{
    public static class NoodyCustomCode
    {
        public static Thread newThread;

        #region Look, mouse and Vector zone
        public static Vector3 ScreenPointToWorldPoint(Vector2 screenPoint){
            Camera cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            return cam.ScreenToWorldPoint(screenPoint);
        }

        public static Vector3 MouseToWorldPoint(){
            Camera cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            Vector2 mousePos = Input.mousePosition;
            return cam.ScreenToWorldPoint(mousePos);
        }

        public static Vector2 WorldPointToScreenPoint(Vector3 worldPoint){
            Camera cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            return cam.WorldToScreenPoint(worldPoint);
        }

        public static void LookToMouse2D(Transform objectTransform){
            Vector3 mousePosition = MouseToWorldPoint();
            LookToPoint2D(objectTransform, mousePosition);
        }

        public static void LookToPoint2D(Transform objectTransform, Vector3 targetPosition){
            Vector3 lookDirection = LookDirection(objectTransform.position, targetPosition);
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            objectTransform.localEulerAngles = new Vector3(0f, 0f, angle);
        }

        public static Vector3 LookDirection(Vector3 FromPosition, Vector3 targetPosition){
            return (targetPosition - FromPosition).normalized;
        }

        public static Vector3 GetPointAroundAPosition2D(Vector3 centerPosition, float degrees, float radius){
            var radians = degrees * Mathf.Deg2Rad;
            var x = Mathf.Cos(radians);
            var y = Mathf.Sin(radians);
            Vector3 pos = new Vector3(x, y, centerPosition.z);
            return pos += centerPosition;
        }

        public static Vector3 GetPointAroundAPosition2D(Vector3 centerPosition, float radius){
            var degrees = UnityEngine.Random.Range(0, 360);
            var radians = degrees * Mathf.Deg2Rad;
            var x = Mathf.Cos(radians);
            var y = Mathf.Sin(radians);
            Vector3 pos = new Vector3(x, y, centerPosition.z);
            pos *= radius;
            return pos += centerPosition;
        }

        public static Vector3 GetPointAroundAPosition3D(Vector3 centerPosition, float degrees, float radius){
            var radians = degrees * Mathf.Deg2Rad;
            var x = Mathf.Cos(radians);
            var z = Mathf.Sin(radians);
            Vector3 pos = new Vector3(x, centerPosition.y, z);
            return pos += centerPosition;
        }

        public static Vector3 GetPointAroundAPosition3D(Vector3 centerPosition, float radius){
            var degrees = UnityEngine.Random.Range(0, 360);
            var radians = degrees * Mathf.Deg2Rad;
            var x = Mathf.Cos(radians);
            var z = Mathf.Sin(radians);
            Vector3 pos = new Vector3(x, centerPosition.y, z);
            pos *= radius;
            return pos += centerPosition;
        }
        #endregion

        #region Background Function
        public static void RunInBackground(Action function, Queue<Action> mainThreadActions = null){
            //! WebGL doesn't do multithreading

            /* Create a mainThreadQueue in main script to hold the Action and run the action in Update like below
                 if your Action do something to Unity object like set transform, set physic or contain Unity Time class 
                !Ex for mainThreadQueue:
                    Queue<Action> mainThreadQueue = new Queue<Action>()
                    
                    void Update()
                    {
                        if(mainThreadQueue.Count > 0)
                        {
                            Action action = mainThreadQueue.Dequeue();
                            action();
                        }
                    }
            */

            //! if your function has parameters, use param like this
            //! NoodyCustomCode.RunInBackGround(() => yourFunction(parameters)); 

            Thread t = new Thread(() => {
                if(mainThreadActions != null)
                    NoodyCustomCode.AddToMainThread(function, mainThreadActions);
                else
                    function();
            });
            t.Start();
        }

        static void AddToMainThread(Action function, Queue<Action> mainThreadActions){
            mainThreadActions.Enqueue(function);
        }

        //TODO: learn Unity.Jobs and create a Function to run many complex job in multithread

        #endregion
   
        #region Camera
        public static void SmoothCameraFollow(GameObject camera, float smoothTime, Transform targetTransform, Vector3 offset, 
        float maxX, float maxY, float minX, float minY){

            Vector3 temp = camera.transform.position;
            Vector3 targetPosition = targetTransform.position + offset;
            Vector3 currentSpeed = Vector3.zero;
            Vector3 smoothPosition = Vector3.SmoothDamp(camera.transform.position, targetPosition, ref currentSpeed, smoothTime);
            if(smoothPosition.x < maxX && smoothPosition.x > minX)
                temp.x = smoothPosition.x;
            if(smoothPosition.y < maxY && smoothPosition.y > minY)
                temp.y = smoothPosition.y;
            temp.z = smoothPosition.z;
            camera.transform.position = temp;
        }

        public static void CameraShake(GameObject camera){

        }

        public static IEnumerator CameraShake(GameObject camera, float duration, float magnitude)
        {
            Vector3 OriginalPos = camera.transform.position;
            float elapsed = 0.0f;
            float range = 1f;
            while (elapsed < duration)
            {
                float x, y;
                if((elapsed / duration) * 100 < 80){
                    //Starting shake
                    x = UnityEngine.Random.Range(-range, range) * magnitude;
                    y = UnityEngine.Random.Range(-range, range) * magnitude;
                }
                else{
                    //Ending
                    range -= Time.deltaTime * elapsed;
                    x = UnityEngine.Random.Range(-range, range) * magnitude;
                    y = UnityEngine.Random.Range(-range, range) * magnitude;
                }

                camera.transform.localPosition = new Vector3(x, y, OriginalPos.z);
                    
                elapsed += Time.deltaTime;
                yield return null;
            }
            camera.transform.localPosition = OriginalPos;

        }
        #endregion
    }

}
