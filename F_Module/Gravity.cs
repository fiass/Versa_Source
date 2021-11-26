using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Versa.F_Module
{
    class Gravity
    {
        internal static void Zero()
        {
            Physics.gravity = new Vector3(0, 0, 0);
        }
        internal static void Standard()
        {
            Physics.gravity = new Vector3(0, -9.81f, 0);
        }
        internal static void Moon()
        {
            Physics.gravity = new Vector3(0, -1.63f, 0);
        }
    }
}
