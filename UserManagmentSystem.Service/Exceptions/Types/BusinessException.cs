using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagmentSystem.Service.Exceptions.Types;

public sealed class BusinessException(string message) : Exception(message);
