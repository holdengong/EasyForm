using EasyForm.EntityFrameCore.Entities.Forms;
using EasyForm.EntityFrameCore.Entities.Records;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace EasyForm.EntityFrameCore.Extensions
{
    public static class RecordExtensions
    {
        public static Entities.Records.Record ToEntity(this Core.Models.Records.Record record)
        {
            var result = new Record
            {
                Created = record.Created,
                Updated = record.Updated,
                BoolFieldValues = record?.Values.Where(x => x is Core.Models.Records.Base.BoolFieldValue).Select(x => x as Core.Models.Records.Base.BoolFieldValue).ToEntity(),
                DateTimeFieldValues = record?.Values.Where(x => x is Core.Models.Records.Base.DateTimeFieldValue).Select(x => x as Core.Models.Records.Base.DateTimeFieldValue).ToEntity(),
                DecimalFieldValues = record?.Values.Where(x => x is Core.Models.Records.Base.DecimalFieldValue).Select(x => x as Core.Models.Records.Base.DecimalFieldValue).ToEntity(),
                Key = record.Key,
                FormKey = record.FormKey,
                IntFieldValues = record?.Values.Where(x => x is Core.Models.Records.Base.IntFieldValue).Select(x => x as Core.Models.Records.Base.IntFieldValue).ToEntity(),
                ObjectFieldValues = record?.Values.Where(x => x is Core.Models.Records.Base.ObjectFieldValue).Select(x => x as Core.Models.Records.Base.ObjectFieldValue).ToEntity()
            };

            return result;
        }

        public static Entities.Records.BoolFieldValue ToEntity(this Core.Models.Records.Base.BoolFieldValue value)
        {
            return new Entities.Records.BoolFieldValue
            {
                FieldName = value.FieldDefinition.FieldName,
                Value = value.Value
            };
        }

        public static IEnumerable<Entities.Records.BoolFieldValue> ToEntity(this IEnumerable<Core.Models.Records.Base.BoolFieldValue> values)
        {
            var result = new List<Entities.Records.BoolFieldValue>();
            values?.ToList().ForEach(x => result.Add(x.ToEntity()));
            return result;
        }

        public static Entities.Records.DateTimeFieldValue ToEntity(this Core.Models.Records.Base.DateTimeFieldValue value)
        {
            return new Entities.Records.DateTimeFieldValue
            {
                FieldName = value.FieldDefinition.FieldName,
                Value = value.Value
            };
        }

        public static IEnumerable<Entities.Records.DateTimeFieldValue> ToEntity(this IEnumerable<Core.Models.Records.Base.DateTimeFieldValue> values)
        {
            var result = new List<Entities.Records.DateTimeFieldValue>();
            values?.ToList().ForEach(x => result.Add(x.ToEntity()));
            return result;
        }

        public static Entities.Records.DecimalFieldValue ToEntity(this Core.Models.Records.Base.DecimalFieldValue value)
        {
            return new Entities.Records.DecimalFieldValue
            {
                FieldName = value.FieldDefinition.FieldName,
                Value = value.Value
            };
        }
        public static IEnumerable<Entities.Records.DecimalFieldValue> ToEntity(this IEnumerable<Core.Models.Records.Base.DecimalFieldValue> values)
        {
            var result = new List<Entities.Records.DecimalFieldValue>();
            values?.ToList().ForEach(x => result.Add(x.ToEntity()));
            return result;
        }

        public static Entities.Records.IntFieldValue ToEntity(this Core.Models.Records.Base.IntFieldValue value)
        {
            return new Entities.Records.IntFieldValue
            {
                FieldName = value.FieldDefinition.FieldName,
                Value = value.Value
            };
        }
        public static IEnumerable<Entities.Records.IntFieldValue> ToEntity(this IEnumerable<Core.Models.Records.Base.IntFieldValue> values)
        {
            var result = new List<Entities.Records.IntFieldValue>();
            values?.ToList().ForEach(x => result.Add(x.ToEntity()));
            return result;
        }

        public static Entities.Records.ObjectFieldValue ToEntity(this Core.Models.Records.Base.ObjectFieldValue value)
        {
            return new Entities.Records.ObjectFieldValue
            {
                FieldName = value.FieldDefinition.FieldName,
                Value = JsonConvert.SerializeObject(value.Value)
            };
        }

        public static IEnumerable<Entities.Records.ObjectFieldValue> ToEntity(this IEnumerable<Core.Models.Records.Base.ObjectFieldValue> fields)
        {
            var result = new List<Entities.Records.ObjectFieldValue>();
            fields?.ToList().ForEach(x => result.Add(x.ToEntity()));
            return result;
        }
    }
}
