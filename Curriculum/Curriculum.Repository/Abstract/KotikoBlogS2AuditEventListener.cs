#region Curriculum Header License

// // Solution: Curriculum
// // Project: Curriculum.Repository
// //
// // This file is included in the Curriculum solution.
// //
// // File created on 14/01/2016   14:54
// //
// // File Modified on 14/01/2016/   14:54
// 
// // Permission is hereby granted, free of charge, to any person obtaining a copy
// // of this software and associated documentation files (the "Software"), to deal
// // in the Software without restriction, including without limitation the rights
// // to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// // copies of the Software, and to permit persons to whom the Software is
// // furnished to do so, subject to the following conditions:
// //
// // The above copyright notice and this permission notice shall be included in all
// // copies or substantial portions of the Software.
// //
// // THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// // IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// // FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// // AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// // LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// // OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// // SOFTWARE.

#endregion

#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Curriculum.Models.Annotations;
using NHibernate.Envers;
using NHibernate.Envers.Event;
using NHibernate.Event;

#endregion

namespace Curriculum.Repository.Abstract
{
    /// <summary>
    /// 
    /// </summary>
    public class CurriculumAuditEventListener : AuditEventListener, IPreUpdateEventListener, IPreInsertEventListener,
        IPreDeleteEventListener, IPreCollectionRecreateEventListener
    {
        /// <summary>
        /// 
        /// </summary>
        private const string MODEL_NAMESPACE = "Curriculum.Models";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="evt"></param>
        public void OnPreRecreateCollection(PreCollectionRecreateEvent evt)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="evt"></param>
        /// <returns></returns>
        public bool OnPreDelete(PreDeleteEvent evt)
        {
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="evt"></param>
        /// <returns></returns>
        public bool OnPreInsert(PreInsertEvent evt)
        {
            var index = Array.IndexOf(evt.Persister.PropertyNames, "FechaAlta");

            if (index >= 0 && evt.Entity.GetType().Namespace.StartsWith(MODEL_NAMESPACE))
            {
                evt.State[index] = VerCfg.RevisionTimestampGetter.Get(evt.Session.Auditer().GetCurrentRevision(false));
                evt.Entity.GetType()
                    .GetProperties()
                    .First(x => x.Name.CompareTo("FechaAlta") == 0)
                    .SetValue(evt.Entity, evt.State[index]);
                evt.Entity.GetType()
                    .GetProperties()
                    .First(x => x.Name.CompareTo("FechaModificacion") == 0)
                    .SetValue(evt.Entity, null);
                evt.Entity.GetType()
                    .GetProperties()
                    .First(x => x.Name.CompareTo("FechaBaja") == 0)
                    .SetValue(evt.Entity, null);
                GetAuditedProperties(evt.Entity.GetType().GetProperties()).ToList().ForEach(x =>
                {
                    var value = x.GetValue(evt.Entity, null);
                    value.GetType()
                        .GetProperties()
                        .First(y => y.Name.CompareTo("FechaModificacion") == 0)
                        .SetValue(value, evt.State[index]);
                });
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="evt"></param>
        /// <returns></returns>
        public bool OnPreUpdate(PreUpdateEvent evt)
        {
            var index = Array.IndexOf(evt.Persister.PropertyNames, "FechaModificacion");
            if (index >= 0 && evt.Entity.GetType().Namespace.StartsWith(MODEL_NAMESPACE))
            {
                evt.State[index] = VerCfg.RevisionTimestampGetter.Get(evt.Session.Auditer().GetCurrentRevision(false));
                evt.Entity.GetType()
                    .GetProperties()
                    .First(x => x.Name.CompareTo("FechaModificacion") == 0)
                    .SetValue(evt.Entity, evt.State[index]);
                GetAuditedProperties(evt.Entity.GetType().GetProperties()).ToList().ForEach(x =>
                {
                    var value = x.GetValue(evt.Entity, null);
                    value.GetType()
                        .GetProperties()
                        .First(y => y.Name.CompareTo("FechaModificacion") == 0)
                        .SetValue(value, evt.State[index]);
                });
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="evt"></param>
        public override void OnPreUpdateCollection(PreCollectionUpdateEvent evt)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="evt"></param>
        public override void OnPreRemoveCollection(PreCollectionRemoveEvent evt)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="properties"></param>
        /// <returns></returns>
        private static IEnumerable<PropertyInfo> GetAuditedProperties(PropertyInfo[] properties)
        {
            return properties.Where(x => x.GetCustomAttribute<ParentAuditedAttribute>(false) != null);
        }
    }
}