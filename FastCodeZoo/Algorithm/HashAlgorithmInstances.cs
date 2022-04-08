using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace FastCodeZoo.Algorithm
{
    internal static class HashAlgorithmInstances<THashAlgorithm> where THashAlgorithm : HashAlgorithm
    {
        /// <summary>
        /// 线程静态变量。
        /// 即：这个变量在每个线程中都是唯一的。
        /// 再结合泛型类实现：该变量在不同泛型或不同的线程下的值都是不一样的。
        /// 这样做的目的是为了避开多线程问题。
        /// 关于垃圾回收：当 .NET 线程被释放时，程序中的所有线程静态变量都会被回收，GC 回收时同时将释放资源，所以不必担心释放问题，GC 会帮助我们的。
        /// 这里描述的 .NET 线程释放不是指 .NET 线程回收至线程池。很多时候 .NET 的线程在程序关闭之前都不会真正释放，而是在线程池中继续驻留。
        /// 线程唯一真的能避免多线程问题吗？答：多个线程所用存储空间都不一样，那么脏值就不可能存在，如果这都能出现多线程问题，那GG。
        /// </summary>h
        [ThreadStatic] static THashAlgorithm instance;

        public static THashAlgorithm Instance
        {
            get { return instance != null ? instance : Create(); }
        }

        // public static THashAlgorithm Instance =>
        //     instance ?? Create(); // C# 语法糖，低版本可以改为 { get { return instance != null ? instance : Create(); } }

        /// <summary>
        /// 寻找 THashAlgorithm 类型下的 Create 静态方法，并执行它。
        /// 如果没找到，则执行 Activator.CreateInstance 调用构造方法创建实例。
        /// 如果 Activator.CreateInstance 方法执行失败，它会抛出异常。
        /// </summary>
        [MethodImpl(MethodImplOptions.NoInlining)]
        static THashAlgorithm Create()
        {
            MethodInfo createMethod = typeof(THashAlgorithm).GetMethod(
                nameof(HashAlgorithm.Create), // 这段代码同 "Create"，低版本 C# 可以替换掉
                BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly,
                Type.DefaultBinder,
                Type.EmptyTypes,
                null);

            if (createMethod != null)
            {
                instance = (THashAlgorithm)createMethod.Invoke(null, new object[] { });
            }
            else
            {
                instance = Activator.CreateInstance<THashAlgorithm>();
            }

            return instance;
        }
    }
}