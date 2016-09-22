using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace OneUWP
{
    /// <summary>
    /// 负责加载、保存、漫游配置数据  各个ViewModel之间共享此数据
    /// </summary>
    public sealed class DataShareManager
    {
        private ElementTheme _app_theme;
        public ElementTheme APPTheme
        {
            get
            {
                return _app_theme;
            }
        }


        private Visibility _progressRingVisibility;
        public Visibility ProgressRingVisibility
        {
            get
            {
                return _progressRingVisibility;
            }
        }



        private static DataShareManager _current;
        public static DataShareManager Current
        {
            get
            {
                if (_current == null)
                {
                    _current = new DataShareManager();
                }
                return _current;
            }
        }
        public event ShareDataChangedEventHandler ShareDataChanged;

        public DataShareManager()
        {
            LoadData();
        }

        private void LoadData()
        {
            var roamingSettings = Windows.Storage.ApplicationData.Current.RoamingSettings;
            if (roamingSettings.Values.ContainsKey("APP_THEME"))
            {
                _app_theme = int.Parse(roamingSettings.Values["APP_THEME"].ToString()) == 0 ? ElementTheme.Light : ElementTheme.Dark;
            }
            else
            {
                _app_theme = ElementTheme.Light;
            }
            _progressRingVisibility = Visibility.Collapsed;
        }
        private void OnShareDataChanged()
        {
            ShareDataChanged?.Invoke();
        }
        public void UpdateAPPTheme(bool dark)
        {
            _app_theme = dark ? ElementTheme.Dark : ElementTheme.Light;
            var roamingSettings = Windows.Storage.ApplicationData.Current.RoamingSettings;
            roamingSettings.Values["APP_THEME"] = _app_theme == ElementTheme.Light ? 0 : 1;
            OnShareDataChanged();
        }

        public void UpdateProgressRingVisibility(Visibility visibility)
        {
            _progressRingVisibility = visibility;
            OnShareDataChanged();
        }

    }

    public delegate void ShareDataChangedEventHandler();
}
