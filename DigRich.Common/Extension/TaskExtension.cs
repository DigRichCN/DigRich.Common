﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DigRich.Common.Extension {
    /// <summary>
    ///   任务等待扩展
    /// </summary>
    public static class TaskExtension {
        /// <summary>
        ///   等待异步执行结果
        /// </summary>
        /// <typeparam name="TRes"></typeparam>
        /// <param name="task"></param>
        /// <returns></returns>
        public static TRes WaitResult<TRes>(this Task<TRes> task) {
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// 等待异步执行结果
        /// </summary>
        /// <typeparam name="TRes"></typeparam>
        /// <param name="task"></param>
        /// <param name="milliseconds">等待任务完成的毫秒数，-1,表示无限期等待</param>
        /// <returns></returns>
        public static TRes WaitResult<TRes>(this Task<TRes> task, int milliseconds) {
            task.Wait(milliseconds);
            return task.Result;
        }


        /// <summary>
        /// 等待异步执行结果
        /// </summary>
        /// <param name="task"></param>
        /// <param name="span">等待时间间隔</param>
        /// <typeparam name="TRes"></typeparam>
        /// <returns></returns>
        public static TRes WaitResult<TRes>(this Task<TRes> task, TimeSpan span) {
            task.Wait(span);
            return task.Result;
        }

        /// <summary>
        /// 等待异步执行结果
        /// </summary>
        /// <param name="task"></param>
        /// <param name="token">等待任务完成期间要观察的取消标记</param>
        /// <typeparam name="TRes"></typeparam>
        /// <returns></returns>
        public static TRes WaitResult<TRes>(this Task<TRes> task, CancellationToken token) {
            task.Wait(token);
            return task.Result;
        }

        /// <summary>
        /// 等待异步执行结果
        /// </summary>
        /// <param name="task"></param>
        /// <param name="milliseconds">等待任务完成的毫秒数，-1,表示无限期等待</param>
        /// <param name="token">等待任务完成期间要观察的取消标记</param>
        /// <typeparam name="TRes"></typeparam>
        /// <returns></returns>
        public static TRes WaitResult<TRes>(this Task<TRes> task, int milliseconds, CancellationToken token) {
            task.Wait(milliseconds, token);
            return task.Result;
        }

    }
}
