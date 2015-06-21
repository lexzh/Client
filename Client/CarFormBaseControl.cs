namespace Client
{
    using System;

    public class CarFormBaseControl
    {
        public virtual void Init(CarFormEx carform)
        {
        }

        public virtual bool Send(CarFormEx carform)
        {
            return true;
        }
    }
}

