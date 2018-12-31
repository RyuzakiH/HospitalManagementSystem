using System;
using System.Runtime.Serialization;

namespace HospitalManagementSystem.Repositories
{
    [Serializable]
    internal class EntityNotFoundException<T> : Exception
    {
        private int id;

        public EntityNotFoundException()
        {
        }

        public EntityNotFoundException(int id)
        {
            this.id = id;
        }

        public EntityNotFoundException(string message) : base(message)
        {
        }

        public EntityNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EntityNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}