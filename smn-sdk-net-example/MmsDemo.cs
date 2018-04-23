using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Smn.Request.Mms;
using Smn.Response.Mms;
using Smn.Util;

namespace Smn.Example
{
    class MmsDemo
    {
        private SmnClient smnClient;

        public MmsDemo(SmnClient smnClient)
        {
            this.smnClient = smnClient;
        }

        /// <summary>
        /// 发送彩信
        /// </summary>
        public void MmsPublish()
        {
            // 生成彩信 图片数据
            MmsFrameMessage image = new MmsFrameMessage
            {
                FileType = MmsFileType.MMS_IAMGE_JPG,
                ContentBase64 = FileToBase64("E:/zhangyx/mms/timg.jpg")
            };

            // 生成彩信 音频数据
            MmsFrameMessage voice = new MmsFrameMessage
            {
                FileType = MmsFileType.MMS_VOICE_MID,
                ContentBase64 = FileToBase64("E:/zhangyx/mms/town.mid")
            };

            // 生成mms frame数据
            MmsFrame mmsFrame = new MmsFrame
            {
                Text = "彩信测试",
                Image = image,
                Voice = voice
            };

            MmsPublishRequest request = new MmsPublishRequest
            {
                Title = "彩信测试1234",
                Endpoints = new List<string>
                {
                  "136*****87", "1772*****31"
                },
                SignId = "3e863eac748b417c98795ec3c7f2887c",
                MmsMessage = new List<MmsFrame>
                {
                    mmsFrame
                }
            };

            try
            {
                // 发送请求并返回响应
                MmsPublishResponse response = smnClient.SendRequest(request);
                if (response.IsSuccess())
                {
                    List<MmsPublishResult> results = response.Result;
                    foreach (MmsPublishResult result in results)
                    {
                        Console.WriteLine("messageId={0}, endpoint={1}, code={2}, message={3}",
                            result.MessageId, result.Endpoint, result.Code, result.Message);
                    }
                }
                else
                {
                    Console.WriteLine("code={0}, message={1}, statusCode={2}",
                        response.ErrCode, response.ErrMessage, response.StatusCode);
                }
                Console.ReadLine();
            }
            catch (Exception e)
            {
                // 处理异常
                Console.WriteLine("{0}", e.Message);
                Console.ReadLine();
            }
        }

        /// <summary>
        /// 将文件base64编码
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>base64 string</returns>
        string FileToBase64(string filePath)
        {
            string base64Str;
            using (FileStream filestream = new FileStream(filePath, FileMode.Open))
            {
                byte[] bt = new byte[filestream.Length];
                //调用read读取方法  
                filestream.Read(bt, 0, bt.Length);
                base64Str = Convert.ToBase64String(bt);
                filestream.Close();
            }
            return base64Str;
        }
    }
}
