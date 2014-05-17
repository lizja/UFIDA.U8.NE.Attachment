using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using System.Linq;
using System.Text;
using System.Xml.Linq;

using UFSoft.U8.Framework.Login.UI;
using UFSoft.U8.Framework.LoginContext;
using UFIDA.U8.SlFileServer.FileManagerLib;

using UFIDA.U8.NE.BO;


namespace UFIDA.U8.NE.Attachment
{
    /// <summary>
    /// 附件服务
    /// </summary>
    public class AttachmentProvider
    {
        public AttachmentProvider()
        {
            
        }
        /// <summary>
        /// 转换附件实体信息
        /// </summary>
        /// <param name="u8Login"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public AttachmentInfo ConvertAttachment(clsLogin u8Login,string fileName)
        {
            if (string.IsNullOrEmpty(fileName) == true)
            {
                throw new Exception("文件不能为空！");
            }

            AttachmentInfo attachmentInfo = new AttachmentInfo();

            UFSoft.U8.Framework.LoginContext.UserData userData = u8Login.GetLoginInfo();
            attachmentInfo.FileServer = u8Login.GetFileServerInfo(u8Login.userToken, true); 
            attachmentInfo.FileName = fileName;
            attachmentInfo.Account = userData.AccID;
            attachmentInfo.DataSource = userData.DataSource;
            attachmentInfo.FileSize = 0;
            attachmentInfo.Owner = userData.UserId;
            attachmentInfo.Password = userData.Password;
            attachmentInfo.ServerFileName = string.Empty;
            attachmentInfo.UserId = userData.UserId;
            attachmentInfo.Year = int.Parse(userData.iYear);

            return attachmentInfo;
        }
        /// <summary>
        /// 添加文件
        /// </summary>
        /// <param name="attachmentInfo"></param>
        /// <returns></returns>
        public string AddFile(AttachmentInfo attachmentInfo)
        {
            AttachmentCheck(attachmentInfo);

            FileManager fileManager = new FileManager();

            string newFileName =
                fileManager.CallWebServiceAddFile(attachmentInfo.FileName, attachmentInfo.FileServer, attachmentInfo.UserId,
                attachmentInfo.Password, attachmentInfo.Owner, attachmentInfo.FileSize, attachmentInfo.DataSource, attachmentInfo.Account, attachmentInfo.Year);

            return newFileName;
        }
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="attachmentInfo"></param>
        /// <returns></returns>
        public bool DeleteFile(AttachmentInfo attachmentInfo)
        {
            AttachmentCheck(attachmentInfo);

            FileManager fileManager = new FileManager();

            bool isSuccess = fileManager.CallWebServiceDeleteFile(attachmentInfo.FileServer, attachmentInfo.FileName);

            return isSuccess;
        }
        private void AttachmentCheck(AttachmentInfo attachmentInfo)
        {
            if (attachmentInfo == null)
            {
                throw new ArgumentNullException("附件信息为空，请检查！");
            }
            if (string.IsNullOrEmpty(attachmentInfo.FileServer) == true)
            {
                throw new Exception("文件服务器有异常，请检查！");
            }
            if (string.IsNullOrEmpty(attachmentInfo.FileName) == true)
            {
                throw new Exception("文件不能为空！");
            }
        }
    }
}
