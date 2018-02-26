﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using DevExpress.Mvvm;
using VKMSmalta.Services.Navigate;
using VKMSmalta.View.Elements.ViewModel;
using VKMSmalta.View.InnerPages.ViewModel;

namespace VKMSmalta.View.ViewModel
{
    public class MainInnerDevicePageViewModel : InnerPageViewModelBase
    {
        public MainInnerDevicePageViewModel() : base(InnerRegionPages.Main, "View/Images/Background.png")
        {
            InitializeElements(); //TODO: ВЫШЕ!
        }

        private void InitializeElements()
        {
            //TODO: Добавить начальное состояние элементам из CurrentAlgorithm.StartStateOfElements
            Elements = new ObservableCollection<ElementViewModelBase>
                       {
                           //Тумблеры в середине
                           new VkmThumblerViewModel(0, "thumbler_1channel") { PosTop = 285, PosLeft = 330, StartupRotation = 90 },
                           new VkmThumblerViewModel(0, "thumbler_2channel") { PosTop = 330, PosLeft = 330, StartupRotation = 90 },
                           new VkmThumblerViewModel(0, "thumbler_3channel") { PosTop = 375, PosLeft = 330, StartupRotation = 90 },
                           new VkmThumblerViewModel(0, "thumbler_4channel") { PosTop = 420, PosLeft = 330, StartupRotation = 90 },

                           //Тумблеры снизу
                           new VkmThumblerViewModel(1, "thumbler_imitator") { PosTop = 595, PosLeft = 375 },
                           new VkmThumblerViewModel(0, "thumbler_antenna_leftside") { PosTop = 600, PosLeft = 660 },
                           new VkmThumblerViewModel(0, "thumbler_antenna_rightside") { PosTop = 600, PosLeft = 750 },
                           new VkmThumblerViewModel(0, "thumbler_light") { PosTop = 670, PosLeft = 750 },
                           
                           //Тумблеры справа сверху
                           new VkmThumblerViewModel(0, "thumbler_power") { PosTop = 70, PosLeft = 1189 },
                           new VkmThumblerViewModel(0, "thumbler_cold") { PosTop = 70, PosLeft = 1235 },
                           new VkmThumblerViewModel(0, "thumbler_autosarpp") { PosTop = 70, PosLeft = 1287 },
                           new VkmThumblerViewModel(0, "thumbler_aircontrol") { PosTop = 70, PosLeft = 1340 },
                           
                           //Тумблеры справа снизу
                           new VkmThumblerViewModel(0, "thumbler_cooler") { PosTop = 660, PosLeft = 1180 },
                           new VkmThumblerViewModel(0, "thumbler_light_maintance") { PosTop = 660, PosLeft = 1223 },
                           new VkmThumblerViewModel(0, "thumbler_light_advanced") { PosTop = 660, PosLeft = 1270 },
                           new VkmThumblerViewModel(0, "thumbler_light_table") { PosTop = 660, PosLeft = 1317 },

                           //Стрелки слева
                           new VkmBlackTriangleArrowViewModel(0, "channel1_arrow", 40) { PosTop = 25, PosLeft = 25 },
                           //TODO: Добавить стрелки.
                       };
        }
    }
}