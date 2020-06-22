using EasyForm.Core.Extensions;
using EasyForm.EntityFrameCore.Entities.Forms;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyForm.EntityFrameCore.Extensions
{
    public static class FormExtensions
    {
        public static Form ToEntity(this Core.Models.Forms.Form form)
        {
            var result = new Form
            {
                Key = form.Key,
                Created = form.Created,
                Description = form.Description,
                Updated = form.Updated,
                BoolFields = form.Fields?.Where(x => x is Core.Models.Forms.Base.BoolField).Select(x => x as Core.Models.Forms.Base.BoolField).ToEntity(),
                DateTimeFields = form.Fields?.Where(x => x is Core.Models.Forms.Base.DateTimeField).Select(x => x as Core.Models.Forms.Base.DateTimeField).ToEntity(),
                DecimalFields = form.Fields?.Where(x => x is Core.Models.Forms.Base.DecimalField).Select(x => x as Core.Models.Forms.Base.DecimalField).ToEntity(),
                IntFields = form.Fields?.Where(x => x is Core.Models.Forms.Base.IntField).Select(x => x as Core.Models.Forms.Base.IntField).ToEntity(),
                ObjectFields = form.Fields?.Where(x => x is Core.Models.Forms.Base.ObjectField).Select(x => x as Core.Models.Forms.Base.ObjectField).ToEntity()
            };

            return result;
        }

        public static Entities.Forms.BoolField ToEntity(this Core.Models.Forms.Base.BoolField field)
        {
            return new Entities.Forms.BoolField
            {
                DefaultValue = field.DefaultValue,
                Description = field.Description,
                FieldName = field.FieldName,
                IsRequired = field.IsRequired
            };
        }

        public static IEnumerable<Entities.Forms.BoolField> ToEntity(this IEnumerable<Core.Models.Forms.Base.BoolField> fields)
        {
            var result = new List<Entities.Forms.BoolField>();
            fields?.ToList().ForEach(x => result.Add(x.ToEntity()));
            return result;
        }

        public static Entities.Forms.DateTimeField ToEntity(this Core.Models.Forms.Base.DateTimeField field)
        {
            return new Entities.Forms.DateTimeField
            {
                Description = field.Description,
                FieldName = field.FieldName,
                IsRequired = field.IsRequired
            };
        }

        public static IEnumerable<Entities.Forms.DateTimeField> ToEntity(this IEnumerable<Core.Models.Forms.Base.DateTimeField> fields)
        {
            var result = new List<Entities.Forms.DateTimeField>();
            fields?.ToList().ForEach(x => result.Add(x.ToEntity()));
            return result;
        }

        public static Entities.Forms.DecimalField ToEntity(this Core.Models.Forms.Base.DecimalField field)
        {
            return new Entities.Forms.DecimalField
            {
                Description = field.Description,
                FieldName = field.FieldName,
                IsRequired = field.IsRequired,
                DefaultValue = field.DefaultValue,
                Min = field.Min,
                Max = field.Max
            };
        }
        public static IEnumerable<Entities.Forms.DecimalField> ToEntity(this IEnumerable<Core.Models.Forms.Base.DecimalField> fields)
        {
            var result = new List<Entities.Forms.DecimalField>();
            fields?.ToList().ForEach(x => result.Add(x.ToEntity()));
            return result;
        }

        public static Entities.Forms.IntField ToEntity(this Core.Models.Forms.Base.IntField field)
        {
            return new Entities.Forms.IntField
            {
                Description = field.Description,
                FieldName = field.FieldName,
                IsRequired = field.IsRequired,
                DefaultValue = field.DefaultValue,
                Min = field.Min,
                Max = field.Max
            };
        }
        public static IEnumerable<Entities.Forms.IntField> ToEntity(this IEnumerable<Core.Models.Forms.Base.IntField> fields)
        {
            var result = new List<Entities.Forms.IntField>();
            fields?.ToList().ForEach(x => result.Add(x.ToEntity()));
            return result;
        }

        public static ObjectField ToEntity(this Core.Models.Forms.Base.ObjectField field)
        {
            return new ObjectField
            {
                Description = field.Description,
                FieldName = field.FieldName,
                IsRequired = field.IsRequired,
                ObjType = field.ObjType.Name
            };
        }

        public static IEnumerable<Entities.Forms.ObjectField> ToEntity(this IEnumerable<Core.Models.Forms.Base.ObjectField> fields)
        {
            var result = new List<Entities.Forms.ObjectField>();
            fields?.ToList().ForEach(x => result.Add(x.ToEntity()));
            return result;
        }

        public static IEnumerable<Entities.Forms.Option> ToEntity(this IEnumerable<Core.Models.Forms.Option> options, string purpose)
        {
            if (purpose.IsMissing())
            {
                throw new ArgumentNullException(nameof(purpose));
            }

            var entities = new List<Entities.Forms.Option>();
            if (options.IsNullOrEmpty()) return entities;

            foreach (var item in options)
            {
                var entity = new Entities.Forms.Option
                {
                    Label = item.Label,
                    Value = item.Value,
                    Purpose = purpose,
                    HierarchyCode = item.Value
                };

                entities.Add(entity);

                SetChildren(entity, item);
            }

            return entities;

            void SetChildren(Entities.Forms.Option entity , Core.Models.Forms.Option item)
            {
                if (item.Children.IsNullOrEmpty()) return;

                item.Children.ForEach(childOption =>
                {
                    var childEntity = new Entities.Forms.Option
                    {
                        Label = childOption.Label,
                        Value = childOption.Value,
                        Purpose = entity.Purpose,
                        HierarchyCode = entity.HierarchyCode + "." + item.Value
                    };

                    SetChildren(childEntity, childOption);

                    entities.Add(childEntity);
                });
            }
        }
    }
}
