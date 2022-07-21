using System.Collections.Generic;
using System;
using System.Threading;
using UnityEngine;

namespace NOOD{
    public static class FunctionDelay
    {

        public static void StartThreadDelayFunction(Action function, float timer, Queue<Action> mainThreadActions = null){
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

                //Pause this thread for timer seconds
                for(int i = 0; i < timer*100; i++){
                    Thread.Sleep(10);
                }
                if(mainThreadActions != null)
                    FunctionDelay.AddToMainThread(function, mainThreadActions);
                else
                    function();
            });
            t.Start();
        }

        static void AddToMainThread(Action function, Queue<Action> mainThreadActions){
            mainThreadActions.Enqueue(function);
        }
   }
}
