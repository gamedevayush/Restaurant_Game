﻿// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.

#if UNITY_5_6_OR_NEWER

using UnityEngine;
using UnityEngine.Video;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory(ActionCategory.Video)]
    [Tooltip("Get The clock that the player follows to derive its current time")]
    public class VideoPlayerGetTimeSource : FsmStateAction
    {
        [RequiredField]
        [CheckForComponent(typeof(VideoPlayer))]
        [Tooltip("The GameObject with as VideoPlayer component.")]
        public FsmOwnerDefault gameObject;

        [RequiredField]
        [UIHint(UIHint.Variable)]
        [Tooltip("The time source type")]
       // [ObjectType(typeof(VideoTimeUpdateMode))]
        public FsmEnum timeSource;

        [Tooltip("Repeat every frame.")]
        public bool everyFrame;

        GameObject go;

        VideoPlayer _vp;

        public override void Reset()
        {
            gameObject = null;
            timeSource = null;
            everyFrame = false;
        }

        public override void OnEnter()
        {
            GetVideoPlayer();

            ExecuteAction();

            if (!everyFrame)
            {
                Finish();
            }
        }

        public override void OnUpdate()
        {
            ExecuteAction();
        }


        void ExecuteAction()
        {
            if (_vp != null)
            {
              //  timeSource.Value = _vp.timeUpdateMode;
            }
        }

        void GetVideoPlayer()
        {
            go = Fsm.GetOwnerDefaultTarget(gameObject);
            if (go != null)
            {
                _vp = go.GetComponent<VideoPlayer>();
            }
        }
    }
}

#endif