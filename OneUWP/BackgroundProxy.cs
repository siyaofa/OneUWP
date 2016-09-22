using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.UI.Popups;


namespace OneUWP
{
    class BackgroundProxy
    {
        /// <summary>
        /// 注册后台任务
        /// </summary>
        public async void Register()
        {
            BackgroundExecutionManager.RemoveAccess();
            var access = await BackgroundExecutionManager.RequestAccessAsync();
            if (access == BackgroundAccessStatus.DeniedBySystemPolicy || access == BackgroundAccessStatus.Unspecified)
            {
                await new MessageDialog("系统关闭了后台运行，请前往‘系统设置’进行设置").ShowAsync();
                return;
            }

            RegisterUpdateTopStoriesBackgroundTask();
        }
        /// <summary>
        /// 屏幕点亮时执行该任务
        /// </summary>
        private void RegisterUpdateTopStoriesBackgroundTask()
        {
         // BackgroundTaskAction.UpdateTile();
        }



    }
}
