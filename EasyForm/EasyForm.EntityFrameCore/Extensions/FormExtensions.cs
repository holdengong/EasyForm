using EasyForm.Core.Extensions;
using EasyForm.Core.Models.Forms;
using EasyForm.EntityFrameCore.Entities.Forms;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyForm.EntityFrameCore.Extensions
{
    public static class FormExtensions
    {
        public static Entities.Forms.Form ToEntity(this Core.Models.Forms.Form form)
        {
            var result = new Entities.Forms.Form
            {
                Key = form.Key,
                Created = form.Created,
                Description = form.Description,
                Updated = form.Updated,
                BoolFields = form.Fields?.Where(x => x is Core.Models.Forms.Base.BoolField).Select(x => x as Core.Models.Forms.Base.BoolField).ToEntity(),
                DateTimeFields = form.Fields?.Where(x => x is Core.Models.Forms.DateTimeField).Select(x => x as Core.Models.Forms.DateTimeField).ToEntity(),
                DecimalFields = form.Fields?.Where(x => x is Core.Models.Forms.DecimalField).Select(x => x as Core.Models.Forms.DecimalField).ToEntity(),
                IntFields = form.Fields?.Where(x => x is Core.Models.Forms.IntField).Select(x => x as Core.Models.Forms.IntField).ToEntity(),
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
                IsRequired = field.IsRequired,
                FieldType = field.GetType().Name.ToLower()
            };
        }

        public static Core.Models.Forms.Base.BoolField ToModel(this Entities.Forms.BoolField field)
        {
            Type fieldType = field.GetType();
            if (fieldType == typeof(SwitchField))
            {
                return new SwitchField
                {
                    DefaultValue = field.DefaultValue,
                    Description = field.Description,
                    DisplayName = field.DisplayName,
                    FieldName = field.FieldName,
                    IsRequired = field.IsRequired
                };
            }

            throw new NotImplementedException($"unrecoganized bool field type: {fieldType.Name.ToLower()}");
        }

        public static IEnumerable<Entities.Forms.BoolField> ToEntity(this IEnumerable<Core.Models.Forms.Base.BoolField> fields)
        {
            var result = new List<Entities.Forms.BoolField>();
            fields?.ToList().ForEach(x => result.Add(x.ToEntity()));
            return result;
        }

        public static IEnumerable<Core.Models.Forms.Base.BoolField> ToModel(this IEnumerable<Entities.Forms.BoolField> fields)
        {
            var result = new List<Core.Models.Forms.Base.BoolField>();
            fields?.ToList().ForEach(x => result.Add(x.ToModel()));
            return result;
        }

        public static Entities.Forms.DateTimeField ToEntity(this Core.Models.Forms.DateTimeField field)
        {
            return new Entities.Forms.DateTimeField
            {
                Description = field.Description,
                FieldName = field.FieldName,
                IsRequired = field.IsRequired,
                FieldType = field.GetFieldType()
            };
        }

        public static Core.Models.Forms.DateTimeField ToModel(this Entities.Forms.DateTimeField field)
        {
            return new Core.Models.Forms.DateTimeField
            {
                AllowFilter = field.AllowFilter,
                AllowSort = field.AllowSort,
                DefaultValue = field.DefaultValue,
                Description = field.Description,
                DisplayName = field.DisplayName,
                FieldName = field.FieldName,
                IsRequired = field.IsRequired,
                IsUnique = field.IsUnique,
                Placeholder = field.Placeholder
            };
        }

        public static IEnumerable<Entities.Forms.DateTimeField> ToEntity(this IEnumerable<Core.Models.Forms.DateTimeField> fields)
        {
            var result = new List<Entities.Forms.DateTimeField>();
            fields?.ToList().ForEach(x => result.Add(x.ToEntity()));
            return result;
        }

        public static IEnumerable<Core.Models.Forms.DateTimeField> ToModel(this IEnumerable<Entities.Forms.DateTimeField> entities)
        {
            var result = new List<Core.Models.Forms.DateTimeField>();
            entities?.ToList().ForEach(x => result.Add(x.ToModel()));
            return result;
        }

        public static Entities.Forms.DecimalField ToEntity(this Core.Models.Forms.DecimalField field)
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

        public static Core.Models.Forms.DecimalField ToModel(this Entities.Forms.DecimalField entity)
        {
            return new Core.Models.Forms.DecimalField
            {
                AllowFilter = entity.AllowFilter,
                IsUnique = entity.IsUnique,
                IsRequired = entity.IsRequired,
                FieldName = entity.FieldName,
                DisplayName = entity.DisplayName,
                AllowSort = entity.AllowSort,
                Description = entity.Description,
                DefaultValue = entity.DefaultValue,
                Max = entity.Max,
                Min = entity.Min
            };
        }

        public static IEnumerable<Entities.Forms.DecimalField> ToEntity(this IEnumerable<Core.Models.Forms.DecimalField> fields)
        {
            var result = new List<Entities.Forms.DecimalField>();
            fields?.ToList().ForEach(x => result.Add(x.ToEntity()));
            return result;
        }

        public static IEnumerable<Core.Models.Forms.DecimalField> ToEntity(this IEnumerable<Entities.Forms.DecimalField> entities)
        {
            var result = new List<Core.Models.Forms.DecimalField>();
            entities?.ToList().ForEach(x => result.Add(x.ToModel()));
            return result;
        }


        public static Entities.Forms.IntField ToEntity(this Core.Models.Forms.IntField field)
        {
            return new Entities.Forms.IntField
            {
                Description = field.Description,
                FieldName = field.FieldName,
                IsRequired = field.IsRequired,
                DefaultValue = field.DefaultValue,
                Min = field.Min,
                Max = field.Max,
                FieldType = field.GetFieldType()
            };
        }

        public static Core.Models.Forms.IntField ToModel(this Entities.Forms.IntField entity)
        {
            var fieldType = entity.fiel
        }


        public static IEnumerable<Entities.Forms.IntField> ToEntity(this IEnumerable<Core.Models.Forms.IntField> fields)
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
                ObjType = field.ObjType.Name,
                FieldType = field.GetFieldType()
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

        public static IEnumerable<Core.Models.Forms.Option> ToModel(this IEnumerable<Entities.Forms.Option> entities)
        {
            var options = new List<Core.Models.Forms.Option>();
            if (entities.IsNullOrEmpty()) return options;

            entities.OrderBy(x => x.HierarchyCode).ToList().ForEach(entity =>
            {
                var option = new Core.Models.Forms.Option
                {
                    Label = entity.Label,
                    Value = entity.Value,
                    Children = new List<Core.Models.Forms.Option>()
                };

                SetChildren(option, entity);
            });

            return options;

            void SetChildren(Core.Models.Forms.Option option, Entities.Forms.Option entity)
            {
                var childEntities = entities.Where(x => x.Purpose == entity.Purpose && x.HierarchyCode.StartsWith(entity.HierarchyCode + "."));
                if (childEntities.IsNullOrEmpty()) return;
                childEntities.ToList().ForEach(childEntity =>
                {
                    var childOption = new Core.Models.Forms.Option
                    {
                        Label = childEntity.Label,
                        Value = childEntity.Value,
                        Children = new List<Core.Models.Forms.Option>()
                    };

                    SetChildren(childOption, childEntity);

                    option.Children.Add(childOption);
                });
            }
        }

        private static string GetFieldType(this Core.Models.Forms.Base.Field field)
        {
            return field.GetType().Name.ToLower().Replace("field", string.Empty);
        }
    }
}
