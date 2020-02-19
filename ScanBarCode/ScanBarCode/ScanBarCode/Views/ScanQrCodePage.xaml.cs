using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace ScanBarCode.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScanQrCodePage : ContentPage
    {
        public ScanQrCodePage()
        {
            InitializeComponent();
        }

        private async void ScanBarCodeBtn_OnClicked(object sender, EventArgs e)
        {
            if (await CheckPerssion())
            {
                var scanner = new MobileBarcodeScanner();
                var result = await scanner.Scan();
                if (null != result)
                {
                    ScanTextResult.Text = result.Text;
                }
            }
        }

        private async void CustomScanBarCodeBtn_OnClicked(object sender, EventArgs e)
        {
            if (await CheckPerssion())
            {
                var options = new ZXingScanOverlayOptions()
                {
                    ScanColor = Color.Green,
                    ShowFlash = true
                };
                var overlay = new ZXingScanOverlay(options);
                var csPage = new ZXingCustomScanPage(overlay);

                csPage.OnScanResult = (result) =>
                {
                    if (null != result)
                    {
                        CustomScanResult.Text = result.Text;
                    }
                };

                await Navigation.PushAsync(csPage);
            }
        }

        private void BuildQrCdoeBtn_OnClicked(object sender, EventArgs e)
        {

            var barcode = new ZXingBarcodeImageView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            barcode.BarcodeFormat = ZXing.BarcodeFormat.QR_CODE;
            barcode.BarcodeOptions.Width = 300;
            barcode.BarcodeOptions.Height = 300;
            barcode.BarcodeOptions.Margin = 10;
            barcode.BarcodeValue = "Xamarin.Forms";
            QrCodeSite.Children.Add(barcode);
        }

        /// <summary>
        /// 检查权限
        /// </summary>
        /// <returns></returns>
        private async Task<bool> CheckPerssion()
        {
            var current = CrossPermissions.Current;
            var status = await current.CheckPermissionStatusAsync<CameraPermission>();
            if (PermissionStatus.Granted != status)
            {
                status = await current.RequestPermissionAsync<CameraPermission>();
            }
            return status == PermissionStatus.Granted;
        }
    }
}