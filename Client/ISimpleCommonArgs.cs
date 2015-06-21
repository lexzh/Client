namespace Client
{
    using System;

    public interface ISimpleCommonArgs
    {
        bool Check { get; }

        object DestinationMarshalByRefObject { get; set; }

        string ErrorInfo { get; set; }

        string InfoName { get; set; }

        bool IsNeed { get; set; }

        string PropertyName { get; set; }

        Type PropertyType { get; set; }
    }
}

