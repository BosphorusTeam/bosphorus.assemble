using System.Data;
using System.Globalization;
using NHibernate;
using NHibernate.SqlTypes;
using NHibernate.Type;

namespace Aras.Common.Customization.Bosphorus.Dao.NHibernate.Extension.Convention.UpperCaseValue
{
    public class UserType : AbstractStringType
    {
        private readonly CultureInfo cultureInfo;

        public UserType()
            : base(new StringSqlType())
        {
            cultureInfo = CultureInfo.GetCultureInfo("tr-TR");
        }

        public override void Set(IDbCommand cmd, object value, int index)
        {
            string upperCaseValue = ToUpper(value);
            IDbDataParameter dbDataParameter = (IDbDataParameter)cmd.Parameters[index];
            dbDataParameter.Value = upperCaseValue;

            if (dbDataParameter.Size > 0 && ((string)value).Length > dbDataParameter.Size)
                throw new HibernateException("The length of the string value exceeds the length configured in the mapping/parameter.");
        }

        public override object Get(IDataReader rs, int index)
        {
            object value = rs[index];
            string upperCaseString = ToUpper(value);
            return upperCaseString;
        }

        public override object Get(IDataReader rs, string name)
        {
            object value = rs[name];
            string upperCaseString = ToUpper(value);
            return upperCaseString;
        }

        public override string ToString(object val)
        {
            string upperCaseString = ToUpper(val);
            return upperCaseString;
        }

        public override object FromStringValue(string xml)
        {
            return xml;
        }

        private string ToUpper(object value)
        {
            string result = value.ToString().ToUpper(cultureInfo);
            return result;
        }

        public override string Name
        {
            get { return "UpperCase String"; }
        }
    }
}
