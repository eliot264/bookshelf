using Bookshelf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bookshelf.Exceptions
{
    public class InvalidEntityDetailsModeException : Exception
    {
        public InvalidEntityDetailsModeException()
        {
        }

        public InvalidEntityDetailsModeException(EntityDetailsMode currentMode, EntityDetailsMode expectedMode, Type classType) : base(GetMessage(currentMode, expectedMode, classType))
        {
        }

        public InvalidEntityDetailsModeException(EntityDetailsMode currentMode, EntityDetailsMode expectedMode, Type classType, Exception? innerException) : base(GetMessage(currentMode, expectedMode, classType), innerException)
        {
        }

        private static string GetMessage(EntityDetailsMode currentMode, EntityDetailsMode expectedMode, Type classType)
        {
            return $"in class of type {classType.Name}, expected EntityDetailsMode is {expectedMode.ToString()}, but was passed an object with {currentMode.ToString()} EntityDetailsMode";
        }
    }
}
