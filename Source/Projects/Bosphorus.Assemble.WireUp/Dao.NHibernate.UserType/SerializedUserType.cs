using System;
using System.Data;
using Bosphorus.Common.Api.Container;
using Bosphorus.Serialization.Core.Serializer.Binary;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using NHibernate;
using NHibernate.SqlTypes;
using NHibernate.UserTypes;

namespace Bosphorus.Assemble.WireUp.Dao.NHibernate.UserType
{
    public class SerializedUserType<TModel> : AbstractUserType, IUserType
    {
        private readonly IBinarySerializer<TModel> serializer;
        private readonly IBinaryDeserializer<TModel> deserializer;
        public SerializedUserType()
        {
            serializer = Container.Resolve<IBinarySerializer<TModel>>();
            deserializer = Container.Resolve<IBinaryDeserializer<TModel>>();
        }

        public bool Equals(object x, object y) => x.Equals(y);

        public int GetHashCode(object x) => x.GetHashCode();

        public object NullSafeGet(IDataReader rs, string[] names, object owner)
        {
            byte[] serialized = (byte[])NHibernateUtil.BinaryBlob.NullSafeGet(rs, names[0]);
            var model = deserializer.Deserialize(serialized);
            return model;
        }

        public void NullSafeSet(IDbCommand cmd, object value, int index)
        {
            TModel model = (TModel) value;
            var serialized = serializer.Serialize(model);
            NHibernateUtil.BinaryBlob.NullSafeSet(cmd, serialized, index);
        }

        public object DeepCopy(object value) => value;

        public object Replace(object original, object target, object owner) => original;

        public object Assemble(object cached, object owner) => cached;

        public object Disassemble(object value) => value;

        public SqlType[] SqlTypes => new SqlType[] {SqlTypeFactory.GetBinaryBlob(int.MaxValue)};
        public Type ReturnedType => typeof(TModel);
        public bool IsMutable => false;
    }

}
