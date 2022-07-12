﻿using System;
using System.Globalization;
using System.Windows.Data;
using RevitDBExplorer.Domain.DataModel;

namespace RevitDBExplorer.WPF.Converters
{
    internal class FeetToMetersConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var snoopableMember = value as SnoopableMember;

            if (snoopableMember == null) return null;

            if ((snoopableMember.ValueTypeName == "Double") && (double.TryParse(snoopableMember.Value, out double parsed)))
            {
                double result = parsed * 0.3048;
                return $"{result} [m]";
            }
            return snoopableMember.Value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
