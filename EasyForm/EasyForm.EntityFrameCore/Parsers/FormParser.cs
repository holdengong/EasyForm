using EasyForm.Core.Extensions;
using EasyForm.Core.Models.Forms;
using EasyForm.Core.Models.Forms.Base;
using EasyForm.EntityFrameCore.Extensions;
using EasyForm.EntityFrameCore.Interfaces;
using EasyForm.EntityFrameCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyForm.EntityFrameCore.Parsers
{
    public abstract class FormParser : IFormParser
    {

        public virtual Entities.Forms.Form ToEntity(Core.Models.Forms.Form form)
        {
            var result = new Entities.Forms.Form
            {
                Key = form.Key,
                Created = form.Created,
                Description = form.Description,
                Updated = form.Updated,
                BoolFields = form.Fields?.Where(x => x is Core.Models.Forms.Base.BoolField).Select(x => x as Core.Models.Forms.Base.BoolField).ToEntity(),
                DateTimeFields = form.Fields?.Where(x => x is DateTimeField).Select(x => x as DateTimeField).ToEntity(),
                DecimalFields = form.Fields?.Where(x => x is DecimalField).Select(x => x as DecimalField).ToEntity(),
                IntFields = form.Fields?.Where(x => x is IntField).Select(x => x as IntField).ToEntity(),
                ObjectFields = form.Fields?.Where(x => x is Core.Models.Forms.Base.ObjectField).Select(x => x as Core.Models.Forms.Base.ObjectField).ToEntity()
            };

            return result;
        }

        public virtual Entities.Forms.BoolField ToEntity(Core.Models.Forms.Base.BoolField field)
        {
            return new Entities.Forms.BoolField
            {
                DefaultValue = field.DefaultValue,
                Description = field.Description,
                FieldName = field.FieldName,
                IsRequired = field.IsRequired,
                FieldType = GetFieldType(field),
                DisplayName = field.DisplayName
            };
        }

        public virtual Core.Models.Forms.Base.BoolField ToModel(Entities.Forms.BoolField field)
        {
            var fieldType = field.FieldType;

            switch (fieldType)
            {
                case FieldTypes.Switch:
                    return new SwitchField
                    {
                        DefaultValue = field.DefaultValue,
                        Description = field.Description,
                        DisplayName = field.DisplayName,
                        FieldName = field.FieldName,
                        IsRequired = field.IsRequired
                    };
            }

            throw new InvalidOperationException($"unknown field type {fieldType}");
        }

        public virtual IEnumerable<Entities.Forms.BoolField> ToEntity(IEnumerable<Core.Models.Forms.Base.BoolField> fields)
        {
            var result = new List<Entities.Forms.BoolField>();
            fields?.ToList().ForEach(x => result.Add(x.ToEntity()));
            return result;
        }

        public virtual IEnumerable<Core.Models.Forms.Base.BoolField> ToModel(IEnumerable<Entities.Forms.BoolField> fields)
        {
            var result = new List<Core.Models.Forms.Base.BoolField>();
            fields?.ToList().ForEach(x => result.Add(x.ToModel()));
            return result;
        }

        public virtual Entities.Forms.DateTimeField ToEntity(DateTimeField field)
        {
            return new Entities.Forms.DateTimeField
            {
                Description = field.Description,
                FieldName = field.FieldName,
                IsRequired = field.IsRequired,
                FieldType = GetFieldType(field),
                AllowFilter = field.AllowFilter,
                AllowSort = field.AllowSort,
                DefaultValue = field.DefaultValue,
                DisplayName = field.DisplayName,
                IsUnique = field.IsUnique,
                Placeholder = field.Placeholder
            };
        }

        public virtual DateTimeField ToModel(Entities.Forms.DateTimeField field)
        {
            string fieldType = field.FieldType;
            switch (fieldType)
            {
                case FieldTypes.DateTime:
                    return new DateTimeField
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
                case FieldTypes.Date:
                    return new DateField
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

            throw new InvalidOperationException($"unknown field type {fieldType}");
        }

        public IEnumerable<Entities.Forms.DateTimeField> ToEntity(IEnumerable<DateTimeField> fields)
        {
            var result = new List<Entities.Forms.DateTimeField>();
            fields?.ToList().ForEach(x => result.Add(x.ToEntity()));
            return result;
        }

        public IEnumerable<DateTimeField> ToModel(IEnumerable<Entities.Forms.DateTimeField> entities)
        {
            var result = new List<DateTimeField>();
            entities?.ToList().ForEach(x => result.Add(x.ToModel()));
            return result;
        }

        public Entities.Forms.DecimalField ToEntity(DecimalField field)
        {
            return new Entities.Forms.DecimalField
            {
                Description = field.Description,
                FieldName = field.FieldName,
                IsRequired = field.IsRequired,
                DefaultValue = field.DefaultValue,
                Min = field.Min,
                Max = field.Max,
                AllowFilter = field.AllowFilter,
                FieldType = GetFieldType(field),
                IsUnique = field.IsUnique,
                AllowSort = field.AllowSort,
                DisplayName = field.DisplayName
            };
        }

        public DecimalField ToModel(Entities.Forms.DecimalField entity)
        {
            string fieldType = entity.FieldType;
            switch (fieldType)
            {
                case FieldTypes.Decimal:
                    return new DecimalField
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

            throw new InvalidOperationException($"unknown field type {fieldType}");
        }

        public IEnumerable<Entities.Forms.DecimalField> ToEntity(IEnumerable<DecimalField> fields)
        {
            var result = new List<Entities.Forms.DecimalField>();
            fields?.ToList().ForEach(x => result.Add(x.ToEntity()));
            return result;
        }

        public IEnumerable<DecimalField> ToEntity(IEnumerable<Entities.Forms.DecimalField> entities)
        {
            var result = new List<DecimalField>();
            entities?.ToList().ForEach(x => result.Add(x.ToModel()));
            return result;
        }


        public Entities.Forms.IntField ToEntity(IntField field)
        {
            return new Entities.Forms.IntField
            {
                Description = field.Description,
                FieldName = field.FieldName,
                IsRequired = field.IsRequired,
                DefaultValue = field.DefaultValue,
                Min = field.Min,
                Max = field.Max,
                FieldType = GetFieldType(field),
                AllowFilter = field.AllowFilter,
                AllowSort = field.AllowSort,
                DisplayName = field.DisplayName,
                IsUnique = field.IsUnique
            };
        }

        public IntField ToModel(Entities.Forms.IntField entity)
        {
            var fieldType = entity.FieldType;
            switch (fieldType)
            {
                case FieldTypes.Int:
                    return new IntField
                    {
                        AllowFilter = entity.AllowFilter,
                        AllowSort = entity.AllowSort,
                        DefaultValue = entity.DefaultValue,
                        Description = entity.Description,
                        DisplayName = entity.DisplayName,
                        FieldName = entity.FieldName,
                        IsRequired = entity.IsRequired,
                        IsUnique = entity.IsUnique,
                        Max = entity.Max,
                        Min = entity.Min
                    };
            }
            throw new InvalidOperationException($"unknown field type {fieldType}");
        }


        public virtual IEnumerable<Entities.Forms.IntField> ToEntity(IEnumerable<IntField> fields)
        {
            var result = new List<Entities.Forms.IntField>();
            fields?.ToList().ForEach(x => result.Add(x.ToEntity()));
            return result;
        }

        public virtual Entities.Forms.ObjectField ToEntity(Core.Models.Forms.Base.ObjectField field)
        {
            return new Entities.Forms.ObjectField
            {
                Description = field.Description,
                FieldName = field.FieldName,
                IsRequired = field.IsRequired,
                FieldType = GetFieldType(field),
                DisplayName = field.DisplayName
            };
        }

        public virtual IEnumerable<Entities.Forms.ObjectField> ToEntity(IEnumerable<Core.Models.Forms.Base.ObjectField> fields)
        {
            var result = new List<Entities.Forms.ObjectField>();
            fields?.ToList().ForEach(x => result.Add(x.ToEntity()));
            return result;
        }

        public virtual Core.Models.Forms.Base.ObjectField ToModel(Entities.Forms.ObjectField entity)
        {
            string fieldType = entity.FieldType;
            switch (fieldType)
            {
                case FieldTypes.Cascader:
                    return new CascaderField
                    {
                         DefaultValue = entity.DefaultValue,
                          Description = entity.Description,
                           DisplayName = entity.DisplayName,
                            FieldName = entity.FieldName,
                             IsRequired = entity.IsRequired,
                              ObjType
                    };
                default:
                    break;
            }
        }

        public virtual IEnumerable<Entities.Forms.Option> ToEntity(IEnumerable<Core.Models.Forms.Option> options, string purpose)
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

            void SetChildren(Entities.Forms.Option entity, Core.Models.Forms.Option item)
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

        public virtual IEnumerable<Core.Models.Forms.Option> ToModel(IEnumerable<Entities.Forms.Option> entities)
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

        private string GetFieldType(Core.Models.Forms.Base.Field field)
        {
            return field.GetType().Name.ToLower().Replace("field", string.Empty);
        }
    }
}
