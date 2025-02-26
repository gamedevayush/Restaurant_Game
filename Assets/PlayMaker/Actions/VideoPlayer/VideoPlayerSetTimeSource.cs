﻿// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.

#if UNITY_5_6_OR_NEWER

using UnityEngine;
using UnityEngine.Video;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory(ActionCategory.Video)]
    [Tooltip("Sets Time source followed by the VideoPlayer when reading content.")]
    public class VideoPlayerSetTimeSource : FsmStateAction
    {
        [RequiredField]
        [CheckForComponent(typeof(VideoPlayer))]
        [Tooltip("The GameObject with a VideoPlayer component.")]
        public FsmOwnerDefault gameObject;

        [RequiredField]
        [Tooltip("The timeSource Value")]
       // [ObjectType(typeof(VideoTimeUpdateMode))]
        public FsmEnum timeSource;

        [Tooltip("Event sent if time can not be set")]
        public FsmEvent canNotSetTime;


        GameObject go;

        VideoPlayer _vp;


        public override void Reset()
        {
            gameObject = null;
           // timeSource = VideoTimeUpdateMode.DSPTime;
            canNotSetTime = null;
        }

        public override void OnEnter()
        {
            GetVideoPlayer();

            if (_vp != null && !_vp.canSetTime)
            {
                Fsm.Event(canNotSetTime);
            }
            else
            {
                ExecuteAction();
            }

            Finish();

        }

        void ExecuteAction()
        {
            if (_vp != null && _vp.canSetTime)
            {
                //_vp.timeUpdateMode = (VideoTimeUpdateMode)timeSource.Value;
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