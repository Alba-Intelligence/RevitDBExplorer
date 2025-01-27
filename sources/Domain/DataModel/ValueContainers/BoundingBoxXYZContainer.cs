﻿using System.Collections.Generic;
using Autodesk.Revit.DB;

// (c) Revit Database Explorer https://github.com/NeVeSpl/RevitDBExplorer/blob/main/license.md

namespace RevitDBExplorer.Domain.DataModel.ValueContainers
{
    internal sealed class BoundingBoxXYZContainer : Base.ValueContainer<BoundingBoxXYZ>
    {
        protected override bool CanBeSnoooped(BoundingBoxXYZ box) => box is not null;
        protected override string ToLabel(BoundingBoxXYZ box)
        {
            return $"Min({box.Min.X:0.##}, {box.Min.Y:0.##}, {box.Min.Z:0.##}), Max({box.Max.X:0.##}, {box.Max.Y:0.##}, {box.Max.Z:0.##})";
        }
        protected override IEnumerable<SnoopableObject> Snooop(Document document, BoundingBoxXYZ box)
        {
            yield return new SnoopableObject(document, box);
        }
    }
}