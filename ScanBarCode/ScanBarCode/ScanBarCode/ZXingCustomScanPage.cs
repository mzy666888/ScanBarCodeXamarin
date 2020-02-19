/*******************************************************************************************
 *Copyright (c) 2020  All Rights Reserved.
 *CLR版本: 4.0.30319.42000
 *机器名称:ZHIMATECH
 *公司名称:
 *命名空间:ScanBarCode
 *文件名:ZXingCustomScanPage
 *版本号:V1.0.0.0
 *唯一标识:722bc4cf-534a-4563-93c3-595108e303b7
 *当前的用户域:ZHIMATECH
 *创建人:Administrator
 *电子邮箱:mzyfbz@dingtalk.com
 *创建时间:2020/2/19 14:30:29

 *描述
 *
 *==========================================================================================
 *修改标记
 *修改时间:2020/2/19 14:30:29
 *修改人:Administrator
 *版本号:V1.0.0.0
 *描述:
 *
********************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace ScanBarCode
{
    /// <summary>
    /// ZXingCustomScanPage
    /// </summary>
    public class ZXingCustomScanPage : ContentPage
    {
        private ZXingScannerView _zxing;
        private ZXingScanOverlay _overlay;

        public ZXingCustomScanPage(ZXingScanOverlay overlay = null) : base()
        {
            _overlay = overlay ?? new ZXingScanOverlay();

            Title = "扫一扫";

            _zxing = new ZXingScannerView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                AutomationId = "zxingScannerView",
            };

            // 返回结果
            _zxing.OnScanResult += (result) =>
                Device.BeginInvokeOnMainThread(async () =>
                {
                    _zxing.IsAnalyzing = false;

                    await Navigation.PopAsync();

                    OnScanResult?.Invoke(result);
                });

            // 闪光灯
            _overlay.Options.FlashTappedAction = () =>
            {
                _zxing.IsTorchOn = !_zxing.IsTorchOn;
            };

            var grid = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };

            grid.Children.Add(_zxing);
            grid.Children.Add(_overlay);

            Content = grid;
        }

        // 扫描结果
        public Action<ZXing.Result> OnScanResult { get; set; }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            _zxing.IsScanning = true;

            if (_overlay != null && _overlay.Options.ShowScanAnimation)
                await _overlay.ScanAnimationAsync();
        }

        protected override void OnDisappearing()
        {
            _zxing.IsScanning = false;

            base.OnDisappearing();
        }
    }
}
