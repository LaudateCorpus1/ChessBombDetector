using System;
using System.Collections.Generic;

namespace ChessBombDetector.Utils
{
  class FactoryRegistry<TKey, TBaseClass> where TBaseClass: class
  {
    private readonly Dictionary<TKey, Func<TBaseClass>> _factories = new Dictionary<TKey, Func<TBaseClass>>();

    public void Register<TClass>(TKey key) where TClass: TBaseClass, new()
    {
      _factories.Add(key, () => new TClass());
    }
    
    public TBaseClass CreateInstance(TKey key)
    {
      return _factories[key]();
    }

  }
}
