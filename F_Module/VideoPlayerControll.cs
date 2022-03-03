using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VRCSDK2;

namespace Versa.F_Module
{
    internal class VideoPlayerControll
    {
        internal static void Play()
        {
            foreach (VRC_SyncVideoPlayer pl in GameObject.FindObjectsOfType<VRC_SyncVideoPlayer>())
            {
                pl.Play();
            }
        }
        internal static void Pause()
        {
            foreach (VRC_SyncVideoPlayer pl in GameObject.FindObjectsOfType<VRC_SyncVideoPlayer>())
            {
                pl.Pause();
            }
        }
        internal static void Restart()
        {
            foreach (VRC_SyncVideoPlayer pl in GameObject.FindObjectsOfType<VRC_SyncVideoPlayer>())
            {
                pl.Stop();
                pl.Play();
            }
        }
    }
}
