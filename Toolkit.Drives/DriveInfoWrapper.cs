using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Toolkit.Drives
{
    public class DriveInfoWrapper
    {
        public enum UnitSize
        {
            KiloByte,
            MegaByte,
            GigaByte,
            TeraByte
        }


        private DriveInfo driveInfo;

        public DriveInfoWrapper(DriveInfo di)
        {
            driveInfo = di;
        }

        public DriveType DriveType
        {
            get
            {
                return (driveInfo.DriveType);
            }
        }

        public int GetTotalSize(UnitSize unitSize = UnitSize.GigaByte)
        {
            int ret = 0;

            ret = GetSizeInUnit(driveInfo.TotalSize, unitSize);

            return (ret);
        }

        public int GetTotalFreeSpace(UnitSize unitSize = UnitSize.GigaByte)
        {
            int ret = 0;

            ret = GetSizeInUnit(driveInfo.TotalFreeSpace, unitSize);

            return (ret);
        }

        private int GetSizeInUnit(long size, UnitSize unitSize = UnitSize.GigaByte)
        {
            int ret = 0;
            switch(unitSize)
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
                    ret = (int)(size / 1024);
                    break;
            }
            return (ret);
        }


    }
}
