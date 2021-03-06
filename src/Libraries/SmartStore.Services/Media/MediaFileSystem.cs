﻿using System;
using SmartStore.Core.Data;
using SmartStore.Core.IO;
using SmartStore.Utilities;

namespace SmartStore.Services.Media
{
	public interface IMediaFileSystem : IFileSystem
	{
	}

	public class MediaFileSystem : LocalFileSystem, IMediaFileSystem
	{
		public MediaFileSystem()
			: base(GetMediaBasePath(), CommonHelper.GetAppSetting<string>("sm:MediaPublicPath"))
		{
			this.TryCreateFolder("Storage");
			this.TryCreateFolder("Thumbs");
			this.TryCreateFolder("Uploaded");
			this.TryCreateFolder("QueuedEmailAttachment");
			this.TryCreateFolder("Downloads");
		}

		private static string GetMediaBasePath()
		{
			var path = CommonHelper.GetAppSetting<string>("sm:MediaStoragePath")?.Trim().NullEmpty();
			if (path == null)
			{
				path = "/App_Data/Tenants/" + DataSettings.Current.TenantName + "/Media";
			}

			return path;
		}
	}
}
