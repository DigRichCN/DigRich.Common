using System;
using System.Collections.Generic;
using System.Text;

namespace DigRich.Common {
    public partial class Response<T> {
        public int Code { get; set; }

        public string Message { get; set; }

        public T Data { get; set; }

        public Response() {
            Code = 0;
            Message = "操作成功OK";
        }
        public Response(int code, string message) {
            Code = code;
            Message = message;
        }
        public Response(T data) {
            Code = 0;
            Message = "操作成功OK";
            Data = data;
        }
        public void SetMessage(int code, string message) {
            Message = message;
            Code = code;
        }
        /// <summary>
        /// 设置响应状态为成功
        /// </summary>
        /// <param name="message"></param>
        public void SetSuccess(string message = "成功") {
            SetMessage(0, message);
        }
        /// <summary>
        /// 设置响应状态为失败
        /// </summary>
        /// <param name="message"></param>
        public void SetFailed(string message = "失败") {
            SetMessage(999, message);
        }

        /// <summary>
        /// 设置响应状态为体验版(返回失败结果)
        /// </summary>
        /// <param name="message"></param>
        public void SetIsTrial(string message = "体验版,功能已被关闭") {
            SetMessage(999, message);
        }

        /// <summary>
        /// 设置响应状态为错误
        /// </summary>
        /// <param name="message"></param>
        public void SetError(string message = "错误") {
            SetMessage(500, message);
        }

        /// <summary>
        /// 设置响应状态为未知资源
        /// </summary>
        /// <param name="message"></param>
        public void SetNotFound(string message = "未知资源") {
            SetMessage(404, message);
        }

        /// <summary>
        /// 设置响应状态为无权限
        /// </summary>
        /// <param name="message"></param>
        public void SetNoPermission(string message = "无权限") {
            SetMessage(401, message);
        }
        /// <summary>
        /// 设置响应数据
        /// </summary>
        /// <param name="data"></param>
        public void SetData(T data) {
            Data = data;
        }
        public bool IsSuccess { get { return this.Code == 0; } }
    }
}
