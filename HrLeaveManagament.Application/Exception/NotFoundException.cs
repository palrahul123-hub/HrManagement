﻿namespace HrLeaveManagament.Application.Exception
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, object key) : base($"{name} {key} was not found")
        {

        }
    }
}
