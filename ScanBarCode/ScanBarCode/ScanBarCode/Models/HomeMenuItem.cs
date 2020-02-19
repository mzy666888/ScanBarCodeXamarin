using System;
using System.Collections.Generic;
using System.Text;

namespace ScanBarCode.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        ScanQrCode //二维码扫码菜单
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
