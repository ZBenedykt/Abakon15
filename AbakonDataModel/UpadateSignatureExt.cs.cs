using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using AbakonDataModel.Interfaces;

namespace AbakonDataModel
{
    public static class UpadateSignatureExt
    {

        private static string userName;

        public static string LoggedUserName
        {
            get { return UpadateSignatureExt.userName; }
            set { UpadateSignatureExt.userName = value; }
        }


        internal static void UpdatingStamp(this IUpdateSignature entity)
        {
            entity.ApplicationId = _Application.ThisApplication().ApplicationId;
            entity.LastUpdateDate = DateTime.Now;
            entity.UserName = LoggedUserName;

        }

        internal static void CreatingStamp(this  IUpdateSignature entity)
        {
            entity.ApplicationId = _Application.ThisApplication().ApplicationId;
            entity.CreateDate = DateTime.Now;
            entity.LastUpdateDate = DateTime.Now;
            entity.UserName = LoggedUserName;
        }


        public static void UpdateInfoFile(this  IInfoFile entity, FileInfo fileInfo)
        {
            entity.infoFile.Attributes = (int)fileInfo.Attributes;
            entity.infoFile.CreationTime = fileInfo.CreationTime;
            entity.infoFile.CreationTimeUtc = fileInfo.CreationTimeUtc;
            entity.infoFile.Directory = fileInfo.Directory.ToString();
            entity.infoFile.DirectoryName = fileInfo.DirectoryName;
            entity.infoFile.Extension = fileInfo.Extension;
            entity.infoFile.FullName = fileInfo.FullName;
            entity.infoFile.IsReadOnly = fileInfo.IsReadOnly;
            entity.infoFile.LastAccessTime = fileInfo.LastAccessTime;
            entity.infoFile.LastAccessTimeUtc = fileInfo.LastAccessTimeUtc;
            entity.infoFile.LastWriteTime = fileInfo.LastWriteTime;
            entity.infoFile.LastWriteTimeUtc = fileInfo.LastWriteTimeUtc;
            entity.infoFile.Length = fileInfo.Length;
            entity.infoFile.Name = fileInfo.Name;
        }

        public static void UpdateSignature(this  Document entity, FileInfo fileInfo)
        {
            if (entity.docSignature == null || entity.docSignature.Trim() == string.Empty)
            {
                entity.docSignature = fileInfo.Name;
            }
        }

    }
}
