﻿using System;
using System.Globalization;
using System.Windows.Data;
using RevitDBExplorer.Domain.DataModel;
using RevitDBExplorer.Domain.DataModel.ValueContainers;
using RevitDBExplorer.UIComponents.List.ValuePresenters;

namespace RevitDBExplorer.WPF.Converters
{
    internal class FeetToMetersConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var snoopableMember = value as SnoopableMember;

            if (snoopableMember == null) return null;

            if (snoopableMember.ValueViewModel is DefaultPresenterVM presenter)
            {
                if (presenter.ValueContainer is DoubleContainer container)
                {
                    double result = container.Value * 0.3048;
                    return $"{result} [m]";
                }
            }
            return snoopableMember.Label.Text;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
