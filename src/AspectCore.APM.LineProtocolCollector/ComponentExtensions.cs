﻿using System;
using AspectCore.APM.Collector;
using AspectCore.APM.Common;
using AspectCore.Injector;

namespace AspectCore.APM.LineProtocolCollector
{
    public static class ComponentExtensions
    {
        public static ApmComponentOptions AddLineProtocolCollector(this ApmComponentOptions apmComponent, Action<LineProtocolClientOptions> configure)
        {
            if (apmComponent == null)
            {
                throw new ArgumentNullException(nameof(apmComponent));
            }
            if (configure == null)
            {
                throw new ArgumentNullException(nameof(configure));
            }
            apmComponent.Services.AddType<IPayloadClientProvider, LineProtocolPayloadClientProvider>(Lifetime.Singleton);
            var lineProtocolClientOptions = new LineProtocolClientOptions();
            configure(lineProtocolClientOptions);
            apmComponent.Services.AddInstance<IOptionAccessor<LineProtocolClientOptions>>(lineProtocolClientOptions);
            return apmComponent;
        }
    }
}