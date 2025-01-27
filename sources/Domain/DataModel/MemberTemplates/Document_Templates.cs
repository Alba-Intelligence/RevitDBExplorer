﻿using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;
using RevitDBExplorer.Domain.DataModel.MemberTemplates.Base;

// (c) Revit Database Explorer https://github.com/NeVeSpl/RevitDBExplorer/blob/main/license.md

namespace RevitDBExplorer.Domain.DataModel.MemberTemplates
{
    internal class Document_Templates : IHaveMemberTemplates
    {
        private static readonly IEnumerable<ISnoopableMemberTemplate> templates = Enumerable.Empty<ISnoopableMemberTemplate>();

        static Document_Templates()
        {
            templates = new ISnoopableMemberTemplate[]
            {
                SnoopableMemberTemplate<Document>.Create((doc, target) => Document.GetDocumentVersion(target), kind: SnoopableMember.Kind.StaticMethod),
#if R2023b
                SnoopableMemberTemplate<Document>.Create((doc, target) => target.GetChangedElements(Guid.Empty), kind: SnoopableMember.Kind.Method),
#endif

                SnoopableMemberTemplate<Document>.Create((doc, target) => BasicFileInfo.Extract(target.PathName), kind: SnoopableMember.Kind.StaticMethod),
               
            };
        }


        public IEnumerable<ISnoopableMemberTemplate> GetTemplates()
        {
            return templates;
        }
    }
}
