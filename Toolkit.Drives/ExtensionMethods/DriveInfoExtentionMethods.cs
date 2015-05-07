using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Toolkit.Drives.ExtentionMethods
{
    public static class DriveInfoExtentionMethods
    {
        public enum UnitSize
        {
            Bytes,
            KiloByte,
            MegaByte,
            GigaByte,
            TeraByte
        }

        public static long GetTotalSize(this DriveInfo driveInfo, UnitSize unitSize = UnitSize.GigaByte)
        {
            long ret = 0;

            ret = GetSizeInUnit(driveInfo.TotalSize, unitSize);

            return (ret);
        }

        public static long GetTotalFreeSpace(this DriveInfo driveInfo, UnitSize unitSize = UnitSize.GigaByte)
        {
            long ret = 0;

            ret = GetSizeInUnit(driveInfo.TotalFreeSpace, unitSize);

            return (ret);
        }

        public static int GetPercentFree(this DriveInfo driveInfo)
        {
            int ret = 0;

            double percent = driveInfo.TotalFreeSpace / (driveInfo.TotalSize / 100);
            ret = (int)Math.Round(percent, 0);

            return (ret);
        }

        public static long GetSizeInUnit(long size, UnitSize unitSize = UnitSize.GigaByte)
        {
            long ret = 0;
            switch (unitSize)
            {
                case UnitSize.TeraByte:
                    ret = GetSizeInUnit(size, UnitSize.GigaByte) / 1024;
                    break;
                case UnitSize.GigaByte:
                    ret = GetSizeInUnit(size, UnitSize.MegaByte) / 1024;
                    break;
                case UnitSize.MegaByte:
                    ret = GetSizeInUnit(size, UnitSize.KiloByte) / 1024;
                    break;
                case UnitSize.KiloByte:
                    ret = (GetSizeInUnit(size, UnitSize.Bytes) / 1024);
                    break;
                case UnitSize.Bytes:
                    ret = size;
                    break;
            }
            return (ret);
        }
    }
}
