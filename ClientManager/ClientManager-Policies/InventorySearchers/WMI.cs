using System;
using System.Collections.Generic;
using System.Management;

namespace ClientManager_Policies.InventorySearchers
{
    class WMI<T> : IDisposable where T : new()
    {
        private readonly string _scope;
        private readonly string _query;
        private readonly T _instance;
        bool _disposed;

        private ManagementObjectCollection moc;

        public WMI(T instance, string scope = "\\")
        {
            _instance = instance;
            _scope = scope;
            _query = instance.GetType().GetField("Query").GetValue(instance).ToString();
            SetObjectCollection();
        }

        public void SetObjectCollection()
        {
            var mScope = new ManagementScope(_scope);
            var oQuery = new ObjectQuery(_query);

            using (var objectSearcher = new ManagementObjectSearcher(mScope, oQuery))
            {
                objectSearcher.Options.BlockSize = 10;
                objectSearcher.Options.ReturnImmediately = true;
                objectSearcher.Options.Timeout = TimeSpan.FromSeconds(30);
                moc = objectSearcher.Get();
            }
        }

        public T Execute()
        {
           
            var type = _instance.GetType();
            
            foreach (var o in moc)
            {
                foreach (var a in type.GetProperties())
                {
                    if (o[a.Name] != null)
                        a.SetValue(_instance, o[a.Name],null);
                }
                //Can only handle one object in the collection, if more than 1 expected use GetObjectList
                break;
            }

            return _instance;
        }

     

        public List<T> GetObjectList()
        {
            
            var list = new List<T>();
            var inst = (T)Activator.CreateInstance(typeof(T));
            var type = inst.GetType();
         
            foreach (var o in moc)
            {
                int objCounter = 0;
                foreach (var a in type.GetProperties())
                {
                    objCounter++;
                    if (o[a.Name] != null)
                    {
                        a.SetValue(inst, o[a.Name], null);

                        if (type.GetProperties().Length == objCounter)
                        {
                            list.Add(inst);
                            inst = (T)Activator.CreateInstance(typeof(T));
                            
                        }
                    }
                }
            }

            return list;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~WMI()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                moc.Dispose();
            }

            _disposed = true;
        }

    }
}
