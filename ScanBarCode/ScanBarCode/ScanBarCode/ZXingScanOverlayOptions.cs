/*******************************************************************************************
 *Copyright (c) 2020  All Rights Reserved.
 *CLR版本: 4.0.30319.42000
 *机器名称:ZHIMATECH
 *公司名称:
 *命名空间:ScanBarCode
 *文件名:ZXingScanOverlayOptions
 *版本号:V1.0.0.0
 *唯一标识:026a68ac-7bb6-4c47-bc55-76eda42399dd
 *当前的用户域:ZHIMATECH
 *创建人:Administrator
 *电子邮箱:mzyfbz@dingtalk.com
 *创建时间:2020/2/19 14:27:58

 *描述
 *
 *==========================================================================================
 *修改标记
 *修改时间:2020/2/19 14:27:58
 *修改人:Administrator
 *版本号:V1.0.0.0
 *描述:
 *
********************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using static Xamarin.Forms.LayoutOptions;

namespace ScanBarCode
{
    public class ZXingScanOverlayOptions
    {
        public ZXingScanOverlayOptions()
        {
            TopLabel = new Label
            {
                VerticalOptions = Center,
                HorizontalOptions = Center,
                TextColor = Color.White,
                AutomationId = "zxingDefaultOverlay_TopTextLabel",
            };

            BottomLabel = new Label
            {
                VerticalOptions = Center,
                HorizontalOptions = Center,
                TextColor = Color.White,
                AutomationId = "zxingDefaultOverlay_BottomTextLabel",
            };

            FlashLabel = new Label
            {
                HorizontalOptions = End,
                VerticalOptions = End,
                Text = "闪光灯",
                FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Label)),
                TextColor = Color.White,
                AutomationId = "zxingDefaultOverlay_FlashButton",
                Margin = new Thickness(8)
            };
        }

        // 顶部标签
        public Label TopLabel { get; private set; }
        // 底部标签
        public Label BottomLabel { get; private set; }
        // 闪光灯
        public Label FlashLabel { get; private set; }
        // 闪光灯点击操作
        public Action FlashTappedAction { get; set; }

        // 扫描框大小
        public double ScanWidth { get; set; } = 230;
        public double ScanHeight { get; set; } = 230;

        // 扫描光及扫描线的颜色
        public Color ScanColor { get; set; } = Color.White;
        // 是否显示闪光灯
        public bool ShowFlash { get; set; }
        // 是否显示扫描动画
        public bool ShowScanAnimation { get; set; } = true;
    }
}
