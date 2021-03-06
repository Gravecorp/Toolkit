﻿using System;
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
            Bytes,
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

        public string DriveFormat
        {
            get
            {
                return (driveInfo.DriveFormat);
            }
        }

        public string DriveLabel
        {
            get
            {
                return (driveInfo.VolumeLabel);
            }
        }

        public string DriveName
        {
            get
            {
                return (driveInfo.Name);
            }
        }

        public bool IsReady
        {
            get
            {
                return (driveInfo.IsReady);
            }
        }

        public long GetTotalSize(UnitSize unitSize = UnitSize.GigaByte)
        {
            long ret = 0;

            ret = GetSizeInUnit(driveInfo.TotalSize, unitSize);

            return (ret);
        }

        public long GetTotalFreeSpace(UnitSize unitSize = UnitSize.GigaByte)
        {
            long ret = 0;

            ret = GetSizeInUnit(driveInfo.TotalFreeSpace, unitSize);

            return (ret);
        }

        public int GetPercentFree()
        {
            int ret = 0;

            double percent = driveInfo.TotalFreeSpace / (driveInfo.TotalSize / 100);
            ret = (int)Math.Round(percent, 0);
            
            return (ret);
        }

        private long GetSizeInUnit(long size, UnitSize unitSize = UnitSize.GigaByte)
        {
            long ret = 0;
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
