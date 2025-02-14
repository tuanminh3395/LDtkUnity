﻿using UnityEngine;

namespace LDtkUnity
{
    public static class LDtkInjectionErrorContext
    {
        public static Object Context;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        public static void Dispose()
        {
            Context = null;
        }

        public static void SetLogErrorContext(Object obj)
        {
            Context = obj;
        }
    }
}